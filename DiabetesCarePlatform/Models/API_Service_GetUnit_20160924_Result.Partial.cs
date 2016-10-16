namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Service_GetUnit_20160924_ResultMetaData))]
    public partial class API_Service_GetUnit_20160924_Result
    {
    }
    
    public partial class API_Service_GetUnit_20160924_ResultMetaData
    {
        [Required]
        public int 医疗团队代码 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 医疗团队名称 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 最近预约日期 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 最近预约时间 { get; set; }
    }
}
