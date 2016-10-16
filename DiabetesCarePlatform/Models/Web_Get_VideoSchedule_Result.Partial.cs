namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_Get_VideoSchedule_ResultMetaData))]
    public partial class Web_Get_VideoSchedule_Result
    {
    }
    
    public partial class Web_Get_VideoSchedule_ResultMetaData
    {
        public Nullable<int> UserID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string UserLoginKey { get; set; }
        public Nullable<System.DateTime> ShiftDate { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public string start_url { get; set; }
        public string join_url { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string host_id { get; set; }
        
        [StringLength(300, ErrorMessage="欄位長度不得大於 300 個字元")]
        public string topic { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string password { get; set; }
        public Nullable<int> room_Id { get; set; }
        public Nullable<int> CaseAmount { get; set; }
        
        [StringLength(24, ErrorMessage="欄位長度不得大於 24 個字元")]
        public string uuid { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string meet_id { get; set; }
        public Nullable<int> TimeSectionId { get; set; }
    }
}
