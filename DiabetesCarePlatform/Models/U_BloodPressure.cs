using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class U_BloodPressure
    {
        public Int64 ID { get; set; }
        public int AppUserID { get; set; }
        public DateTime RecordTime { get; set; }
        public Int64 Systolic { get; set; }
        public Int64 Diastolic { get; set; }
        public Int64 Heartbeat { get; set; }
        public DateTime UploadTime { get; set; }
    }
}