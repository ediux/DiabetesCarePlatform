using DiabetesCarePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Repository
{
    public class DCCareRepository : BaseRepository
    {
        #region [Basic Information Detail]

        // Basic Infotmation
        public BasicInformationDetailModel Web_GetCMRBasicInformation(int PatientID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            return Dap.ModelListSP<BasicInformationDetailModel>("Web_GetCMRBasicInformation", field).FirstOrDefault();
        }
        // Contact Person
        public List<ContactPersonModel> Web_GetCMRContactPerson(int PatientID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            return Dap.ModelListSP<ContactPersonModel>("Web_GetCMRContactPerson", field);
        }
        // PMR Pathology
        public List<PMRPathologyModel> Web_GetPMRPathology(int PatientID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            return Dap.ModelListSP<PMRPathologyModel>("Web_GetPMRPathology", field);
        }

        public void Web_EditCMRPatientBase(CMR_PatientBase model)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            if (model.Section == 1)
            {
                field.Add("PatientID", model.PatientID);
                field.Add("PatientName", model.PatientName);
                field.Add("SexID", model.SexID);
                field.Add("Birthday", model.Birthday);
                field.Add("BloodTypeID", model.BloodTypeID);
                field.Add("BloodRhTypeID", model.BloodRhTypeID);
                field.Add("RaceTypeID", model.RaceTypeID);
                field.Add("LanguageTypeID", model.LanguageTypeID);
                field.Add("ReligionTypeID", model.ReligionTypeID);
                field.Add("DisabledID", model.DisabledID);
                field.Add("Section", model.Section);
            }
            else if (model.Section == 2)
            {
                field.Add("PatientID", model.PatientID);
                field.Add("MaritalStatus", model.MaritalStatus);
                field.Add("Section", model.Section);
            }
            BaseDap.NonQuerySP("Web_EditCMRPatientBase ", field);
        }

        public void Web_EditCMRPatientDetails(CMR_PatientDetails model)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", model.PatientID);
            field.Add("ProfessionID", model.ProfessionID);
            field.Add("LivingStatus", model.LivingStatus);
            field.Add("SmokeTypeID", model.SmokeTypeID);
            field.Add("DrinkTypeID", model.DrinkTypeID);
            field.Add("ArecaTypeID", model.ArecaTypeID);
            field.Add("Section", model.Section);
            BaseDap.NonQuerySP("Web_EditCMRPatientDetails ", field);
        }

        public void Web_EditCMRPatientKey(CMR_PatientKey model)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", model.PatientID);
            field.Add("ChronicSubTypeID", model.ChronicSubTypeID);
            field.Add("Section", model.Section);
            BaseDap.NonQuerySP("Web_EditCMRPatientKey ", field);
        }
        #endregion

        #region Pressure
        public List<BloodPressureData> Web_GetPatientPressureRecord(int PatientID, int PressureDay)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PressureDay", PressureDay);
            field.Add("PatientID", PatientID);
            return BaseDap.ModelListSP<BloodPressureData>("Web_GetPatientPressureRecord", field);
        }

        #endregion

        #region MedicineRecord
        public List<MedicalRecordViewModel> Web_GetPatientMedicineRecord(int PatientID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("LoginUserKey", Common.UserInfoObj.UserKey);
            field.Add("PatientID", PatientID);
            return Dap.ModelListSP<MedicalRecordViewModel>("Web_GetPatientMedicineRecord", field);
        }
        #endregion

        #region Index
        public List<DCCareIndexViewModel> Web_GetDMCareMemberByUserID()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();

            return BaseDap.ModelListSP<DCCareIndexViewModel>("Web_GetDMCareMemberByUserID", field);
        }

        public List<DCCareIndexViewModel> Web_GetDMCareMemberByUserID(int PatientID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            return BaseDap.ModelListSP<DCCareIndexViewModel>("Web_GetDMCareMemberByUserID", field);
        }


        public List<DCCareIndexViewModel> Web_QueryDMCareInfoByUserID(string name, string medicalNumber, int sexID, string homeTelphone, string cellPhone)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("Name", name);
            field.Add("MedicalRecordNumber", medicalNumber);
            field.Add("SexId", sexID);
            field.Add("HomeTelphone", homeTelphone);
            field.Add("CellPhone", cellPhone);
            return BaseDap.ModelListSP<DCCareIndexViewModel>("Web_QueryDMCareInfoByUserID", field);
        }

        #endregion

        #region DMIndex


        #endregion

        #region BloodSugar
        public List<U_BloodSugar> Web_GetPatientBloodSugar(int PatientID, int GlucoseDay)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            field.Add("GlucoseDay", GlucoseDay);
            return BaseDap.ModelListSP<U_BloodSugar>("Web_GetPatientBloodSugar", field);
        }
        public List<MealTypeTimingType> Web_GetSYSMealTypeTimingType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return BaseDap.ModelListSP<MealTypeTimingType>("Web_GetSYSMealTypeTimingType", field);
        }
        #endregion

        #region ServiceRecord
        public List<CG_ServiceRecord_Extend> Web_GetCGServiceRecord(int PatientID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            return BaseDap.ModelListSP<CG_ServiceRecord_Extend>("Web_GetCGServiceRecord", field);
        }
        public int Web_AddCGServiceRecord(CG_ServiceRecord model)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", model.PatientID);
            field.Add("ServiceDate", model.ServiceDate);
            field.Add("StartTime", model.StartTime);
            field.Add("EndTime", model.EndTime);
            field.Add("ServiceRecordTypeID", model.ServiceRecordTypeID);
            field.Add("ServiceResultID", model.ServiceResultID);
            field.Add("ServiceResultNote", model.ServiceResultNote);
            field.Add("ServiceTypeID", model.ServiceTypeID);
            field.Add("ServiceTypeNote", model.ServiceTypeNote);
            field.Add("Note", model.Note);
            field.Add("ResponseMessage", model.ResponseMessage);
            return BaseDap.NonQuerySP("Web_AddCGServiceRecord", field);
        }
        public List<SYS_ServiceRecordType> Web_GetSYSServiceRecordType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return BaseDap.ModelListSP<SYS_ServiceRecordType>("Web_GetSYSServiceRecordType", field);
        }
        public List<SYS_ServiceResult> Web_GetSYSServiceResult()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return BaseDap.ModelListSP<SYS_ServiceResult>("Web_GetSYSServiceResult", field);
        }
        public List<SYS_ServiceType> Web_GetSYSServiceType()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return BaseDap.ModelListSP<SYS_ServiceType>("Web_GetSYSServiceType", field);
        }
        #endregion

        #region Setting
        public CMR_DiabetesAlertConfig Web_GetCMRDiabetesAlertConfig(int PatientID,int CGUnitID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            field.Add("CGUnitID", CGUnitID);
            return BaseDap.ModelListSP<CMR_DiabetesAlertConfig>("Web_GetCMRDiabetesAlertConfig", field).FirstOrDefault();
        }
        public List<CMR_DiabetesPlan> Web_GetCMRDiabetesPlan(int PatientID, int CGUnitID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            field.Add("CGUnitID", CGUnitID);
            return BaseDap.ModelListSP<CMR_DiabetesPlan>("Web_GetCMRDiabetesPlan", field);
        }
        public List<int> Web_GetCareGroupXUserUnit(int PatientID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", PatientID);
            return BaseDap.ModelListSP<int>("Web_GetCareGroupXUserUnit", field);
        }
        public int Web_EditCMRDiabetesAlertConfig(CMR_DiabetesAlertConfig model)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", model.PatientID);
            field.Add("CGUnitID", model.CGUnitID);
            field.Add("BeforeMealLow", model.BeforeMealLow);
            field.Add("BeforeMealHigh", model.BeforeMealHigh);
            field.Add("AfterMealLow", model.AfterMealLow);
            field.Add("AfterMealHigh", model.AfterMealHigh);
            field.Add("OthersLow", model.OthersLow);
            field.Add("OthersHigh", model.OthersHigh);
            field.Add("MissingCount", model.MissingCount);
            return BaseDap.NonQuerySP("Web_EditCMRDiabetesAlertConfig", field);
        }
        public int Web_EditCMRDiabetesPlan(CMR_DiabetesPlan model,bool Enable)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("PatientID", model.PatientID);
            field.Add("CGUnitID", model.CGUnitID);
            field.Add("MealTypeID", model.MealTypeID);
            field.Add("TimingTypeID", model.TimingTypeID);
            field.Add("Enable", Enable);
            return BaseDap.NonQuerySP("Web_EditCMRDiabetesPlan", field);
        }
        #endregion
    }
}