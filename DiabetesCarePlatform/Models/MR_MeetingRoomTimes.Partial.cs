namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MR_MeetingRoomTimesMetaData))]
    public partial class MR_MeetingRoomTimes
    {
    }
    
    public partial class MR_MeetingRoomTimesMetaData
    {
        [Required]
        public int TimeSectionId { get; set; }
        [Required]
        public System.TimeSpan StartTime { get; set; }
        [Required]
        public System.TimeSpan EndTime { get; set; }
    }
}
