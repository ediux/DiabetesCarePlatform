using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class CMR_PatientKey
    {
     
        public int PatientID { get; set; }

        [Required]
        [StringLength(30)]
        public string MedicalRecordNumber { get; set; }

        public int ChronicTypeID { get; set; }

        public int ChronicSubTypeID { get; set; }

        public int ParentUnitID { get; set; }

        public int? UnitID { get; set; }

        public int? AppUserID { get; set; }

        public bool Enable { get; set; }

        public int CaseStatus { get; set; }

        public int CreateUserID { get; set; }
     
        public DateTime CreateDate { get; set; }

        public int LastUserID { get; set; }

        public DateTime LastUpdate { get; set; }

        // For個人基本資料修改
        public int Section { get; set; }
    }
    public class CMR_Patient_Extend : CMR_PatientKey
    {
        public DateTime Birthday { get; set; }
        public string SexName { get; set; }
        public string PatientName { get; set; }
        public string ChronicSubName { get; set; }
        public string GroupName { get; set; }
        public string GroupID { get; set; }
    }
}