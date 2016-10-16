namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CG_HealthEducationOrderMetaData))]
    public partial class CG_HealthEducationOrder
    {
    }
    
    public partial class CG_HealthEducationOrderMetaData
    {
        [Required]
        public int NewsID { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        [Required]
        public System.DateTime PublishDate { get; set; }
        [Required]
        public System.DateTime EndDate { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        [Required]
        public System.DateTime CreateDate { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
