namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_UnitRankType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnitRankTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitRankName { get; set; }

        public int UnitRank { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public bool MedicGroup { get; set; }

        public bool CareManager { get; set; }

        public bool Enable { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LasUpdate { get; set; }
    }
}
