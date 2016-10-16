namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CGHT_CareGroupMetaData))]
    public partial class CGHT_CareGroup
    {
    }
    
    public partial class CGHT_CareGroupMetaData
    {
        [Required]
        public int UnitID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int ChronicTypeID { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public Nullable<System.DateTime> RemoveDate { get; set; }
    }
}
