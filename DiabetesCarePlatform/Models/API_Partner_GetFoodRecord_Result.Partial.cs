namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Partner_GetFoodRecord_ResultMetaData))]
    public partial class API_Partner_GetFoodRecord_Result
    {
    }
    
    public partial class API_Partner_GetFoodRecord_ResultMetaData
    {
        [Required]
        public long 血糖记录代码 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string 量测日期 { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        public string 量测时间 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 量测时段 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 量测餐别 { get; set; }
        [Required]
        public int 食物种类码 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 食物种类 { get; set; }
    }
}
