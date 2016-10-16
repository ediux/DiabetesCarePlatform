namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_个案建立_产生病患ID对应基本以及明细资料MetaData))]
    public partial class C_个案建立_产生病患ID对应基本以及明细资料
    {
    }
    
    public partial class C_个案建立_产生病患ID对应基本以及明细资料MetaData
    {
        [Required]
        public int PatientID { get; set; }
    }
}
