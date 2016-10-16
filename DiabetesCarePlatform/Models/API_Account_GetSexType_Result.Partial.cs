namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Account_GetSexType_ResultMetaData))]
    public partial class API_Account_GetSexType_Result
    {
    }
    
    public partial class API_Account_GetSexType_ResultMetaData
    {
        [Required]
        public int 代码 { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        [Required]
        public string 名称 { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        [Required]
        public string 称谓 { get; set; }
    }
}
