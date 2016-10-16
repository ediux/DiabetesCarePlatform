namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_QuerySYSUser_ResultMetaData))]
    public partial class Web_QuerySYSUser_Result
    {
    }
    
    public partial class Web_QuerySYSUser_ResultMetaData
    {
        [Required]
        public int UserID { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string Account { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string JobTitle { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string IdentityNumber { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        public string SexName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string RaceTypeName { get; set; }
        [Required]
        public int GroupCount { get; set; }
        public Nullable<int> SexID { get; set; }
        public Nullable<int> LanguageTypeID { get; set; }
        public Nullable<int> RaceTypeID { get; set; }
    }
}
