using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class DCCareIndexUserViewModel
    {
        public DCCareIndexViewModel UserDataModel { get; set; }
    }

    public class DCCareIndexViewModel
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string SexName { get; set; }
        public string Age { get; set; }
        public string MedicalRecordNumber { get; set; }
        public string HomeTelphone { get; set; }
        public string CellPhone { get; set; }
        public string ChronicSubName { get; set; }
        public int Status { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string GroupName { get; set; }
        public string GroupID { get; set; }
    }
}