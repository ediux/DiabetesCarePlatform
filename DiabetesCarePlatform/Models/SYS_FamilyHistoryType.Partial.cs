namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_FamilyHistoryTypeMetaData))]
    public partial class SYS_FamilyHistoryType
    {
    }
    
    public partial class SYS_FamilyHistoryTypeMetaData
    {
        [Required]
        public int FamilyHistoryTypeID { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required]
        public string FamilyHistoryTypeName { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
