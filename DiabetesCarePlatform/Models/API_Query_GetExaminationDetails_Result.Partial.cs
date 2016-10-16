namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Query_GetExaminationDetails_ResultMetaData))]
    public partial class API_Query_GetExaminationDetails_Result
    {
    }
    
    public partial class API_Query_GetExaminationDetails_ResultMetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 检验项目 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 目标值 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 检验报告 { get; set; }
    }
}
