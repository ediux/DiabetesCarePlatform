using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class DCGroupDMReportViewModel
    {
        public Int64 PatientID { get; set; }
        public string MedicalNumber { get; set; }
        public string PatientName { get; set; }
        public int SexID { get; set; }
        public DateTime Birthday { get; set; }
        public string ChronicName { get; set; }
        public string ChronicSubName { get; set; }
        public DateTime StartDate { get; set; }
    }
}