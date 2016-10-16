namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CMR_ContactPersonMetaData))]
    public partial class CMR_ContactPerson
    {
    }
    
    public partial class CMR_ContactPersonMetaData
    {
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int RelationshipTypeID { get; set; }
        public Nullable<int> AppUserID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ContactName { get; set; }
        public Nullable<int> SexID { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string HomeTelphone { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string OfficeTelphone { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string CellPhone { get; set; }
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
