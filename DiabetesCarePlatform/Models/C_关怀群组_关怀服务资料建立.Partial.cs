namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_关怀群组_关怀服务资料建立MetaData))]
    public partial class C_关怀群组_关怀服务资料建立
    {
    }
    
    public partial class C_关怀群组_关怀服务资料建立MetaData
    {
        [Required]
        public int PatientID { get; set; }
    }
}
