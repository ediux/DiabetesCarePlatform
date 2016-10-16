namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CGHT_ServiceRecord
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

        [Key]
        [Column(Order = 3)]
        public TimeSpan EndTime { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceRecordTypeID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceTypeID { get; set; }

        [StringLength(50)]
        public string ServiceTypeNote { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceResultID { get; set; }

        [StringLength(50)]
        public string ServiceResultNote { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        [StringLength(200)]
        public string ResponseMessage { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreateUserID { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "smalldatetime")]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastUserID { get; set; }

        [Key]
        [Column(Order = 10, TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
