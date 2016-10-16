namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSBloodType_ResultMetaData))]
    public partial class Web_GetSYSBloodType_Result
    {
    }
    
    public partial class Web_GetSYSBloodType_ResultMetaData
    {
        [Required]
        public int BloodTypeID { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required]
        public string BloodTypeName { get; set; }
    }
}
