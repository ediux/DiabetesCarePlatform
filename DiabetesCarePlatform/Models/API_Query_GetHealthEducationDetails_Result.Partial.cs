namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Query_GetHealthEducationDetails_ResultMetaData))]
    public partial class API_Query_GetHealthEducationDetails_Result
    {
    }
    
    public partial class API_Query_GetHealthEducationDetails_ResultMetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 标题 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string 发布日期 { get; set; }
        [Required]
        public string 发布日期1 { get; set; }
    }
}
