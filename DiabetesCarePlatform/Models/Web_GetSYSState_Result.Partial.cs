namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSState_ResultMetaData))]
    public partial class Web_GetSYSState_Result
    {
    }
    
    public partial class Web_GetSYSState_ResultMetaData
    {
        [Required]
        public int StateID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string StateName { get; set; }
        [Required]
        public int CountryID { get; set; }
    }
}
