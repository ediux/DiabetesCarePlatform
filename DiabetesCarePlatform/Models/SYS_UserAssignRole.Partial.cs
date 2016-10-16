namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_UserAssignRoleMetaData))]
    public partial class SYS_UserAssignRole
    {
    }
    
    public partial class SYS_UserAssignRoleMetaData
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int RoleID { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
