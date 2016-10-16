using DataAccess;
using DiabetesCarePlatform.Models.Common;
using DiabetesCarePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DiabetesCarePlatform
{
    public class Common
    {
        DBRepository SP = new DBRepository();
        private static UserInfo _UserProfile
        {
            get { return (UserInfo)HttpContext.Current.Session["UserProfile"]; }
            set { HttpContext.Current.Session["UserProfile"] = value; }
        }

        private static SYSParamaterModel _SYSParamater
        {
            get { return (SYSParamaterModel)HttpContext.Current.Session["SYSParamater"]; }
            set { HttpContext.Current.Session["SYSParamater"] = value; }
        }

        public UserInfo QueryUserInfo(string UserKey)
        {
            try
            {
                return SP.Web_GetUserInfo(UserKey);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static UserInfo UserInfoObj
        {
            get
            {
                if (_UserProfile == null)
                {
                    UserInfo uif = new UserInfo();
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        FormsIdentity Id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket Ticket = Id.Ticket; //取得身份验证票
                        string userkey = Ticket.UserData.Split(',')[0];
                        string IP = Ticket.UserData.Split(',')[1];
                        UserInfo mem = new Common().QueryUserInfo(userkey);
                        uif = new UserInfo { ID = mem.ID, Account = mem.Account, Name = mem.Name, ParentUnitID = mem.ParentUnitID, UserKey = mem.UserKey, IP = IP };
                    }

                    _UserProfile = uif;
                }
                return _UserProfile;
            }
            set
            {
                _UserProfile = value;
            }
        }

        public SYSParamaterModel QueryParamater()
        {
            try
            {
                SYSParamaterModel model = new SYSParamaterModel();
                //model.User = SP.Web_GetSYSUserByID(ID);
                //model.User.UnitList = SP.Web_GetSYSUserAssignUnit(ID);
                model.SexTypeList = SP.Web_GetSYSSexType();
                model.ChronicSubTypeList = SP.Web_GetDiabetesType();
                model.BloodTypeList = SP.Web_GetSYSBloodType();
                model.BloodRhTypeList = SP.Web_GetSYSBloodRhType();
                model.RaceTypeList = SP.Web_GetSYSRaceType();
                model.LanguageTypeList = SP.Web_GetSYSLanguageType();
                model.ReligionTypeList = SP.Web_GetSYSReligionType();
                model.ProfessionTypeList = SP.Web_GetSYSProfessionType();
                model.EducationLevelList = SP.Web_GetSYSEducationLevel();
                model.MaritalStatusList = SP.Web_GetSYSMaritalStatus();
                model.LivingStatusList =SP.Web_GetSYSLivingStatus(); 
                model.SmokeTypeList=SP.Web_GetSYSSmokeType();
                model.DrinkTypeList =SP.Web_GetSYSDrinkType();
                model.ArecaTypeList=SP.Web_GetSYSArecaType();
                //model.StateList = DBSP.Web_GetSYSState();
                //model.UnitList = SetChecked(SP.Web_GetSYSUnit(), model.User.UnitList);
                //model.CityList = model.User.StateID > 0 ? DBSP.Web_GetSYSCity(model.User.StateID) : new List<SYS_City>();
                //model.DistrictList = model.User.CityID > 0 ? DBSP.Web_GetSYSDistrict(model.User.CityID) : new List<SYS_District>();
                //model.UnitTree = SetUnitTree(model.UnitList);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static SYSParamaterModel SYSParamaterObj
        {
            get
            {
                if (_SYSParamater == null)
                {
                    SYSParamaterModel mem = new Common().QueryParamater();
                }
                return _SYSParamater;
            }
            set
            {
                _SYSParamater = value;
            }
        }
    }
}