namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APP_User
    {
        [Key]
        public int AppUserID { get; set; }

        [Required]
        [StringLength(20)]
        public string Account { get; set; }

        [Required]
        [MaxLength(128)]
        public byte[] Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? SexID { get; set; }

        [StringLength(50)]
        public string MailAddress { get; set; }

        [StringLength(50)]
        public string MobileToken { get; set; }

        [StringLength(10)]
        public string MobileNumber { get; set; }

        public bool NoiceByPush { get; set; }

        public bool NoiceByMessage { get; set; }

        public bool NoiceByPhone { get; set; }

        public bool Enable { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime VerifyDate { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
