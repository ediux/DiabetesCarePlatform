namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Health_GetWeightRecord_ResultMetaData))]
    public partial class API_Health_GetWeightRecord_Result
    {
    }
    
    public partial class API_Health_GetWeightRecord_ResultMetaData
    {
        [Required]
        public long 体重记录代码 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string 量测日期 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string 日期别 { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        public string 量测时间 { get; set; }
        [Required]
        public decimal 体重 { get; set; }
        [Required]
        public decimal 体脂率 { get; set; }
    }
}
