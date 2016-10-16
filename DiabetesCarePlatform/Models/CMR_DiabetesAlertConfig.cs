using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class CMR_DiabetesAlertConfig
    {
        public decimal BeforeMealHigh { get; set; }
        public decimal BeforeMealLow { get; set; }
        public decimal AfterMealHigh { get; set; }
        public decimal AfterMealLow { get; set; }
        public decimal OthersHigh { get; set; }
        public decimal OthersLow { get; set; }
        public int MissingCount { get; set; }
        public int CGUnitID { get; set; }
        public int PatientID { get; set; }
    }
}