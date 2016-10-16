namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CMR_DiabetesAlertConfigMetaData))]
    public partial class CMR_DiabetesAlertConfig
    {
    }
    
    public partial class CMR_DiabetesAlertConfigMetaData
    {
        [Required]
        public int CGUnitID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int ParentUnitID { get; set; }
        [Required]
        public decimal BeforeMealHigh { get; set; }
        [Required]
        public decimal BeforeMealLow { get; set; }
        [Required]
        public decimal AfterMealHigh { get; set; }
        [Required]
        public decimal AfterMealLow { get; set; }
        [Required]
        public decimal OthersHigh { get; set; }
        [Required]
        public decimal OthersLow { get; set; }
        [Required]
        public int MissingCount { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
