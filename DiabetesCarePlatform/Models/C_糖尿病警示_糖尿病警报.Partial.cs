namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_糖尿病警示_糖尿病警报MetaData))]
    public partial class C_糖尿病警示_糖尿病警报
    {
    }
    
    public partial class C_糖尿病警示_糖尿病警报MetaData
    {
        [Required]
        public int PatientID { get; set; }
    }
}
