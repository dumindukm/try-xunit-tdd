using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractitionerCore
{
    public interface ICalendarService
    {
        public List<DaySlot> GetEvents(DateTime selectedDate);
    }
    public class NoClendar : ICalendarService
    {
        public List<DaySlot> GetEvents(DateTime selectedDate)
        {
            return new List<DaySlot>();
        }
    }

    public class MicrosoftCalendar : ICalendarService
    {
        public List<DaySlot> GetEvents(DateTime selectedDate)
        {
            throw new NotImplementedException();
        }
    }

    public class GoogleCalendar : ICalendarService
    {
        public List<DaySlot> GetEvents(DateTime selectedDate)
        {
            throw new NotImplementedException();
        }
    }
}
