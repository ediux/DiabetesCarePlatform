namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSServiceType_ResultMetaData))]
    public partial class Web_GetSYSServiceType_Result
    {
    }
    
    public partial class Web_GetSYSServiceType_ResultMetaData
    {
        [Required]
        public int ServiceTypeID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Description { get; set; }
    }
}
