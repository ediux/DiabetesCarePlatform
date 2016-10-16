namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SP_GetAllMR_MeetingRoomTimeAssigened_ResultMetaData))]
    public partial class SP_GetAllMR_MeetingRoomTimeAssigened_Result
    {
    }
    
    public partial class SP_GetAllMR_MeetingRoomTimeAssigened_ResultMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Required]
        public int DayOfWeek { get; set; }
        [Required]
        public int TimeSectionId { get; set; }
        [Required]
        public System.TimeSpan StartTime { get; set; }
        [Required]
        public System.TimeSpan EndTime { get; set; }
    }
}
