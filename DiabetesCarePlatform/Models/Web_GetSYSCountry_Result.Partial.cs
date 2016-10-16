namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSCountry_ResultMetaData))]
    public partial class Web_GetSYSCountry_Result
    {
    }
    
    public partial class Web_GetSYSCountry_ResultMetaData
    {
        [Required]
        public int CountryID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string CountryName { get; set; }
    }
}
