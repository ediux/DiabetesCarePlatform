namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CMRHT_PatientBaseMetaData))]
    public partial class CMRHT_PatientBase
    {
    }
    
    public partial class CMRHT_PatientBaseMetaData
    {
        [Required]
        public int PatientID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string PatientName { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string IdentityNumber { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<decimal> BodyHeight { get; set; }
        public Nullable<decimal> BodyWeight { get; set; }
        public Nullable<int> SexID { get; set; }
        public Nullable<int> RaceTypeID { get; set; }
        public Nullable<int> BloodTypeID { get; set; }
        public Nullable<int> BloodRhTypeID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string DisabledID { get; set; }
        public Nullable<int> LanguageTypeID { get; set; }
        public Nullable<int> ReligionTypeID { get; set; }
        public Nullable<int> MaritalStatus { get; set; }
        public Nullable<int> RegisterCountryID { get; set; }
        public Nullable<int> RegisterStateID { get; set; }
        public Nullable<int> RegisterCityID { get; set; }
        public Nullable<int> RegisterDistrictID { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string RegisterAddress { get; set; }
        public Nullable<int> EducationLevelID { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        [Required]
        public System.DateTime CreateDate { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
