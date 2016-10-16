namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CMR_DiabetesPlanMetaData))]
    public partial class CMR_DiabetesPlan
    {
    }
    
    public partial class CMR_DiabetesPlanMetaData
    {
        [Required]
        public int CGUnitID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int ParentUnitID { get; set; }
        [Required]
        public int MealTypeID { get; set; }
        [Required]
        public int TimingTypeID { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
