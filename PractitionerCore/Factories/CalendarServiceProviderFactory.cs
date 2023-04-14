using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractitionerCore.Factories
{
    public class CalendarServiceProviderFactory
    {
        public static ICalendarService GetCalenderServiceByPractitoner(Practitioner practitioner)
        {
            switch (practitioner.Provider.ToLower())
            {
                case "google":
                    return new GoogleCalendar();
                case "microsoft":
                    return new MicrosoftCalendar();
                default:
                    return new NoClendar();
            }
        }
    }
}
