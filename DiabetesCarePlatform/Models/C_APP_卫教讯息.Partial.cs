namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_APP_卫教讯息MetaData))]
    public partial class C_APP_卫教讯息
    {
    }
    
    public partial class C_APP_卫教讯息MetaData
    {
        [Required]
        public int NewsID { get; set; }
    }
}
