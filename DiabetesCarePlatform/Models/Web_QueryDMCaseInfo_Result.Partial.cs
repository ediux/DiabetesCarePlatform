namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_QueryDMCaseInfo_ResultMetaData))]
    public partial class Web_QueryDMCaseInfo_Result
    {
    }
    
    public partial class Web_QueryDMCaseInfo_ResultMetaData
    {
        public Nullable<int> PatientID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string MedicalRecordNumber { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string PatientName { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        public string SexName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string ChronicSubName { get; set; }
        
        [StringLength(300, ErrorMessage="欄位長度不得大於 300 個字元")]
        public string GroupName { get; set; }
        
        [StringLength(300, ErrorMessage="欄位長度不得大於 300 個字元")]
        public string GroupID { get; set; }
    }
}
