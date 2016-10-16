namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetAPPUserInfo_ResultMetaData))]
    public partial class Web_GetAPPUserInfo_Result
    {
    }
    
    public partial class Web_GetAPPUserInfo_ResultMetaData
    {
        [Required]
        public int AppUserID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string MailAddress { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Name { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> SexID { get; set; }
    }
}
