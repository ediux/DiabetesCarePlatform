namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetAllDMAndUnassignReport_ResultMetaData))]
    public partial class Web_GetAllDMAndUnassignReport_Result
    {
    }
    
    public partial class Web_GetAllDMAndUnassignReport_ResultMetaData
    {
        [Required]
        public int PatientID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string MedicalNumber { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string PatientName { get; set; }
        public Nullable<int> SexID { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string ChronicName { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string ChronicSubName { get; set; }
        [Required]
        public System.DateTime StartDate { get; set; }
    }
}
