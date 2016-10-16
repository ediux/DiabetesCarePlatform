using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class CMR_PatientBase
    {
      
        public int PatientID { get; set; }
        [StringLength(30)]
        public string PatientName { get; set; }
        [Key]
        [StringLength(30)]
        public string IdentityNumber { get; set; }

        public DateTime Birthday { get; set; }

        public decimal BodyHeight { get; set; }

        public decimal BodyWeight { get; set; }

        public int? SexID { get; set; }

        public int? RaceTypeID { get; set; }

        public int? BloodTypeID { get; set; }

        public int? BloodRhTypeID { get; set; }

        [StringLength(30)]
        public string DisabledID { get; set; }

        public int? LanguageTypeID { get; set; }

        public int? ReligionTypeID { get; set; }

        public int? MaritalStatus { get; set; }

        public int? RegisterCountryID { get; set; }

        public int? RegisterStateID { get; set; }

        public int? RegisterCityID { get; set; }

        public int? RegisterDistrictID { get; set; }

        [StringLength(100)]
        public string RegisterAddress { get; set; }

        public int? EducationLevelID { get; set; }

        public int CreateUserID { get; set; }
    
        public DateTime CreateDate { get; set; }
      
        public int LastUserID { get; set; }
     
        public DateTime LastUpdate { get; set; }

        // For個人基本資料修改
        public int Section { get; set; }
    }
}