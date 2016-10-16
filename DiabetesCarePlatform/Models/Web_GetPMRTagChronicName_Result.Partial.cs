namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetPMRTagChronicName_ResultMetaData))]
    public partial class Web_GetPMRTagChronicName_Result
    {
    }
    
    public partial class Web_GetPMRTagChronicName_ResultMetaData
    {
        [Required]
        public int PathologyID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Description { get; set; }
    }
}
