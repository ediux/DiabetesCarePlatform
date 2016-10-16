namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetDiabetesType_ResultMetaData))]
    public partial class Web_GetDiabetesType_Result
    {
    }
    
    public partial class Web_GetDiabetesType_ResultMetaData
    {
        [Required]
        public int ChronicSubTypeID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string ChronicSubName { get; set; }
        [Required]
        public int ChronicTypeID { get; set; }
    }
}
