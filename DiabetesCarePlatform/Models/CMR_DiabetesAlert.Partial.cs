namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CMR_DiabetesAlertMetaData))]
    public partial class CMR_DiabetesAlert
    {
    }
    
    public partial class CMR_DiabetesAlertMetaData
    {
        [Required]
        public int PatientID { get; set; }
        [Required]
        public System.DateTime RecordTime { get; set; }
        [Required]
        public int DiabetesAlertType { get; set; }
        [Required]
        public System.DateTime StartTime { get; set; }
        [Required]
        public System.DateTime EndTime { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
