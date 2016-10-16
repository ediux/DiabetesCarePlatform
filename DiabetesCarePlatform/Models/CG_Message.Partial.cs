namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CG_MessageMetaData))]
    public partial class CG_Message
    {
    }
    
    public partial class CG_MessageMetaData
    {
        [Required]
        public int SourceType { get; set; }
        [Required]
        public int SourceID { get; set; }
        [Required]
        public int TargetType { get; set; }
        [Required]
        public int TargetID { get; set; }
        
        [StringLength(500, ErrorMessage="欄位長度不得大於 500 個字元")]
        [Required]
        public string Message { get; set; }
        [Required]
        public System.DateTime InputTime { get; set; }
        public Nullable<System.DateTime> ProcessTime { get; set; }
        [Required]
        public int SendStatus { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
