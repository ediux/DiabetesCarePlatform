namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DistrictID { get; set; }

        [Required]
        [StringLength(30)]
        public string DistrictName { get; set; }

        public int CityID { get; set; }

        public int OrderNumber { get; set; }

        public int StateID { get; set; }

        public int CountryID { get; set; }

        public bool Enable { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LasUpdate { get; set; }
    }
}
