namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[医事人员]指派单位关连图")]
    public partial class C_医事人员_指派单位关连图
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnitID { get; set; }
    }
}
