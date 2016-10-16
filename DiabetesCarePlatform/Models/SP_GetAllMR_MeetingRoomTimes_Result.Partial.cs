namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SP_GetAllMR_MeetingRoomTimes_ResultMetaData))]
    public partial class SP_GetAllMR_MeetingRoomTimes_Result
    {
    }
    
    public partial class SP_GetAllMR_MeetingRoomTimes_ResultMetaData
    {
        [Required]
        public int TimeSectionId { get; set; }
        [Required]
        public System.TimeSpan StartTime { get; set; }
        [Required]
        public System.TimeSpan EndTime { get; set; }
    }
}
