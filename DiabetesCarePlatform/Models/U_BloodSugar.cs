using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class U_BloodSugar
    {
        public Int64 ID { get; set; }
        public int AppUserID { get; set; }
        public string RecordTime { get; set; }
        public int TimingTypeID { get; set; }
        public int MealTypeID { get; set; }
        public decimal ResultValue { get; set; }
        public string Note { get; set; }
        public string PictrueUrl { get; set; }
       
    }
}