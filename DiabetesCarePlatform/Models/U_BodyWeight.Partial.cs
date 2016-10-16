namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(U_BodyWeightMetaData))]
    public partial class U_BodyWeight
    {
    }
    
    public partial class U_BodyWeightMetaData
    {
        [Required]
        public long ID { get; set; }
        [Required]
        public int AppUserID { get; set; }
        [Required]
        public System.DateTime RecordTime { get; set; }
        [Required]
        public decimal BodyWeight { get; set; }
        [Required]
        public decimal BodyFat { get; set; }
        [Required]
        public System.DateTime UploadTime { get; set; }
    }
}
