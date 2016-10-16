namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSBloodRhType_ResultMetaData))]
    public partial class Web_GetSYSBloodRhType_Result
    {
    }
    
    public partial class Web_GetSYSBloodRhType_ResultMetaData
    {
        [Required]
        public int BloodRhTypeID { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required]
        public string BloodRhTypeName { get; set; }
    }
}
