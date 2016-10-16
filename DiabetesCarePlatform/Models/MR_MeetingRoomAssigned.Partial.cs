namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MR_MeetingRoomAssignedMetaData))]
    public partial class MR_MeetingRoomAssigned
    {
    }
    
    public partial class MR_MeetingRoomAssignedMetaData
    {
        [Required]
        public int room_Id { get; set; }
        
        [StringLength(24, ErrorMessage="欄位長度不得大於 24 個字元")]
        public string uuid { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string meet_id { get; set; }
        [Required]
        public int TimeSectionId { get; set; }
        [Required]
        public System.DateTime WorkShiftDate { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
