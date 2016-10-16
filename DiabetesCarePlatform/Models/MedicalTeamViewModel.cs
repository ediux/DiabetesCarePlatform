using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class MedicalTeamViewModel 
    {
        public SYS_Unit Unit { get; set; }
        public List<SYS_Unit_Extend> UserList { get; set; }
        public List<SYS_RaceType> RaceTypeList { get; set; }
        public List<SYS_LanguageType> LanguageTypeList { get; set; }
        public List<SYS_Unit> UnitList { get; set; }
        public List<SYS_SexType> SexTypeList { get; set; }

        public List<DCGroupDMReportViewModel> DMList { get; set; }
    }
}