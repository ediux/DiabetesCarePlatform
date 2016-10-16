using DiabetesCarePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using DataAccess;
using System.Data;
using System.Reflection;
using DiabetesCarePlatform.Models.Common;
using DiabetesCarePlatform.Helpers.MVCExtras;


namespace DiabetesCarePlatform.Repository
{
    public class DBRepository
    {
        //DB_Dapper Dap = new DB_Dapper();
        BaseRepository BaseDap = new BaseRepository();

        #region Login
        public string SP_UserLogin(int UnitID, string Account, string Password, string IP)
        {
            System.Data.Entity.Core.Objects.ObjectParameter output = new System.Data.Entity.Core.Objects.ObjectParameter("UserKey", "");
            BaseDap.Database.Web_UserLogin(UnitID, Account, Password, IP, output);

            //Dictionary<String, Object> field = new Dictionary<string, object>();
            //field.Add("UnitID", UnitID);
            //field.Add("Account", Account);
            //field.Add("Password", Password);
            //field.Add("IP", IP);
            //Dictionary<String, DbType> Outputparam = new Dictionary<string, DbType>();
            //Outputparam.Add("UserKey", DbType.String);
            //Dictionary<String, Object> output;
            //Dap.NonQuerySPOutput("Web_UserLogin", field, Outputparam,out output);
            return output.Value as string;
        }
        public UserInfo Web_GetUserInfo(string UserKey)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("UserKey", UserKey);
            return Dap.ModelListSP<UserInfo>("Web_GetUserInfo", field).FirstOrDefault();
        }

