namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_关怀群组_排班表MetaData))]
    public partial class C_关怀群组_排班表
    {
    }
    
    public partial class C_关怀群组_排班表MetaData
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
        public int LimitNumber { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
