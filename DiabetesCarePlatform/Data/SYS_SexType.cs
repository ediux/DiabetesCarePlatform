namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_SexType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SexID { get; set; }

        [Required]
        [StringLength(5)]
        public string SexName { get; set; }

        [Required]
        [StringLength(5)]
        public string Appellation { get; set; }

        public int OrderNumber { get; set; }

        public bool Enable { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LasUpdate { get; set; }
    }
}
