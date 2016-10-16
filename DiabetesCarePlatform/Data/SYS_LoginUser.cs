namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_LoginUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        public int UnitID { get; set; }

        public Guid LoginKey { get; set; }

        [StringLength(15)]
        public string IP { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
