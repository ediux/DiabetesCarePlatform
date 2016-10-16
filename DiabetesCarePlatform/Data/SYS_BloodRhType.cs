namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_BloodRhType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BloodRhTypeID { get; set; }

        [Required]
        [StringLength(10)]
        public string BloodRhTypeName { get; set; }

        public int OrderNumber { get; set; }

        public bool Enable { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LasUpdate { get; set; }
    }
}
