using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Data
{
    public class Web_Get_VideoScheduleResult
    {
        public int UserID { get; set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string start_url { get; set; }
        public string join_url { get; set; }
        public string host_id { get; set; }
        public string topic { get; set; }
        public string password { get; set; }
        public int room_id { get; set; }
        public int CaseAmount { get; set; }
        public string uuid { get; set; }
        public string meet_id { get;set; }
        public int TimeSectionId { get; set; }
    }
}