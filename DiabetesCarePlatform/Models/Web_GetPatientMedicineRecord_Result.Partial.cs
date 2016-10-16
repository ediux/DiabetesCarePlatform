namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetPatientMedicineRecord_ResultMetaData))]
    public partial class Web_GetPatientMedicineRecord_Result
    {
    }
    
    public partial class Web_GetPatientMedicineRecord_ResultMetaData
    {
        [Required]
        public long ID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string Date { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        public string Time { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string TimeType { get; set; }
        [Required]
        public int MedicineID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string MedicineName { get; set; }
        [Required]
        public decimal MedicineValue { get; set; }
    }
}
