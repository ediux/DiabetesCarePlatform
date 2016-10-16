namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PMEHT_ExaminationBodyMetaData))]
    public partial class PMEHT_ExaminationBody
    {
    }
    
    public partial class PMEHT_ExaminationBodyMetaData
    {
        [Required]
        public long HeadID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public System.DateTime ExaminationDate { get; set; }
        [Required]
        public int ExaminationID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ResultValue { get; set; }
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
