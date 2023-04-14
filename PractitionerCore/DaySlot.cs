using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractitionerCore
{
    public class DaySlot
    {
        public DaySlot(int dayId, string startTime, string endTime)
        {
            DayId = dayId;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int DayId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
