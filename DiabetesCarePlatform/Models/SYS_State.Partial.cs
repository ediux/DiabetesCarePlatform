namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_StateMetaData))]
    public partial class SYS_State
    {
    }
    
    public partial class SYS_StateMetaData
    {
        [Required]
        public int StateID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string StateName { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        [Required]
        public int CountryID { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
