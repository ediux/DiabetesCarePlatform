namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SP_AddMR_MeetingRooms_ResultMetaData))]
    public partial class SP_AddMR_MeetingRooms_Result
    {
    }
    
    public partial class SP_AddMR_MeetingRooms_ResultMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
    }
}
