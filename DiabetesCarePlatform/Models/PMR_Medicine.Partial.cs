namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PMR_MedicineMetaData))]
    public partial class PMR_Medicine
    {
    }
    
    public partial class PMR_MedicineMetaData
    {
        [Required]
        public int PatientID { get; set; }
        [Required]
        public System.DateTime InspectionDate { get; set; }
        [Required]
        public int MedicineID { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        [Required]
        public string ResultValue { get; set; }
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
