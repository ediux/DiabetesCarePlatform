namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_LoginUserMetaData))]
    public partial class SYS_LoginUser
    {
    }
    
    public partial class SYS_LoginUserMetaData
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int UnitID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string LoginKey { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        public string IP { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
