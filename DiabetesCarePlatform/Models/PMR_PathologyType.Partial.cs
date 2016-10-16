namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PMR_PathologyTypeMetaData))]
    public partial class PMR_PathologyType
    {
    }
    
    public partial class PMR_PathologyTypeMetaData
    {
        [Required]
        public int PathologyTypeID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Description { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
