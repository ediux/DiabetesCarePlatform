namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_UnitTaskMetaData))]
    public partial class SYS_UnitTask
    {
    }
    
    public partial class SYS_UnitTaskMetaData
    {
        [Required]
        public int UnitID { get; set; }
        [Required]
        public int ChronicTypeID { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
