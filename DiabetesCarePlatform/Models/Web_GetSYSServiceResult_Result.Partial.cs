namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSServiceResult_ResultMetaData))]
    public partial class Web_GetSYSServiceResult_Result
    {
    }
    
    public partial class Web_GetSYSServiceResult_ResultMetaData
    {
        [Required]
        public int ServiceResultID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Description { get; set; }
    }
}
