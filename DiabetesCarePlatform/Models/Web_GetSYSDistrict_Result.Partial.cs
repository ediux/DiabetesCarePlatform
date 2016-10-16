namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSDistrict_ResultMetaData))]
    public partial class Web_GetSYSDistrict_Result
    {
    }
    
    public partial class Web_GetSYSDistrict_ResultMetaData
    {
        [Required]
        public int DistrictID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string DistrictName { get; set; }
        [Required]
        public int CityID { get; set; }
        [Required]
        public int StateID { get; set; }
        [Required]
        public int CountryID { get; set; }
    }
}
