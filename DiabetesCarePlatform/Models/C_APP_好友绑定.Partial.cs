namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_APP_好友绑定MetaData))]
    public partial class C_APP_好友绑定
    {
    }
    
    public partial class C_APP_好友绑定MetaData
    {
        [Required]
        public int AppUserID { get; set; }
    }
}
