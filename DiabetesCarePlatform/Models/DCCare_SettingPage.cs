using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class DCCare_SettingPage
    {
        public int PatientID { get; set; }
        public CGUnitSetting CGUnitSettings { get; set; }
    }
    public class CGUnitSetting
    {
        public int CGUnitID { get; set; }
        public List<MealTypeTimingType> PlanList { get; set; }
        public CMR_DiabetesAlertConfig Config { get; set; }
    }
}