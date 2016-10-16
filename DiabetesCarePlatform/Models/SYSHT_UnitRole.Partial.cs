namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYSHT_UnitRoleMetaData))]
    public partial class SYSHT_UnitRole
    {
    }
    
    public partial class SYSHT_UnitRoleMetaData
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
