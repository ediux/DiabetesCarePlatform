namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYSHT_User
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnitID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string Account { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte[] Password { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppUserID { get; set; }

        [StringLength(30)]
        public string IdentityNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public int? SexID { get; set; }

        public int? RaceTypeID { get; set; }

        public int? LanguageTypeID { get; set; }

        public int? CountryID { get; set; }

        public int? StateID { get; set; }

        public int? CityID { get; set; }

        public int? DistrictID { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(20)]
        public string HomeTelphone { get; set; }

        [StringLength(20)]
        public string OfficeTelphone { get; set; }

        [StringLength(20)]
        public string CellPhone { get; set; }

        [StringLength(50)]
        public string eMail { get; set; }

        [StringLength(128)]
        public string MobileToken { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool Enable { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "smalldatetime")]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "smalldatetime")]
        public DateTime VerifyDate { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastUserID { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
