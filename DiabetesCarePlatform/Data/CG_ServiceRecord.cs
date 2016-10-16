namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CG_ServiceRecord
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime ServiceDate { get; set; }

        [Key]
        [Column(Order = 2)]
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int ServiceRecordTypeID { get; set; }

        public int ServiceTypeID { get; set; }

        [StringLength(50)]
        public string ServiceTypeNote { get; set; }

        public int ServiceResultID { get; set; }

        [StringLength(50)]
        public string ServiceResultNote { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        [StringLength(200)]
        public string ResponseMessage { get; set; }

        public int CreateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreateDate { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
