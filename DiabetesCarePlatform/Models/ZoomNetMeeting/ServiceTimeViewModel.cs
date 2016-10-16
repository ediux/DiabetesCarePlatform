using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class ServiceTimeViewModel
    {
        public int TimeSectionId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}