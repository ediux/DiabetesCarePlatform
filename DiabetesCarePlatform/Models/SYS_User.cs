using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class SYS_User
    {
        public int UserID { get; set; }
        public int ParentUnitID { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string IdentityNumber { get; set; }
        public string Birthday { get; set; }
        public int SexID { get; set; }
        public int RaceTypeID { get; set; }
        public int LanguageTypeID { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int DistrictID { get; set; }
        public string Address { get; set; }
        public string HomeTelphone { get; set; }
        public string OfficeTelphone { get; set; }
        public string CellPhone { get; set; }
        public string eMail { get; set; }
        public string MobileToken { get; set; }
        public bool Enable { get; set; }
        public List<int> UnitList { get; set; }
    }
    public class SYS_User_Extend : SYS_User
    {
        public string SexName { get; set; }
        public string RaceTypeName { get; set; }
        public string LanguageTypeName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
    }
}