namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYSHT_UnitMetaData))]
    public partial class SYSHT_Unit
    {
    }
    
    public partial class SYSHT_UnitMetaData
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
