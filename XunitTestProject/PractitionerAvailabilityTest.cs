using Moq;
using PractitionerCore;
using PractitionerCore.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XunitTestProject.TestDataFactory;
using XunitTestProject.TestDataFixture;
using XunitTestProject.TestDataGenerators;

namespace XunitTestProject
{
    public class PractitionerAvailabilityTest : IClassFixture<TestPractitionerFixture> 
    {
        Practitioner _practitioner;
        public PractitionerAvailabilityTest(TestPractitionerFixture practitoner)
        {
            _practitioner = practitoner.Practitioner;
        }

        [Fact]
        [Trait("Practitoner","AvailabilityTests")]
        public void Practioner_SetAvailability()
        {
            int dayId = 0;
            string startSlot = string.Empty;
            string endSlot = string.Empty;
            _practitioner.SetStarAndEndTimeSlot(dayId , startSlot, endSlot);

            Assert.True(_practitioner.AvailabilitySlots.Count > 0);
        }

        [Trait("Practitoner", "AvailabilityTests")]
        [Theory]
        [InlineData("00:00", "00:00")]
        public void Practitioner_SlotShouldBeWithin24hrs(string startSlot, string endSlot)
        {
            int dayId = 0;
            _practitioner.SetStarAndEndTimeSlot(dayId, startSlot, endSlot);

            Assert.False(_practitioner.AvailabilitySlots.Any(x=>TimeSpan.Parse( x.StartTime).Hours < 0 && TimeSpan.Parse(x.StartTime).Hours > 24));
        }

        [Trait("Practitoner", "AvailabilityTests")]
        [Theory]
        //[InlineData(1,"08:00", "08:30")]
        [ClassData(typeof(TestSlotDataGenerator))]
        public void Practitioner_ShouldBeAvaialbleWithIn_SelectdSlot(DateTime selectedDate,string startSlot, string endSlot)
        {
            var practitioner = PractitionerAvailableSlotDatafactory.LoadAvailableSLots(_practitioner);

            //Assert.True(practitioner.AvailabilitySlots.
            //    Any(x=> TimeSpan.Parse(x.StartTime) <= TimeSpan.Parse(startSlot) 
            //    && TimeSpan.Parse(x.EndTime) >= TimeSpan.Parse(endSlot)));
            var mock = new Mock<ICalendarService>();
            mock.Setup(p => p.GetEvents(It.IsAny<DateTime>())).Returns(new List<DaySlot>());

            Assert.True(practitioner.IsAvailable(selectedDate, startSlot, endSlot, mock.Object));
        }

        [Trait("Practitoner", "AvailabilityTests")]
        [Theory]
        //[InlineData(DateTime.Now,"08:00", "08:30")]
        [ClassData(typeof(TestSlotDataGenerator))]
        public void Practitioner_ShouldBeAvaialble_In_Calendar(DateTime selectedDate, string startSlot, string endSlot)
        {
            var practitioner = PractitionerAvailableSlotDatafactory.LoadAvailableSLots(_practitioner);

            var mock = new Mock<ICalendarService>();
            mock.Setup(p => p.GetEvents(It.IsAny<DateTime>())).Returns(new List<DaySlot>() { new DaySlot(1, "08:00", "08:30") });

            Assert.True(_practitioner.IsAvailable(DateTime.Now, startSlot, endSlot, mock.Object));
        }

        [Trait("Practitoner", "CalendarService")]
        [Theory]
        [InlineData("google" , typeof(GoogleCalendar))]
        [InlineData("microsoft", typeof(MicrosoftCalendar))]
        public void Check_CalendarSrviceFactory(string provider , Type type)
        {
            _practitioner.Provider = provider;
            var calendarService = CalendarServiceProviderFactory.GetCalenderServiceByPractitoner(_practitioner);

            Assert.IsType(type,calendarService);
        }

    }
}
