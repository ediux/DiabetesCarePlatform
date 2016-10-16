namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_医事单位_关连图MetaData))]
    public partial class C_医事单位_关连图
    {
    }
    
    public partial class C_医事单位_关连图MetaData
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
        public System.DateTime LasUpdate { get; set; }
    }
}
