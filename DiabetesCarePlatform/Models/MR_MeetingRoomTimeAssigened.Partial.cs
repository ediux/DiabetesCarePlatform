namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MR_MeetingRoomTimeAssigenedMetaData))]
    public partial class MR_MeetingRoomTimeAssigened
    {
    }
    
    public partial class MR_MeetingRoomTimeAssigenedMetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TimeSectionId { get; set; }
        [Required]
        public int DayOfWeek { get; set; }
    }
}
