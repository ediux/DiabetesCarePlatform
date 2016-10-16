using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class MedicalRecordViewModel
    {
        public Int64 ID { get; set; }
        public int AppUserID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string TimeType { get; set; }
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public string MedicineValue { get; set; }
    }
}