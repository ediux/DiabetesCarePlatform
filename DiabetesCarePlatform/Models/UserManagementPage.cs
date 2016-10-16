using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class UserManagementPage
    {
        public List<SYS_User_Extend> UserList { get; set; }
        public SYS_User User { get; set; }
        public List<SYS_RaceType> RaceTypeList { get; set; }
        public List<SYS_LanguageType> LanguageTypeList { get; set; }
        public List<SYS_Country> CountryList { get; set; }
        public List<SYS_State> StateList { get; set; }
        public List<SYS_City> CityList { get; set; }
        public List<SYS_District> DistrictList { get; set; }
        public List<SYS_Unit> UnitList { get; set; }
        public List<SYS_SexType> SexTypeList { get; set; }
        public List<JsTree> UnitTree { get; set; }
    }
}