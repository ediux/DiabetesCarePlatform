namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_病史资料_门诊用药MetaData))]
    public partial class C_病史资料_门诊用药
    {
    }
    
    public partial class C_病史资料_门诊用药MetaData
    {
        [Required]
        public int PatientID { get; set; }
    }
}
