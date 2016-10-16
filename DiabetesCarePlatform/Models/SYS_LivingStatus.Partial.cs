namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_LivingStatusMetaData))]
    public partial class SYS_LivingStatus
    {
    }
    
    public partial class SYS_LivingStatusMetaData
    {
        [Required]
        public int LivingStatus { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Description { get; set; }
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
