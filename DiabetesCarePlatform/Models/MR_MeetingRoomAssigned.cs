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
    
    public partial class MR_MeetingRoomAssigned
    {
        public int room_Id { get; set; }
        public string uuid { get; set; }
        public string meet_id { get; set; }
        public int TimeSectionId { get; set; }
        public System.DateTime WorkShiftDate { get; set; }
        public int UserId { get; set; }
    }
}
