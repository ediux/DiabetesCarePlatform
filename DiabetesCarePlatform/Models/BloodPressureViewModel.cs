using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class BloodPressureViewModel
    {
        public Int64 ID { get; set; }
        public int AppUserID { get; set; }
        public string Date { get; set; }
        public string WeekDay { get; set; }
        public string Time { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public int Heartbeat { get; set; }
        public DateTime RecordTime { get; set; }
    }
}