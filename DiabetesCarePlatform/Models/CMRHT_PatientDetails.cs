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
    
    public partial class CMRHT_PatientDetails
    {
        public int PatientID { get; set; }
        public Nullable<int> NowCountryID { get; set; }
        public Nullable<int> NowStateID { get; set; }
        public Nullable<int> NowCityID { get; set; }
        public Nullable<int> NowDistrictID { get; set; }
        public string NowAddress { get; set; }
        public string HomeTelphone { get; set; }
        public string OfficeTelphone { get; set; }
        public string CellPhone { get; set; }
        public string eMail { get; set; }
        public Nullable<int> LivingStatus { get; set; }
        public Nullable<int> ProfessionID { get; set; }
        public Nullable<int> SmokeTypeID { get; set; }
        public Nullable<int> DrinkTypeID { get; set; }
        public Nullable<int> ArecaTypeID { get; set; }
        public int LastUserID { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}
