using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Data
{
    public class MR_MeetingRoomTimes
    {
        [Key]
        public int TimeSectionId { get; set; }
        
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}