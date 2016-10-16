namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PME_ExaminationHeadMetaData))]
    public partial class PME_ExaminationHead
    {
    }
    
    public partial class PME_ExaminationHeadMetaData
    {
        [Required]
        public long ID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public System.DateTime ExaminationDate { get; set; }
        [Required]
        public int ChronicTypeID { get; set; }
        [Required]
        public int ChronicSubTypeID { get; set; }
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
