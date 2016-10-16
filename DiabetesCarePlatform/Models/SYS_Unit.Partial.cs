namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_UnitMetaData))]
    public partial class SYS_Unit
    {
    }
    
    public partial class SYS_UnitMetaData
    {
        [Required]
        public int UnitID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string UnitName { get; set; }
        public Nullable<int> ParentUnitID { get; set; }
        [Required]
        public int UnitRankTypeID { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
