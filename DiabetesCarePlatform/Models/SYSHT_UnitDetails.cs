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
    
    public partial class SYSHT_UnitDetails
    {
        public short UnitID { get; set; }
        public string UnitFullName { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int DistrictID { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string ContactPerson { get; set; }
        public string ContactTel { get; set; }
        public string ContactFax { get; set; }
        public string ContactMail { get; set; }
        public string Note { get; set; }
        public int LastUserID { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}
