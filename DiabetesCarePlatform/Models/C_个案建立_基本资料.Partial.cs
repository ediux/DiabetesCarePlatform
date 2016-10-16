namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_个案建立_基本资料MetaData))]
    public partial class C_个案建立_基本资料
    {
    }
    
    public partial class C_个案建立_基本资料MetaData
    {
        [Required]
        public int PatientID { get; set; }
    }
}
