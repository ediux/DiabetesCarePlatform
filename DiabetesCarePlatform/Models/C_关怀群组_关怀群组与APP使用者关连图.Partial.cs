namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_关怀群组_关怀群组与APP使用者关连图MetaData))]
    public partial class C_关怀群组_关怀群组与APP使用者关连图
    {
    }
    
    public partial class C_关怀群组_关怀群组与APP使用者关连图MetaData
    {
        [Required]
        public int PatientID { get; set; }
    }
}
