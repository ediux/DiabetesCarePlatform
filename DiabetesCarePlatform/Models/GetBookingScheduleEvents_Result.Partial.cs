namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(GetBookingScheduleEvents_ResultMetaData))]
    public partial class GetBookingScheduleEvents_Result
    {
    }
    
    public partial class GetBookingScheduleEvents_ResultMetaData
    {
        public Nullable<int> RoomId { get; set; }
        public Nullable<System.DateTime> ShiftDate { get; set; }
        public Nullable<int> TimeSectionId { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<System.TimeSpan> ActualStartTime { get; set; }
        public Nullable<System.TimeSpan> ActualEndTime { get; set; }
        
        [StringLength(300, ErrorMessage="欄位長度不得大於 300 個字元")]
        public string Topic { get; set; }
        public string Start_Url { get; set; }
        public string Join_Url { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string Password { get; set; }
        public Nullable<int> HostUserId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string HostUserKey { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string HostPlatformId { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string MeetingId { get; set; }
        
        [StringLength(24, ErrorMessage="欄位長度不得大於 24 個字元")]
        public string MeetingUUID { get; set; }
        public Nullable<int> AppointmentAmounts { get; set; }
    }
}
