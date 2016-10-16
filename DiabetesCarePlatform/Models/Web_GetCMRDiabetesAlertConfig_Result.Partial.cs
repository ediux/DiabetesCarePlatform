namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetCMRDiabetesAlertConfig_ResultMetaData))]
    public partial class Web_GetCMRDiabetesAlertConfig_Result
    {
    }
    
    public partial class Web_GetCMRDiabetesAlertConfig_ResultMetaData
    {
        [Required]
        public int MissingCount { get; set; }
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
        public int CGUnitID { get; set; }
        [Required]
        public int PatientID { get; set; }
    }
}
