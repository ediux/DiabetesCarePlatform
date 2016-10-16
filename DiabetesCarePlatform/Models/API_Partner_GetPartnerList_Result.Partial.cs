namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Partner_GetPartnerList_ResultMetaData))]
    public partial class API_Partner_GetPartnerList_Result
    {
    }
    
    public partial class API_Partner_GetPartnerList_ResultMetaData
    {
        [Required]
        public int 伙伴ID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 姓名 { get; set; }
    }
}
