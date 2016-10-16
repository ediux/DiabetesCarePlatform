namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SP_AddSYS_Holiday_ResultMetaData))]
    public partial class SP_AddSYS_Holiday_Result
    {
    }
    
    public partial class SP_AddSYS_Holiday_ResultMetaData
    {
        [Required]
        public System.DateTime Holiday { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
