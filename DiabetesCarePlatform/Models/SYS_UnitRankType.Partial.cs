namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYS_UnitRankTypeMetaData))]
    public partial class SYS_UnitRankType
    {
    }
    
    public partial class SYS_UnitRankTypeMetaData
    {
        [Required]
        public int UnitRankTypeID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string UnitRankName { get; set; }
        [Required]
        public int UnitRank { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Description { get; set; }
        [Required]
        public bool MedicGroup { get; set; }
        [Required]
        public bool CareManager { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
