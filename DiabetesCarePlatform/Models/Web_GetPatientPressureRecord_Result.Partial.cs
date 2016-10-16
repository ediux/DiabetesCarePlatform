namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetPatientPressureRecord_ResultMetaData))]
    public partial class Web_GetPatientPressureRecord_Result
    {
    }
    
    public partial class Web_GetPatientPressureRecord_ResultMetaData
    {
        [Required]
        public long ID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string Date { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string WeekDay { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        public string Time { get; set; }
        [Required]
        public int Systolic { get; set; }
        [Required]
        public int Diastolic { get; set; }
        [Required]
        public int Heartbeat { get; set; }
        [Required]
        public System.DateTime RecordTime { get; set; }
    }
}
