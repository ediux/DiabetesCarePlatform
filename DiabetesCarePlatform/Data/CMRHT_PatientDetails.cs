namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CMRHT_PatientDetails
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientID { get; set; }

        public int? NowCountryID { get; set; }

        public int? NowStateID { get; set; }

        public int? NowCityID { get; set; }

        public int? NowDistrictID { get; set; }

        [StringLength(100)]
        public string NowAddress { get; set; }

        [StringLength(20)]
        public string HomeTelphone { get; set; }

        [StringLength(20)]
        public string OfficeTelphone { get; set; }

        [StringLength(20)]
        public string CellPhone { get; set; }

        [StringLength(50)]
        public string eMail { get; set; }

        public int? LivingStatus { get; set; }

        public int? SmokeTypeID { get; set; }

        public int? DrinkTypeID { get; set; }

        public int? ArecaTypeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastUserID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "smalldatetime")]
        public DateTime LastUpdate { get; set; }
    }
}
