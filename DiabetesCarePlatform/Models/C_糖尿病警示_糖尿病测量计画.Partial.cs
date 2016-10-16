namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_糖尿病警示_糖尿病测量计画MetaData))]
    public partial class C_糖尿病警示_糖尿病测量计画
    {
    }
    
    public partial class C_糖尿病警示_糖尿病测量计画MetaData
    {
        [Required]
        public int CGUnitID { get; set; }
    }
}
