using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Data
{
    public class FN_GetMeetingRoomsRemainTableResult
    {
        public int TimeSectionId { get; set; }
        public DateTime Day { get; set; }
        public int DayofWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int RemainAmount { get; set; }
    }
}