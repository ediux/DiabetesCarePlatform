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
    
    public partial class U_MedicineRecord
    {
        public long ID { get; set; }
        public int AppUserID { get; set; }
        public System.DateTime RecordTime { get; set; }
        public int TimingTypeID { get; set; }
        public int MedicineID { get; set; }
        public decimal MedicineValue { get; set; }
    }
}
