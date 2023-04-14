using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitTestProject.TestDataFactory
{
    internal class PractitionerAvailableSlotDatafactory
    {
        public static Practitioner LoadAvailableSLots(Practitioner practitioner)
        {
            practitioner.SetStarAndEndTimeSlot(1, "08:00", "17:00");
            practitioner.SetStarAndEndTimeSlot(2, "08:00", "17:00");
            practitioner.SetStarAndEndTimeSlot(3, "08:00", "17:00");
            practitioner.SetStarAndEndTimeSlot(4, "08:00", "17:00");
            practitioner.SetStarAndEndTimeSlot(5, "08:00", "17:00");
            return practitioner;
        }
    }
}
