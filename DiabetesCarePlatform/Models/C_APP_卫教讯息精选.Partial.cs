namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_APP_卫教讯息精选MetaData))]
    public partial class C_APP_卫教讯息精选
    {
    }
    
    public partial class C_APP_卫教讯息精选MetaData
    {
        [Required]
        public int NewsID { get; set; }
    }
}
