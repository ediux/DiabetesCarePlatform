namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_个案建立_个案与APP绑定验证码MetaData))]
    public partial class C_个案建立_个案与APP绑定验证码
    {
    }
    
    public partial class C_个案建立_个案与APP绑定验证码MetaData
    {
        [Required]
        public int PatientID { get; set; }
    }
}
