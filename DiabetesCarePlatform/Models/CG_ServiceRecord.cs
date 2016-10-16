using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class CG_ServiceRecord
    {
        public int PatientID { get; set; }
        public string ServiceDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int ServiceRecordTypeID { get; set; }
        public int ServiceTypeID { get; set; }
        public string ServiceTypeNote { get; set; }
        public int ServiceResultID { get; set; }
        public string ServiceResultNote { get; set; }
        public string Note { get; set; }
        public string ResponseMessage { get; set; }
    }
    public class CG_ServiceRecord_Extend : CG_ServiceRecord
    {
        public string ServiceRecordTypeName { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceResultName { get; set; }
        public string UserName { get; set; }
    }
}