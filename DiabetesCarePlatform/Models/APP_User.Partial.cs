namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(APP_UserMetaData))]
    public partial class APP_User
    {
    }
    
    public partial class APP_UserMetaData
    {
        [Required]
        public int AppUserID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string MailAddress { get; set; }
        [Required]
        public byte[] Password { get; set; }
        
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
        
        [StringLength(128, ErrorMessage="欄位長度不得大於 128 個字元")]
        [Required]
        public string MobileToken { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string MobileNumber { get; set; }
        public Nullable<bool> NoiceByPush { get; set; }
        public Nullable<bool> NoiceByMessage { get; set; }
        public Nullable<bool> NoiceByPhone { get; set; }
        public Nullable<short> PaymentType { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public System.DateTime CreateDate { get; set; }
        [Required]
        public System.DateTime VerifyDate { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
