namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetUserInfo_ResultMetaData))]
    public partial class Web_GetUserInfo_Result
    {
        
    }
    
    public partial class Web_GetUserInfo_ResultMetaData
    {
        [Required]
        public int ID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string Account { get; set; }
        [Required]
        public int ParentUnitID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string UserKey { get; set; }
    }
}
