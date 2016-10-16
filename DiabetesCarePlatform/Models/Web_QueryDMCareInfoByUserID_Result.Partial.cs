namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_QueryDMCareInfoByUserID_ResultMetaData))]
    public partial class Web_QueryDMCareInfoByUserID_Result
    {
    }
    
    public partial class Web_QueryDMCareInfoByUserID_ResultMetaData
    {
        public Nullable<int> PatientID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string PatientName { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string HomeTelphone { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string CellPhone { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string MedicalRecordNumber { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        public string SexName { get; set; }
        
        [StringLength(300, ErrorMessage="欄位長度不得大於 300 個字元")]
        public string GroupName { get; set; }
        
        [StringLength(300, ErrorMessage="欄位長度不得大於 300 個字元")]
        public string GroupID { get; set; }
    }
}
