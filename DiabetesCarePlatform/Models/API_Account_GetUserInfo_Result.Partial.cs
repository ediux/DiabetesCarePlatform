namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_Account_GetUserInfo_ResultMetaData))]
    public partial class API_Account_GetUserInfo_Result
    {
    }
    
    public partial class API_Account_GetUserInfo_ResultMetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 电子信箱 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(5, ErrorMessage="欄位長度不得大於 5 個字元")]
        [Required]
        public string 性别 { get; set; }
        public Nullable<int> 性别代码 { get; set; }
        public Nullable<System.DateTime> 生日 { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string 糖尿病类型 { get; set; }
        [Required]
        public int 糖尿病类型代码 { get; set; }
        public Nullable<System.DateTime> 确诊日期 { get; set; }
        public Nullable<decimal> 身高 { get; set; }
        public Nullable<decimal> 体重 { get; set; }
    }
}
