namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_ChronicType
    {
        [Key]
        public int ChronicTypeID { get; set; }

        [Required]
        [StringLength(30)]
        public string ChronicName { get; set; }

        public int OrderNumber { get; set; }

        public bool Enable { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LasUpdate { get; set; }
    }
}
