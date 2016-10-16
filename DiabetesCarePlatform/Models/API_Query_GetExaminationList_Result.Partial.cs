namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Query_GetExaminationList_ResultMetaData))]
    public partial class API_Query_GetExaminationList_Result
    {
    }
    
    public partial class API_Query_GetExaminationList_ResultMetaData
    {
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string 量测日期 { get; set; }
        [Required]
        public long 报告代码 { get; set; }
    }
}
