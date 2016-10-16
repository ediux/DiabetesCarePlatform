using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class CMR_PatientDetails
    {
        [Key]
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

        public int? ProfessionID { get; set; }

        public int? SmokeTypeID { get; set; }

        public int? DrinkTypeID { get; set; }

        public int? ArecaTypeID { get; set; }

        public int LastUserID { get; set; }

        public DateTime LastUpdate { get; set; }

        // For個人基本資料修改
        public int Section { get; set; }
    }
}