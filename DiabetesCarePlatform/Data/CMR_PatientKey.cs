namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CMR_PatientKey
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        [StringLength(30)]
        public string MedicalRecordNumber { get; set; }

        public int ChronicTypeID { get; set; }

        public int ParentUnitID { get; set; }

        public int? UnitID { get; set; }

        public int? AppUserID { get; set; }

        public bool Enable { get; set; }

        public int CaseStatus { get; set; }

        public int CreateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreateDate { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
