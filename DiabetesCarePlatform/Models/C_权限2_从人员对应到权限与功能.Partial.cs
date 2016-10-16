namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_权限2_从人员对应到权限与功能MetaData))]
    public partial class C_权限2_从人员对应到权限与功能
    {
    }
    
    public partial class C_权限2_从人员对应到权限与功能MetaData
    {
        [Required]
        public int RoleID { get; set; }
    }
}
