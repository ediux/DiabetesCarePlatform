namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APPHT_User
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppUserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Account { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte[] Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool? Sex { get; set; }

        [StringLength(50)]
        public string MailAddress { get; set; }

        [StringLength(50)]
        public string MobileToken { get; set; }

        [StringLength(10)]
        public string MobileNumber { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool NoiceByPush { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool NoiceByMessage { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool NoiceByPhone { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool Enable { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "smalldatetime")]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "smalldatetime")]
        public DateTime VerifyDate { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastUserID { get; set; }

        [Key]
        [Column(Order = 10, TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
