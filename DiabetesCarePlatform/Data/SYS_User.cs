namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_User
    {
        [Key]
        public int UserID { get; set; }

        public int UnitID { get; set; }

        [Required]
        [StringLength(20)]
        public string Account { get; set; }

        [Required]
        [MaxLength(128)]
        public byte[] Password { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

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
