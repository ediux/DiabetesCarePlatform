namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(U_BloodPressureMetaData))]
    public partial class U_BloodPressure
    {
    }
    
    public partial class U_BloodPressureMetaData
    {
        [Required]
        public long ID { get; set; }
        [Required]
        public int AppUserID { get; set; }
        [Required]
        public System.DateTime RecordTime { get; set; }
        [Required]
        public int Systolic { get; set; }
        [Required]
        public int Diastolic { get; set; }
        [Required]
        public int Heartbeat { get; set; }
        [Required]
        public System.DateTime UploadTime { get; set; }
    }
}
