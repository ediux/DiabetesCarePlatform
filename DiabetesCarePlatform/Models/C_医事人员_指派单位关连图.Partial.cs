namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_医事人员_指派单位关连图MetaData))]
    public partial class C_医事人员_指派单位关连图
    {
    }
    
    public partial class C_医事人员_指派单位关连图MetaData
    {
        [Required]
        public int UnitID { get; set; }
    }
}
