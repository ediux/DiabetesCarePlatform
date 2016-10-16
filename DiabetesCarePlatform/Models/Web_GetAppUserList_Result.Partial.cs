namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetAppUserList_ResultMetaData))]
    public partial class Web_GetAppUserList_Result
    {
    }
    
    public partial class Web_GetAppUserList_ResultMetaData
    {
        [Required]
        public int AppUserID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string MailAddress { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Name { get; set; }
        public Nullable<int> SexID { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public int ChronicSubTypeID { get; set; }
        public Nullable<System.DateTime> DiagnosisDate { get; set; }
        public Nullable<decimal> BodyHeight { get; set; }
        public Nullable<decimal> BodyWeight { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string MobileNumber { get; set; }
        public Nullable<bool> NoiceByMessage { get; set; }
        public Nullable<bool> NoiceByPhone { get; set; }
        public Nullable<bool> NoiceByPush { get; set; }
        public Nullable<short> PaymentType { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int PatientID { get; set; }
    }
}
