namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CMR_ContactPerson
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RelationshipTypeID { get; set; }

        public int? AppUserID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string FirstName { get; set; }

        public int? SexID { get; set; }

        [StringLength(20)]
        public string HomeTelphone { get; set; }

        [StringLength(20)]
        public string OfficeTelphone { get; set; }

        [StringLength(20)]
        public string CellPhone { get; set; }

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
