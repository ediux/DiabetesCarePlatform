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
    using System.Collections.Generic;
    
    public partial class CG_Message
    {
        public int SourceType { get; set; }
        public int SourceID { get; set; }
        public int TargetType { get; set; }
        public int TargetID { get; set; }
        public string Message { get; set; }
        public System.DateTime InputTime { get; set; }
        public Nullable<System.DateTime> ProcessTime { get; set; }
        public int SendStatus { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}
