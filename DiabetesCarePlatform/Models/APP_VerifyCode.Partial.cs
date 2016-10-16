namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(APP_VerifyCodeMetaData))]
    public partial class APP_VerifyCode
    {
    }
    
    public partial class APP_VerifyCodeMetaData
    {
        [Required]
        public int PatientID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string VerifyCode { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
