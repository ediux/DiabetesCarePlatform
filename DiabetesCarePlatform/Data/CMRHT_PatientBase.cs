namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CMRHT_PatientBase
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string IdentityNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public int? SexID { get; set; }

        public int? RaceTypeID { get; set; }

        public int? BloodTypeID { get; set; }

        public int? BloodRhTypeID { get; set; }

        [StringLength(30)]
        public string DisabledID { get; set; }

        public int? LanguageTypeID { get; set; }

        public int? ReligionTypeID { get; set; }

        public int? MaritalStatus { get; set; }

        public int? RegisterCountryID { get; set; }

        public int? RegisterStateID { get; set; }

        public int? RegisterCityID { get; set; }

        public int? RegisterDistrictID { get; set; }

        [StringLength(100)]
        public string RegisterAddress { get; set; }

        public int? EducationLevelID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreateUserID { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "smalldatetime")]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastUserID { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
