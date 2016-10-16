namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CMR_DiabetesMessageMetaData))]
    public partial class CMR_DiabetesMessage
    {
    }
    
    public partial class CMR_DiabetesMessageMetaData
    {
        [Required]
        public int CGUnitID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public System.DateTime RecordTime { get; set; }
        [Required]
        public int DiabetesAlertType { get; set; }
        [Required]
        public decimal ResultValue { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
