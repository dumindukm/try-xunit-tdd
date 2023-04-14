using System.Collections.Concurrent;

namespace PractitionerCore
{
    public class Practitioner
    {
        private Practitioner()
        {
            _slots = new List<DaySlot>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        private readonly List<DaySlot> _slots;

        public IReadOnlyList<DaySlot> AvailabilitySlots => _slots;

        public string Provider { get; set; }

        public static Practitioner Create(string firstName, string lastName, string email)
        {
            var practitioner = new Practitioner();
            practitioner.FirstName = firstName;
            practitioner.LastName = lastName;
            practitioner.Email = email;

            return practitioner;
        }

        public void SetStarAndEndTimeSlot(int dayId,string startTime , string endTime)
        {
            _slots.Add(new DaySlot(dayId,startTime , endTime));
        }

        public bool IsAvailable(DateTime selectedDate, string startSlot, string endSlot, ICalendarService calendarService)
        {
            bool isAvailable = false;
            isAvailable =  AvailabilitySlots.
                Any(x => TimeSpan.Parse(x.StartTime) <= TimeSpan.Parse(startSlot)
                && TimeSpan.Parse(x.EndTime) >= TimeSpan.Parse(endSlot));

            if (isAvailable)
            {
                var daySlots = calendarService.GetEvents(selectedDate);

                if (daySlots.Any())
                {
                    isAvailable = daySlots.Any(x => TimeSpan.Parse(x.StartTime) <= TimeSpan.Parse(startSlot)
                && TimeSpan.Parse(x.EndTime) >= TimeSpan.Parse(endSlot));
                }

            }

            return isAvailable;
        }
    }
}