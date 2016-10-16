namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYSHT_UserAssignUnitMetaData))]
    public partial class SYSHT_UserAssignUnit
    {
    }
    
    public partial class SYSHT_UserAssignUnitMetaData
    {
        [Required]
        public int UnitID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public Nullable<System.DateTime> RemoveDate { get; set; }
    }
}
