namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Query_GetHealthEducationList_ResultMetaData))]
    public partial class API_Query_GetHealthEducationList_Result
    {
    }
    
    public partial class API_Query_GetHealthEducationList_ResultMetaData
    {
        [Required]
        public int 卫教代码 { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        [Required]
        public string 缩图网址 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 标题 { get; set; }
        [Required]
        public string 简述 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string 发布日期 { get; set; }
    }
}
