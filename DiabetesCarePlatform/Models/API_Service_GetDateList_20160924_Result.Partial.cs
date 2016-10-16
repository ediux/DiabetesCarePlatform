namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Service_GetDateList_20160924_ResultMetaData))]
    public partial class API_Service_GetDateList_20160924_Result
    {
    }
    
    public partial class API_Service_GetDateList_20160924_ResultMetaData
    {
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string 可预约日期 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 个管师姓名 { get; set; }
    }
}
