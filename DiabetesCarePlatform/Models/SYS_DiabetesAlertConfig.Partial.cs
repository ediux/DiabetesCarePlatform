namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_DiabetesAlertConfigMetaData))]
    public partial class SYS_DiabetesAlertConfig
    {
    }
    
    public partial class SYS_DiabetesAlertConfigMetaData
    {
        [Required]
        public int ParentUnitID { get; set; }
        [Required]
        public decimal VeryHigh { get; set; }
        [Required]
        public decimal VeryLow { get; set; }
        [Required]
        public int AlertCount { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
