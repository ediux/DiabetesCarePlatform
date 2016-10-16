namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_SearchWordInSP_ResultMetaData))]
    public partial class SYS_SearchWordInSP_Result
    {
    }
    
    public partial class SYS_SearchWordInSP_ResultMetaData
    {
        
        [StringLength(128, ErrorMessage="欄位長度不得大於 128 個字元")]
        [Required]
        public string name { get; set; }
        
        [StringLength(2, ErrorMessage="欄位長度不得大於 2 個字元")]
        public string type { get; set; }
    }
}