        public string GetUserKeyById(int UserId)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("userid", UserId);
            return Dap.QueryList<string>("Select dbo.GetUserKeyById(@userid)", field).FirstOrDefault();
        }
        public List<MenuwithJSONData> Web_Role_GetMainMenu()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return BaseDap.ModelListSP<MenuwithJSONData>("Web_Role_GetMainMenu", field);
        }
        #endregion

        #region DMSetUp Wonda

      
        public List<PMRTagNameCBViewModel> Web_GetPMRTagChronicName()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<PMRTagNameCBViewModel>("Web_GetPMRTagChronicName", field);
        }
          

        public List<AddressViewModels> Web_CheckAddressArea(int stateID, int cityID, int districtID)
        {
         
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("StateID", stateID);
            field.Add("CityID", cityID);
            field.Add("DistrictID", districtID);
            return Dap.ModelListSP<AddressViewModels>("Web_CheckAddressArea", field);
       
        }

        public int Web_AddCMRPatient(CMR_PatientKey mCMR_PatientKey, CMR_PatientBase mCMR_PatientBase, CMR_PatientDetails mCMR_PatientDetails, PMR_PathologyHead mPMR_PathologyHead, List<PMR_PathologyBody> lPMR_PathologyBody, List<CMR_ContactPerson> lCMR_ContactPerson, APP_User mAppUser, int action)
        {
            int nAppUserID = 0;
            int nPatientID = 0;
            try
            {
        #region Web_AddCMRPatient
                //[Web_AddCMRPatient]
                Dictionary<String, Object> field1 = new Dictionary<string, object>();
	            field1.Add("MedicalRecordNumber", mCMR_PatientKey.MedicalRecordNumber);
	            field1.Add("ChronicTypeID", mCMR_PatientKey.ChronicTypeID);
	            field1.Add("ParentUnitID", mCMR_PatientKey.ParentUnitID);
	            field1.Add("UnitID", mCMR_PatientKey.UnitID);
	            field1.Add("AppUserID", mCMR_PatientKey.AppUserID);
	            field1.Add("Enable", 1);
                field1.Add("CaseStatus", 1);
                var lPID = BaseDap.ModelListSP<int>("Web_AddCMRPatientKey", field1);
                nPatientID = lPID.FirstOrDefault();
          
                if (nPatientID > 0)
                {
                    mCMR_PatientBase.PatientID = nPatientID;
                    mCMR_PatientDetails.PatientID = nPatientID;
                    mPMR_PathologyHead.PatientID = nPatientID;
                }
                else
                {
                    return -1;
                }
                //[Web_AddCMRPatientBase]
                Dictionary<String, Object> field2 = new Dictionary<string, object>();
                field2.Add("PatientID", mCMR_PatientBase.PatientID);
                field2.Add("PatientName", mCMR_PatientBase.PatientName);
                field2.Add("IdentityNumber", mCMR_PatientBase.IdentityNumber);
                field2.Add("Birthday", mCMR_PatientBase.Birthday);
                field2.Add("SexID", mCMR_PatientBase.SexID);
                field2.Add("RaceTypeID", mCMR_PatientBase.RaceTypeID);
                field2.Add("BloodTypeID", mCMR_PatientBase.BloodTypeID);
                field2.Add("BloodRhTypeID", (int?)null);
                field2.Add("DisabledID", mCMR_PatientBase.DisabledID);
                field2.Add("LanguageTypeID", (int?)null);
                field2.Add("ReligionTypeID", mCMR_PatientBase.ReligionTypeID);
                field2.Add("MaritalStatus", (int?)null);
                field2.Add("RegisterCountryID", mCMR_PatientBase.RegisterCountryID);
                field2.Add("RegisterStateID", mCMR_PatientBase.RegisterStateID);
                field2.Add("RegisterCityID", mCMR_PatientBase.RegisterCityID);
                field2.Add("RegisterDistrictID", mCMR_PatientBase.RegisterDistrictID);
                field2.Add("RegisterAddress", mCMR_PatientBase.RegisterAddress);
                field2.Add("EducationLevelID", mCMR_PatientBase.EducationLevelID);
                field2.Add("BodyHeight", mCMR_PatientBase.BodyHeight);
                field2.Add("BodyWeight", mCMR_PatientBase.BodyWeight);
                BaseDap.NonQuerySP("Web_AddCMRPatientBase", field2);
        #endregion 
        #region Web_AddCMRPatientDetails
                Dictionary<String, Object> field6 = new Dictionary<string, object>();
                field6.Add("PatientID",mCMR_PatientDetails.PatientID);
	            field6.Add("NowCountryID",mCMR_PatientDetails.NowCountryID);
                field6.Add("NowStateID",mCMR_PatientDetails.NowStateID);
                field6.Add("NowCityID",mCMR_PatientDetails.NowCityID);
                field6.Add("NowDistrictID",mCMR_PatientDetails.NowDistrictID);
                field6.Add("NowAddress",mCMR_PatientDetails.NowAddress);
                field6.Add("HomeTelphone",mCMR_PatientDetails.HomeTelphone);
                field6.Add("OfficeTelphone",mCMR_PatientDetails.OfficeTelphone);
                field6.Add("CellPhone",mCMR_PatientDetails.CellPhone);
                field6.Add("eMail", mCMR_PatientDetails.eMail);
                field6.Add("LivingStatus",mCMR_PatientDetails.LivingStatus);
                field6.Add("SmokeTypeID",mCMR_PatientDetails.SmokeTypeID);
                field6.Add("DrinkTypeID", (int?)null);
                field6.Add("ArecaTypeID", (int?)null);
                BaseDap.NonQuerySP("Web_AddCMRPatientDetails", field6);
        #endregion
        #region Web_AddContactPerson
                //[Web_AddContactPerson]
                foreach (CMR_ContactPerson item in lCMR_ContactPerson)
	            {
		             Dictionary<String, Object> field3 = new Dictionary<string, object>();
                    field3.Add("PatientID", nPatientID);
                    field3.Add("RelationshipTypeID", item.RelationshipTypeID);
                    field3.Add("ContactName", item.ContactName);
                    field3.Add("ContactSexID", (int?)null);
                    field3.Add("EmergencyHomeTelphone", item.HomeTelphone);
                    field3.Add("EmergencyOfficeTelphone", item.OfficeTelphone);
                    field3.Add("EmergencyCellPhone", item.CellPhone);
                    BaseDap.NonQuerySP("Web_AddCMRContactPerson", field3);
	            }
          #endregion           
        #region Web_AddPMRPathologyHead
                //Web_AddPMRPathologyHead
                Dictionary<String, Object> field4 = new Dictionary<string, object>();
                field4.Add("PatientID", mPMR_PathologyHead.PatientID);
                field4.Add("ChronicTypeID", mPMR_PathologyHead.ChronicTypeID);
                field4.Add("InspectionDate", mPMR_PathologyHead.InspectionDate);
                field4.Add("DiagnosisDate", mPMR_PathologyHead.DiagnosisDate);
                field4.Add("ChronicSubTypeID", mPMR_PathologyHead.ChronicSubTypeID);
                field4.Add("FamilyHistoryTypeID", (int?)null);
                var lHeadID = BaseDap.ModelListSP<int>("Web_AddPMRPathologyHead", field4);
                int nHeadID = lHeadID.FirstOrDefault();
                if (nHeadID <= 0)
                {
                    return -1;
                }
                
          #endregion
        #region  Web_AddPMRPathologyBody
                 //Web_AddPMRPathologyBody
                foreach (PMR_PathologyBody item in lPMR_PathologyBody)
                {
                    Dictionary<String, Object> field5 = new Dictionary<string, object>();
                    field5.Add("PatientID", nPatientID);
                    field5.Add("HeadID", nHeadID);
                    field5.Add("PathologyID", item.PathologyID);
                    field5.Add("ResultValue", item.ResultValue);
                    field5.Add("InspectionDate", item.InspectionDate);
                    BaseDap.NonQuerySP("Web_AddPMRPathologyBody", field5);
                }
        #endregion            

                if(action ==0)
                {
                    //新增APPUser
                    Dictionary<String, Object> field7 = new Dictionary<string, object>();
                    field7.Add("MedicalRecordNumber", mCMR_PatientKey.MedicalRecordNumber);
                    field7.Add("MailAddress", mAppUser.MailAddress);
                    field7.Add("Password", mAppUser.Password);
                    field7.Add("Name", mAppUser.Name);
                    field7.Add("SexID", mAppUser.SexID);
                    field7.Add("Birthday", mAppUser.Birthday);
                    field7.Add("IdentityNumber", mAppUser.IdentityNumber);
                    field7.Add("ChronicSubTypeID", mAppUser.ChronicSubTypeID);
                    field7.Add("DiagnosisDate", mAppUser.DiagnosisDate);
                    field7.Add("BodyHeight", mAppUser.BodyHeight);
                    field7.Add("BodyWeight", mAppUser.BodyWeight);
                    field7.Add("MobileNumber", mAppUser.MobileNumber);
                    field7.Add("Enable", 1);
                    var lAppUserID = BaseDap.ModelListSP<int>("Web_AddAPPUser", field7);
                    nAppUserID = lAppUserID.FirstOrDefault();

                    //建立驗證碼
                    Dictionary<String, Object> field9 = new Dictionary<string, object>();
                    field9.Add("PatientID", nPatientID);
                    field9.Add("APPUserID", nAppUserID);
                    field9.Add("IdentityNumber", mCMR_PatientBase.IdentityNumber);
                    BaseDap.NonQuerySP("Web_AddAPPVerifyCode", field9); 

                }
                else
                {
                    //更新APPUser
                    Dictionary<String, Object> field8 = new Dictionary<string, object>();
                    field8.Add("AppUserID", mAppUser.AppUserID);
                    field8.Add("Name", mAppUser.Name);
                    field8.Add("SexID", mAppUser.SexID);
                    field8.Add("Birthday", mAppUser.Birthday);
                    field8.Add("IdentityNumber", mAppUser.IdentityNumber);
                    field8.Add("ChronicSubTypeID", mAppUser.ChronicSubTypeID);
                    field8.Add("BodyHeight", mAppUser.BodyHeight);
                    field8.Add("BodyWeight", mAppUser.BodyWeight);
                    field8.Add("MobileNumber", mAppUser.MobileNumber);
                    field8.Add("Enable", 1);
                    field8.Add("LastUserID", 0);
                    BaseDap.NonQuerySP("Web_UpdateAPPUser", field8);
                    nAppUserID = mAppUser.AppUserID;
                }

                //發送Mail 驗證碼
                Dictionary<String, Object> field10 = new Dictionary<string, object>();
                field10.Add("PatientID", nPatientID);
                BaseDap.NonQuerySP("Web_APP_GenerateCode", field10);
        
            }
            catch (Exception ex)
            {
                throw;
            }
            return nPatientID;

        }
       
        
        public int Web_AddAPPUser(APP_User mAppUser)
        {
            int nAppUserID = 0;
            try
            {
                Dictionary<String, Object> field = new Dictionary<string, object>();
                field.Add("MailAddress", mAppUser.MailAddress);
                field.Add("Password", mAppUser.Password);
                field.Add("Name", mAppUser.Name);
                field.Add("SexID", mAppUser.SexID);
                field.Add("Birthday", mAppUser.Birthday);
                field.Add("IdentityNumber", mAppUser.IdentityNumber);
                field.Add("ChronicSubTypeID", mAppUser.ChronicSubTypeID);
                field.Add("DiagnosisDate", mAppUser.DiagnosisDate);
                field.Add("BodyHeight", mAppUser.BodyHeight);
                field.Add("BodyWeight", mAppUser.BodyWeight);
                field.Add("MobileNumber", mAppUser.MobileNumber);
                field.Add("Enable", 1);
                field.Add("LastUserID", 0);
                //var lValue = Dap.ModelListSP<string>("Web_AddAPPUser", field);
                //sValue = lValue.FirstOrDefault();
                var lAppUserID = Dap.ModelListSP<int>("Web_AddCMRPatientKey", field);
                nAppUserID = lAppUserID.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            return nAppUserID;
        }

        public void Web_UpdateAPPUser(APP_User mAppUser)
        {
           
            try
            {
                Dictionary<String, Object> field = new Dictionary<string, object>();
                field.Add("AppUserID", mAppUser.AppUserID);
                field.Add("Name", mAppUser.Name);
                field.Add("SexID", mAppUser.SexID);
                field.Add("Birthday", mAppUser.Birthday);
                field.Add("IdentityNumber", mAppUser.IdentityNumber);
                field.Add("ChronicSubTypeID", mAppUser.ChronicSubTypeID);
                field.Add("BodyHeight", mAppUser.BodyHeight);
                field.Add("BodyWeight", mAppUser.BodyWeight);
                field.Add("MobileNumber", mAppUser.MobileNumber);
                field.Add("Enable", 1);
                field.Add("LastUserID", 0);
                 Dap.NonQuerySP("Web_UpdateAPPUser", field);
               
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public bool Web_GetMedicalRecordNumber(string medicalRecordNumber)
        {
            bool bchk = false;
            try
            { 
                int nPatientID = 0;
                Dictionary<String, Object> field = new Dictionary<string, object>();
                field.Add("MedicalRecordNumber", medicalRecordNumber);
                var lAppUserID = Dap.ModelListSP<int>("Web_GetMedicalRecordNumber", field);
                nPatientID = lAppUserID.FirstOrDefault();
                if(nPatientID>0)
                {
                    bchk = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return bchk;
        }

        public string Web_GetAPPVerifyCode(int patientID)
        {
            string sPw = "";
            try
            {
                Dictionary<String, Object> field = new Dictionary<string, object>();
                field.Add("PatientID", patientID);
                var lPw = BaseDap.ModelListSP<string>("Web_GetAPPVerifyCode", field);
                sPw = lPw.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            return sPw;
        }

        public List<APP_User> Web_GetAPPUserByMail(string mail)
        {
            
                Dictionary<String, Object> field = new Dictionary<string, object>();
                field.Add("MailAddress", mail);
                return Dap.ModelListSP<APP_User>("Web_GetAPPUserByMail", field);
           
        }

        public List<APP_User> Web_GetAPPUserInfo(int appUserID)
        {
                Dictionary<String, Object> field = new Dictionary<string, object>();
                field.Add("AppUserID", appUserID);
                return Dap.ModelListSP<APP_User>("Web_GetAPPUserInfo", field);
            
        }


        #endregion
        
        #region 取得系統參數

        public List<SYS_SexType> Web_GetSYSSexType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return BaseDap.ModelListSP<SYS_SexType>("Web_GetSYSSexType", field);
        }

        public List<SYS_ChronicSubType> Web_GetDiabetesType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_ChronicSubType>("Web_GetDiabetesType", field);
        }

        public List<SYS_BloodType> Web_GetSYSBloodType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_BloodType>("Web_GetSYSBloodType", field);
        }

        public List<SYS_BloodRhType> Web_GetSYSBloodRhType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_BloodRhType>("Web_GetSYSBloodRhType", field);
        }

        public List<SYS_RaceType> Web_GetSYSRaceType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_RaceType>("Web_GetSYSRaceType", field);
        }

        public List<SYS_LanguageType> Web_GetSYSLanguageType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return BaseDap.ModelListSP<SYS_LanguageType>("Web_GetSYSLanguageType", field);
        }

        public List<SYS_ReligionType> Web_GetSYSReligionType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_ReligionType>("Web_GetSYSReligionType", field);
        }

        public List<SYS_MaritalStatus> Web_GetSYSMaritalStatus()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_MaritalStatus>("Web_GetSYSMaritalStatus", field);
        }

        public List<SYS_EducationLevel> Web_GetSYSEducationLevel()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_EducationLevel>("Web_GetSYSEducationLevel", field);
        }

        public List<SYS_ProfessionType> Web_GetSYSProfessionType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_ProfessionType>("Web_GetSYSProfessionType", field);
        }

        public List<SYS_LivingStatus> Web_GetSYSLivingStatus()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_LivingStatus>("Web_GetSYSLivingStatus", field);
        }

        public List<SYS_SmokeType> Web_GetSYSSmokeType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_SmokeType>("Web_GetSYSSmokeType", field);
        }

        public List<SYS_DrinkType> Web_GetSYSDrinkType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_DrinkType>("Web_GetSYSDrinkType", field);
        }

        public List<SYS_ArecaType> Web_GetSYSArecaType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_ArecaType>("Web_GetSYSArecaType", field);
        }

        public List<SYS_RelationshipType> Web_GetSYSRelationshipType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_RelationshipType>("Web_GetSYSRelationshipType", field);
        }

        public List<SYS_State> Web_GetSYSState()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<SYS_State>("Web_GetSYSState", field);
        }

        public List<SYS_City> Web_GetSYSCity(int state)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("StateID", state);
            return Dap.ModelListSP<SYS_City>("Web_GetSYSCity", field);
        }

        public List<SYS_District> Web_GetSYSDistrict(int city)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("CityID", city);
            return Dap.ModelListSP<SYS_District>("Web_GetSYSDistrict", field);
        }


        #endregion
    }
}