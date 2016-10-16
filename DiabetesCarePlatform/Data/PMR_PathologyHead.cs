namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PMR_PathologyHead
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime InspectionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime DiagnosisDate { get; set; }

        public int ChronicTypeID { get; set; }

        public int ChronicSubTypeID { get; set; }

        public int FamilyHistoryTypeID { get; set; }

        public int CreateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreateDate { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LasUpdate { get; set; }
    }
}
