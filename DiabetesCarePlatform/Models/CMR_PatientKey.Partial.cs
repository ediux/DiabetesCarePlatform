namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CMR_PatientKeyMetaData))]
    public partial class CMR_PatientKey
    {
    }
    
    public partial class CMR_PatientKeyMetaData
    {
        [Required]
        public int PatientID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string MedicalRecordNumber { get; set; }
        [Required]
        public int ChronicTypeID { get; set; }
        [Required]
        public int ChronicSubTypeID { get; set; }
        public Nullable<int> ParentUnitID { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> AppUserID { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int CaseStatus { get; set; }
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
