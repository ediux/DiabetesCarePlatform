namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetCMRDiabetesPlan_ResultMetaData))]
    public partial class Web_GetCMRDiabetesPlan_Result
    {
    }
    
    public partial class Web_GetCMRDiabetesPlan_ResultMetaData
    {
        [Required]
        public int MealTypeID { get; set; }
        [Required]
        public int TimingTypeID { get; set; }
        [Required]
        public int CGUnitID { get; set; }
        [Required]
        public int PatientID { get; set; }
    }
}
