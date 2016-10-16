namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSDrinkType_ResultMetaData))]
    public partial class Web_GetSYSDrinkType_Result
    {
    }
    
    public partial class Web_GetSYSDrinkType_ResultMetaData
    {
        [Required]
        public int DrinkTypeID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Description { get; set; }
    }
}
