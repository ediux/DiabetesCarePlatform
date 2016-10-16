namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetPatientBloodSugar_ResultMetaData))]
    public partial class Web_GetPatientBloodSugar_Result
    {
    }
    
    public partial class Web_GetPatientBloodSugar_ResultMetaData
    {
        [Required]
        public long ID { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string RecordTime { get; set; }
        [Required]
        public decimal ResultValue { get; set; }
        [Required]
        public int TimingTypeID { get; set; }
        [Required]
        public int MealTypeID { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string Note { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string PictrueUrl { get; set; }
    }
}
