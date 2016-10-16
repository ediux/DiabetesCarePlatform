using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class PMR_PathologyBody
    {

        public int PatientID { get; set; }

        public DateTime InspectionDate { get; set; }

        public int PathologyID { get; set; }

        [StringLength(200)]
        public string ResultValue { get; set; }

        public int CreateUserID { get; set; }

        public DateTime CreateDate { get; set; }

        public int LastUserID { get; set; }

        public DateTime LasUpdate { get; set; }
    }
}