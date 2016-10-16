namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Health_GetPressureRecord_ResultMetaData))]
    public partial class API_Health_GetPressureRecord_Result
    {
    }
    
    public partial class API_Health_GetPressureRecord_ResultMetaData
    {
        [Required]
        public long 血压记录代码 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string 量测日期 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string 日期别 { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        public string 量测时间 { get; set; }
        [Required]
        public int 收缩压 { get; set; }
        [Required]
        public int 舒张压 { get; set; }
        [Required]
        public int 心跳数 { get; set; }
    }
}
