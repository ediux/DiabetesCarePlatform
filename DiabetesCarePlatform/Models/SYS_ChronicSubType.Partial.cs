namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_ChronicSubTypeMetaData))]
    public partial class SYS_ChronicSubType
    {
    }
    
    public partial class SYS_ChronicSubTypeMetaData
    {
        [Required]
        public int ChronicSubTypeID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string ChronicSubName { get; set; }
        [Required]
        public int ChronicTypeID { get; set; }
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
