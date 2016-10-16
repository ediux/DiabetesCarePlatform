namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_病史资料_病史资料建立MetaData))]
    public partial class C_病史资料_病史资料建立
    {
    }
    
    public partial class C_病史资料_病史资料建立MetaData
    {
        [Required]
        public int PatientID { get; set; }
    }
}
