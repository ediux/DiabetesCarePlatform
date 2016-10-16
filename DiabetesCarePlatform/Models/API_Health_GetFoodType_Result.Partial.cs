namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Health_GetFoodType_ResultMetaData))]
    public partial class API_Health_GetFoodType_Result
    {
    }
    
    public partial class API_Health_GetFoodType_ResultMetaData
    {
        [Required]
        public int 代码 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 名称 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 计量单位 { get; set; }
    }
}
