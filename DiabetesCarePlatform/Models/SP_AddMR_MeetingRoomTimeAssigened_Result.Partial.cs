namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SP_AddMR_MeetingRoomTimeAssigened_ResultMetaData))]
    public partial class SP_AddMR_MeetingRoomTimeAssigened_Result
    {
    }
    
    public partial class SP_AddMR_MeetingRoomTimeAssigened_ResultMetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TimeSectionId { get; set; }
        [Required]
        public int DayOfWeek { get; set; }
    }
}
