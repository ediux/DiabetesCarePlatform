namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PME_TagName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExaminationID { get; set; }

        public int ExaminationTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string TagName { get; set; }

        [Required]
        [StringLength(30)]
        public string UnitsMeasurement { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LasUpdate { get; set; }
    }
}
