//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiabetesCarePlatform.Models
{
    using System;
    
    public partial class API_Partner_GetSugarRecord_Result
    {
        public long 血糖记录代码 { get; set; }
        public string 量测日期 { get; set; }
        public string 日期别 { get; set; }
        public string 量测时间 { get; set; }
        public string 量测时段 { get; set; }
        public string 量测餐别 { get; set; }
        public decimal 量测数值 { get; set; }
        public string 照片网址 { get; set; }
    }
}
