namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_Role_GetRoleName_ResultMetaData))]
    public partial class Web_Role_GetRoleName_Result
    {
    }
    
    public partial class Web_Role_GetRoleName_ResultMetaData
    {
        [Required]
        public int RoleID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string RoleName { get; set; }
    }
}
