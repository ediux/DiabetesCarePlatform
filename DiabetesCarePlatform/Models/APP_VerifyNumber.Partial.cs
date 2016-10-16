namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(APP_VerifyNumberMetaData))]
    public partial class APP_VerifyNumber
    {
    }
    
    public partial class APP_VerifyNumberMetaData
    {
        [Required]
        public int PatientID { get; set; }
        
        [StringLength(6, ErrorMessage="欄位長度不得大於 6 個字元")]
        [Required]
        public string VerifyNunber { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
