namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYSHT_UserAssignRoleMetaData))]
    public partial class SYSHT_UserAssignRole
    {
    }
    
    public partial class SYSHT_UserAssignRoleMetaData
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int RoleID { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
        [Required]
        public int RemoveUserID { get; set; }
        [Required]
        public System.DateTime RemoveDate { get; set; }
    }
}
