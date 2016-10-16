using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class CMR_DiabetesPlan
    {
        public int MealTypeID { get; set; }
        public int TimingTypeID { get; set; }
        public int CGUnitID { get; set; }
        public int PatientID { get; set; }
    }
}