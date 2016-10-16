namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYSHT_UserLogin
    {
        public int? UnitID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Account { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string IP { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Result { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime LastUpdate { get; set; }
    }
}
