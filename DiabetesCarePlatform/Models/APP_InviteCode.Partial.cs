namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(APP_InviteCodeMetaData))]
    public partial class APP_InviteCode
    {
    }
    
    public partial class APP_InviteCodeMetaData
    {
        [Required]
        public int AppUserID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string InviteCode { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
