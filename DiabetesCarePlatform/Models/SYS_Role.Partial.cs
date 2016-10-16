namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_RoleMetaData))]
    public partial class SYS_Role
    {
    }
    
    public partial class SYS_RoleMetaData
    {
        [Required]
        public int RoleID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string RoleName { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
