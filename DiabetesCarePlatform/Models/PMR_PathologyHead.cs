using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class PMR_PathologyHead
    {

        public int PatientID { get; set; }

        public DateTime InspectionDate { get; set; }

        public DateTime DiagnosisDate { get; set; }

        public int ChronicTypeID { get; set; }

        public int ChronicSubTypeID { get; set; }

        public int? FamilyHistoryTypeID { get; set; }

        public int CreateUserID { get; set; }

        public DateTime CreateDate { get; set; }

        public int LastUserID { get; set; }

        public DateTime LasUpdate { get; set; }
    }
}