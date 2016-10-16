namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(U_BloodSugarMetaData))]
    public partial class U_BloodSugar
    {
    }
    
    public partial class U_BloodSugarMetaData
    {
        [Required]
        public long ID { get; set; }
        [Required]
        public int AppUserID { get; set; }
        [Required]
        public System.DateTime RecordTime { get; set; }
        [Required]
        public decimal ResultValue { get; set; }
        [Required]
        public int TimingTypeID { get; set; }
        [Required]
        public int MealTypeID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string PictrueUrl { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string Note { get; set; }
        [Required]
        public int UploadType { get; set; }
        [Required]
        public int UploadUserID { get; set; }
        [Required]
        public System.DateTime UploadTime { get; set; }
    }
}
