namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(APP_PartnerMetaData))]
    public partial class APP_Partner
    {
    }
    
    public partial class APP_PartnerMetaData
    {
        [Required]
        public int AppUserID { get; set; }
        [Required]
        public int PartnerID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
