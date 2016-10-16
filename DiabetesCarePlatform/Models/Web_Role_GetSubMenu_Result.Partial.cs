namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_Role_GetSubMenu_ResultMetaData))]
    public partial class Web_Role_GetSubMenu_Result
    {
    }
    
    public partial class Web_Role_GetSubMenu_ResultMetaData
    {
        [Required]
        public int FunctionID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Title { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string ButtonID { get; set; }
    }
}
