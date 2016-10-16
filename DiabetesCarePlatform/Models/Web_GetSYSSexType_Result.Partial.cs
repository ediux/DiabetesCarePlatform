namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSSexType_ResultMetaData))]
    public partial class Web_GetSYSSexType_Result
    {
    }
    
    public partial class Web_GetSYSSexType_ResultMetaData
    {
        [Required]
        public int SexID { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        [Required]
        public string SexName { get; set; }
    }
}
