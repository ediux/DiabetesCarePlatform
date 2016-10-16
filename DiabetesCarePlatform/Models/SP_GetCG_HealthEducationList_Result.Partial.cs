namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SP_GetCG_HealthEducationList_ResultMetaData))]
    public partial class SP_GetCG_HealthEducationList_Result
    {
    }
    
    public partial class SP_GetCG_HealthEducationList_ResultMetaData
    {
        [Required]
        public int NewsID { get; set; }
        [Required]
        public int NewsType { get; set; }
        [Required]
        public System.DateTime PublishDate { get; set; }
        [Required]
        public System.DateTime EndDate { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Title { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        [Required]
        public string SmallPictrueUrl { get; set; }
        [Required]
        public string Subtitle { get; set; }
        [Required]
        public string HtmlBody { get; set; }
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
