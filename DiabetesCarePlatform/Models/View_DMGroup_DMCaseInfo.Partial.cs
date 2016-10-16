namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_DMGroup_DMCaseInfoMetaData))]
    public partial class View_DMGroup_DMCaseInfo
    {
    }
    
    public partial class View_DMGroup_DMCaseInfoMetaData
    {
        [Required]
        public int PatientID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string MedicalNumber { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string PatientName { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        public string SexName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string ChronicSubName { get; set; }
        [Required]
        public int GroupCount { get; set; }
        public Nullable<int> RaceTypeID { get; set; }
        public Nullable<int> SexID { get; set; }
        public Nullable<int> ChronicSubTypeID { get; set; }
    }
}
