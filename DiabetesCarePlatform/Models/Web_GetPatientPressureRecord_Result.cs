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
    
    public partial class Web_GetPatientPressureRecord_Result
    {
        public long ID { get; set; }
        public string Date { get; set; }
        public string WeekDay { get; set; }
        public string Time { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public int Heartbeat { get; set; }
    }
}
