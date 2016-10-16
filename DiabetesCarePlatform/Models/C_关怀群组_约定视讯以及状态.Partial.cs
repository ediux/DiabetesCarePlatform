namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_关怀群组_约定视讯以及状态MetaData))]
    public partial class C_关怀群组_约定视讯以及状态
    {
    }
    
    public partial class C_关怀群组_约定视讯以及状态MetaData
    {
        [Required]
        public int AppUserID { get; set; }
    }
}
