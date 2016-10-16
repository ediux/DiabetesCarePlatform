namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CG_WorkShiftBaseMetaData))]
    public partial class CG_WorkShiftBase
    {
    }
    
    public partial class CG_WorkShiftBaseMetaData
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int DayOfWeek { get; set; }
        [Required]
        public System.TimeSpan StartTime { get; set; }
        [Required]
        public System.TimeSpan EndTime { get; set; }
        [Required]
        public int LimitNumber { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
