namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CG_WorkShift
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime ShiftDate { get; set; }

        [Key]
        [Column(Order = 2)]
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int DayOfWeek { get; set; }

        public int LimitNumber { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
