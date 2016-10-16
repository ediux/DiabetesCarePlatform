namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_UserAssignUnitMetaData))]
    public partial class SYS_UserAssignUnit
    {
    }
    
    public partial class SYS_UserAssignUnitMetaData
    {
        [Required]
        public int UnitID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
