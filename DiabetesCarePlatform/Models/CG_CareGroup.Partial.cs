namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CG_CareGroupMetaData))]
    public partial class CG_CareGroup
    {
    }
    
    public partial class CG_CareGroupMetaData
    {
        [Required]
        public int CGUnitID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int ChronicTypeID { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
