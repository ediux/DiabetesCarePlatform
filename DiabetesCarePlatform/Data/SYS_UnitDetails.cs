namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_UnitDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short UnitID { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitFullName { get; set; }

        public int CountryID { get; set; }

        public int StateID { get; set; }

        public int CityID { get; set; }

        public int DistrictID { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string ContactPerson { get; set; }

        [StringLength(20)]
        public string ContactTel { get; set; }

        [StringLength(20)]
        public string ContactFax { get; set; }

        [StringLength(30)]
        public string ContactMail { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LasUpdate { get; set; }
    }
}
