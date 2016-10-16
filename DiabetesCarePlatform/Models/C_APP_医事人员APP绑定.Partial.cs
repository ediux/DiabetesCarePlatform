namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_APP_医事人员APP绑定MetaData))]
    public partial class C_APP_医事人员APP绑定
    {
    }
    
    public partial class C_APP_医事人员APP绑定MetaData
    {
        [Required]
        public int UserID { get; set; }
    }
}
