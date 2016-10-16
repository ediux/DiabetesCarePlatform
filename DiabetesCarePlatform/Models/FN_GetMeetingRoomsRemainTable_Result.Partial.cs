namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(FN_GetMeetingRoomsRemainTable_ResultMetaData))]
    public partial class FN_GetMeetingRoomsRemainTable_Result
    {
    }
    
    public partial class FN_GetMeetingRoomsRemainTable_ResultMetaData
    {
        public Nullable<int> TimeSectionId { get; set; }
        public Nullable<System.DateTime> Day { get; set; }
        public Nullable<int> DayofWeek { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<int> RemainAmount { get; set; }
    }
}
