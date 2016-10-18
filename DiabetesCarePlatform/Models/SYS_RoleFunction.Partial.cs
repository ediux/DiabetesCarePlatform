namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_RoleFunctionMetaData))]
    public partial class SYS_RoleFunction
    {
    }
    
    public partial class SYS_RoleFunctionMetaData
    {
        [Required]
        public int RoleID { get; set; }
        [Required]
        public int FunctionID { get; set; }
        [Required]
        public bool CanRead { get; set; }
        [Required]
        public bool CanAdd { get; set; }
        [Required]
        public bool CanUpdate { get; set; }
        [Required]
        public bool CanDelete { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        [Required]
        public System.DateTime CreateDate { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
