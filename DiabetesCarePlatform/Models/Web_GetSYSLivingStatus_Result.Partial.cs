namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSLivingStatus_ResultMetaData))]
    public partial class Web_GetSYSLivingStatus_Result
    {
    }
    
    public partial class Web_GetSYSLivingStatus_ResultMetaData
    {
        [Required]
        public int LivingStatus { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Description { get; set; }
    }
}
