namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSRaceType_ResultMetaData))]
    public partial class Web_GetSYSRaceType_Result
    {
    }
    
    public partial class Web_GetSYSRaceType_ResultMetaData
    {
        [Required]
        public int RaceTypeID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string RaceTypeName { get; set; }
    }
}
