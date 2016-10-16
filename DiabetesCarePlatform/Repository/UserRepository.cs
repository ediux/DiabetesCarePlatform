using DataAccess;
using DiabetesCarePlatform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Repository
{
    public class UserRepository
    {
        BaseRepository Dap = new BaseRepository();
        #region User
        public List<SYS_User_Extend> Web_GetSYSUserList()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_User_Extend>("Web_GetSYSUserList", field);
        }
        public Dictionary<String, Object> SP_UserCreate(SYS_User model)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("ParentUnitID", model.ParentUnitID);
            field.Add("Account", model.Account);
            field.Add("PassWord", model.PassWord);
            field.Add("Name", model.Name);
            field.Add("SexID", model.SexID);
            field.Add("JobTitle", model.JobTitle);
            field.Add("IdentityNumber", model.IdentityNumber);
            field.Add("Birthday", model.Birthday);
            field.Add("RaceTypeID", model.RaceTypeID);
            field.Add("LanguageTypeID", model.LanguageTypeID);
            field.Add("StateID", model.StateID);
            field.Add("CityID", model.CityID);
            field.Add("DistrictID", model.DistrictID);
            field.Add("Address", model.Address);
            field.Add("HomeTelphone", model.HomeTelphone);
            field.Add("OfficeTelphone", model.OfficeTelphone);
            field.Add("CellPhone", model.CellPhone);
            field.Add("eMail", model.eMail);
            field.Add("CountryID", model.CountryID);
            field.Add("MobileToken", "");
            Dictionary<String, DbType> output = new Dictionary<string, DbType>();
            output.Add("UserID", DbType.Decimal);
            return Dap.NonQuerySPOutput("SP_UserCreate", field, output);
        }
        public SYS_User Web_GetSYSUserByID(int UserID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("UserID", UserID);
            return Dap.ModelListSP<SYS_User>("Web_GetSYSUserByID", field).FirstOrDefault();
        }
        public List<int> Web_GetSYSUserAssignUnit(int UserID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("UserID", UserID);
            return Dap.ModelListSP<int>("Web_GetSYSUserAssignUnit", field);
        }
        public void SP_UserEdit(SYS_User model)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("UserID", model.UserID);
            field.Add("PassWord", model.PassWord);
            field.Add("Name", model.Name);
            field.Add("SexID", model.SexID);
            field.Add("JobTitle", model.JobTitle);
            field.Add("IdentityNumber", model.IdentityNumber);
            field.Add("Birthday", model.Birthday);
            field.Add("RaceTypeID", model.RaceTypeID);
            field.Add("LanguageTypeID", model.LanguageTypeID);
            field.Add("StateID", model.StateID);
            field.Add("CityID", model.CityID);
            field.Add("DistrictID", model.DistrictID);
            field.Add("Address", model.Address);
            field.Add("HomeTelphone", model.HomeTelphone);
            field.Add("OfficeTelphone", model.OfficeTelphone);
            field.Add("CellPhone", model.CellPhone);
            field.Add("eMail", model.eMail);
            field.Add("CountryID", model.CountryID);
            field.Add("MobileToken", "");
            Dap.NonQuerySP("SP_UserEdit", field);
        }
        public void SP_UserRemove(int UserID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("UserID", UserID);
            Dap.NonQuerySP("SP_UserRemove", field);
        }
        public void SP_UserEnable(int UserID, int Enable)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("UserID", UserID);
            field.Add("Enable", Enable);
            Dap.NonQuerySP("SP_UserEnable", field);
        }
        public void SP_UserAssignUnit(int UserID, int UnitID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("UserID", UserID);
            field.Add("UnitID", UnitID);
            Dap.NonQuerySP("SP_UserAssignUnit", field);
        }
        public void SP_UserRemoveUnit(int UserID, int UnitID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("UserID", UserID);
            field.Add("UnitID", UnitID);
            Dap.NonQuerySP("SP_UserRemoveUnit", field);
        }
        public List<SYS_LanguageType> Web_GetSYSLanguageType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_LanguageType>("Web_GetSYSLanguageType", field);
        }
        public List<SYS_Country> Web_GetSYSCountry()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_Country>("Web_GetSYSCountry", field);
        }
        public List<SYS_Unit> Web_GetSYSUnit()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_Unit>("Web_GetSYSUnit", field);
        }
        public List<SYS_SexType> Web_GetSYSSexType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_SexType>("Web_GetSYSSexType", field);
        }
        #endregion

        #region Member
        public List<APP_User_Extend> Web_GetAppUserList()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<APP_User_Extend>("Web_GetAppUserList", field);
        }
        public List<int> Web_GetCGCareGroup(int PatientID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            return Dap.ModelListSP<int>("Web_GetCGCareGroup", field);
        }
        public void Web_EditAppUser(APP_User model)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("AppUserID", model.AppUserID);
            field.Add("Enable", model.Enable);
            field.Add("PaymentType", model.PaymentType);
            Dap.NonQuerySP("Web_EditAppUser ", field);
        }
        public void Web_AddCGCareGroup(int PatientID, int UnitID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            field.Add("UnitID", UnitID);
            Dap.NonQuerySP("Web_AddCGCareGroup", field);
        }
        public void Web_RemoveCGCareGroup(int PatientID, int UnitID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            field.Add("UnitID", UnitID);
            Dap.NonQuerySP("Web_RemoveCGCareGroup", field);
        }
        #endregion
    }
}