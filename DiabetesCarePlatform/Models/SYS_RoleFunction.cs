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
    
    public partial class SYS_RoleFunction
    {
        public int RoleID { get; set; }
        public int FunctionID { get; set; }
        public int ControlLevel { get; set; }
        public int CreateUserID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int LastUserID { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public bool CanRead { get; set; }
        public bool CanAdd { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
