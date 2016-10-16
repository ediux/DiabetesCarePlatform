namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSEducationLevel_ResultMetaData))]
    public partial class Web_GetSYSEducationLevel_Result
    {
    }
    
    public partial class Web_GetSYSEducationLevel_ResultMetaData
    {
        [Required]
        public int EducationLevelID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Description { get; set; }
    }
}
