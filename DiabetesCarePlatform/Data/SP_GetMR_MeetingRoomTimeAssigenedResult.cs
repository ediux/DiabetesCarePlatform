using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Data
{
    public class SP_GetMR_MeetingRoomTimeAssigenedResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DayOfWeek { get; set; }
        public int TimeSectionId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}