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
    
    public partial class APPHT_User
    {
        public int AppUserID { get; set; }
        public string MailAddress { get; set; }
        public byte[] Password { get; set; }
        public string Name { get; set; }
        public Nullable<int> SexID { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string IdentityNumber { get; set; }
        public int ChronicSubTypeID { get; set; }
        public Nullable<System.DateTime> DiagnosisDate { get; set; }
        public Nullable<decimal> BodyHeight { get; set; }
        public Nullable<decimal> BodyWeight { get; set; }
        public string MobileToken { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<bool> NoiceByPush { get; set; }
        public Nullable<bool> NoiceByMessage { get; set; }
        public Nullable<bool> NoiceByPhone { get; set; }
        public Nullable<short> PaymentType { get; set; }
        public bool Enable { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime VerifyDate { get; set; }
        public int LastUserID { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}
