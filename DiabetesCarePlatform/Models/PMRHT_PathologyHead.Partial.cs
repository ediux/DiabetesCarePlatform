namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PMRHT_PathologyHeadMetaData))]
    public partial class PMRHT_PathologyHead
    {
    }
    
    public partial class PMRHT_PathologyHeadMetaData
    {
        [Required]
        public long ID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public System.DateTime InspectionDate { get; set; }
        [Required]
        public System.DateTime DiagnosisDate { get; set; }
        [Required]
        public int ChronicTypeID { get; set; }
        [Required]
        public int ChronicSubTypeID { get; set; }
        [Required]
        public byte[] FamilyHistoryTypeID { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        [Required]
        public System.DateTime CreateDate { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
