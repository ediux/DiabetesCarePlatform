namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(APPHT_PartnerMetaData))]
    public partial class APPHT_Partner
    {
    }
    
    public partial class APPHT_PartnerMetaData
    {
        [Required]
        public int AppUserID { get; set; }
        [Required]
        public int PartnerID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
