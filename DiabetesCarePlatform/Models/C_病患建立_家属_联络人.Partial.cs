namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_病患建立_家属_联络人MetaData))]
    public partial class C_病患建立_家属_联络人
    {
    }
    
    public partial class C_病患建立_家属_联络人MetaData
    {
        [Required]
        public int PatientID { get; set; }
    }
}
