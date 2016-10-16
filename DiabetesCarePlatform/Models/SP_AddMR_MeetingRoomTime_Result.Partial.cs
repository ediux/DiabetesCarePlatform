namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SP_AddMR_MeetingRoomTime_ResultMetaData))]
    public partial class SP_AddMR_MeetingRoomTime_Result
    {
    }
    
    public partial class SP_AddMR_MeetingRoomTime_ResultMetaData
    {
        [Required]
        public int TimeSectionId { get; set; }
        [Required]
        public System.TimeSpan StartTime { get; set; }
        [Required]
        public System.TimeSpan EndTime { get; set; }
    }
}
