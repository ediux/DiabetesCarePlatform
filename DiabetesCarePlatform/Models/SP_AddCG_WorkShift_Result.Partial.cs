namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SP_AddCG_WorkShift_ResultMetaData))]
    public partial class SP_AddCG_WorkShift_Result
    {
    }
    
    public partial class SP_AddCG_WorkShift_ResultMetaData
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public System.DateTime ShiftDate { get; set; }
        [Required]
        public System.TimeSpan StartTime { get; set; }
        [Required]
        public System.TimeSpan EndTime { get; set; }
        [Required]
        public int DayOfWeek { get; set; }
        [Required]
        public int AppointmentNumber { get; set; }
        [Required]
        public int LimitNumber { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
