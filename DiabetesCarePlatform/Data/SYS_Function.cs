namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_Function
    {
        [Key]
        public int FunctionID { get; set; }

        [Required]
        [StringLength(50)]
        public string FunctionName { get; set; }

        [StringLength(30)]
        public string TagName { get; set; }

        public int? FunctionLevel { get; set; }

        [StringLength(100)]
        public string URL { get; set; }

        public int ParentFunctionID { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
