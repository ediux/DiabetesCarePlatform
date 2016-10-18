namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_UnitAssignRoleMetaData))]
    public partial class SYS_UnitAssignRole
    {
    }
    
    public partial class SYS_UnitAssignRoleMetaData
    {
        [Required]
        public int UnitID { get; set; }
        [Required]
        public int RoleID { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
