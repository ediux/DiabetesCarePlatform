namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CMR_PatientBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientID { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
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

        public int CreateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreateDate { get; set; }

        public int LastUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
