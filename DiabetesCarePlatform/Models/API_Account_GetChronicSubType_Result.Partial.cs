namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Account_GetChronicSubType_ResultMetaData))]
    public partial class API_Account_GetChronicSubType_Result
    {
    }
    
    public partial class API_Account_GetChronicSubType_ResultMetaData
    {
        [Required]
        public int 代码 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 名称 { get; set; }
    }
}
