namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(APP_LoginUserMetaData))]
    public partial class APP_LoginUser
    {
    }
    
    public partial class APP_LoginUserMetaData
    {
        [Required]
        public int AppUserID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string LoginKey { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
