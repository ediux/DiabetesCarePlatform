namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_UnitAssignRole_DelMetaData))]
    public partial class SYS_UnitAssignRole_Del
    {
    }
    
    public partial class SYS_UnitAssignRole_DelMetaData
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
