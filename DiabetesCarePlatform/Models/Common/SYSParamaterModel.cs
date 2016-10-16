using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.Common
{
    public class SYSParamaterModel
    {
        public List<SYS_SexType> SexTypeList { get; set; }
        public List<SYS_ChronicSubType> ChronicSubTypeList { get; set; }
        public List<SYS_BloodType> BloodTypeList { get; set; }
        public List<SYS_BloodRhType> BloodRhTypeList { get; set; }
        public List<SYS_RaceType> RaceTypeList { get; set; }
        public List<SYS_LanguageType> LanguageTypeList { get; set; }
        public List<SYS_ReligionType> ReligionTypeList { get; set; }
        public List<SYS_ProfessionType> ProfessionTypeList { get; set; }
        public List<SYS_EducationLevel> EducationLevelList { get; set; }
       
        public List<SYS_MaritalStatus> MaritalStatusList { get; set; }
        public List<SYS_LivingStatus> LivingStatusList { get; set; }
        public List<SYS_SmokeType> SmokeTypeList { get; set; }
        public List<SYS_DrinkType> DrinkTypeList { get; set; }
        public List<SYS_ArecaType> ArecaTypeList { get; set; }

        public List<SYS_Country> CountryList { get; set; }
        public List<SYS_State> StateList { get; set; }
        public List<SYS_City> CityList { get; set; }
        public List<SYS_District> DistrictList { get; set; }
        public List<SYS_Unit> UnitList { get; set; }
     
        public List<JsTree> UnitTree { get; set; }
    }
}