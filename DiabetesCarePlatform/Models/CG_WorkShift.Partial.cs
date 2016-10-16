namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CG_WorkShiftMetaData))]
    public partial class CG_WorkShift
    {
    }
    
    public partial class CG_WorkShiftMetaData
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
