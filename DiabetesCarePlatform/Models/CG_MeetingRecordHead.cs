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
    
    public partial class CG_MeetingRecordHead
    {
        public Nullable<long> ID { get; set; }
        public int AppUserID { get; set; }
        public int PatientID { get; set; }
        public int ChronicTypeID { get; set; }
        public int UnitID { get; set; }
        public int UserID { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public int LastUserID { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}