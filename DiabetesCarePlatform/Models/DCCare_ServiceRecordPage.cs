using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class DCCare_ServiceRecordPage
    {
        public int PatientID { get; set; }
        public List<CG_ServiceRecord_Extend> RecordList { get; set; }
        public List<SYS_ServiceRecordType> ServiceRecordType { get; set; }
        public List<SYS_ServiceResult> ServiceResult { get; set; }
        public List<SYS_ServiceType> ServiceType { get; set; }
    }
}