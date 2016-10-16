using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class CMR_ContactPerson
    {

        public int PatientID { get; set; }

        public int RelationshipTypeID { get; set; }

        public int? AppUserID { get; set; }


        public string ContactName { get; set; }


        public int? SexID { get; set; }

        [StringLength(20)]
        public string HomeTelphone { get; set; }

        [StringLength(20)]
        public string OfficeTelphone { get; set; }

        [StringLength(20)]
        public string CellPhone { get; set; }

        public int CreateUserID { get; set; }

        public DateTime CreateDate { get; set; }

        public int LastUserID { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}


