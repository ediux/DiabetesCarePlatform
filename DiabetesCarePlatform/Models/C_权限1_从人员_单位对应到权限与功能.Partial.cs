namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_权限1_从人员_单位对应到权限与功能MetaData))]
    public partial class C_权限1_从人员_单位对应到权限与功能
    {
    }
    
    public partial class C_权限1_从人员_单位对应到权限与功能MetaData
    {
        [Required]
        public int RoleID { get; set; }
    }
}
