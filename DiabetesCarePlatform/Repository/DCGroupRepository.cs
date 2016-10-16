using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using System.Data;
using System.Reflection;
using DiabetesCarePlatform.Models.Common;
using DiabetesCarePlatform.Models;

namespace DiabetesCarePlatform.Repository
{
    public class DCGroupRepository
    {
        BaseRepository Dap = new BaseRepository();
        DB_Dapper Dap1 = new DB_Dapper();
        UserRepository UserDap = new UserRepository();
        public List<SYS_User_Extend> Web_QuerySYSUser(string name, int sexID , int raceTypeID, int langID, string jobTitle,int assignStatus )
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("Name", name);
            field.Add("SexId", sexID);
            field.Add("LanguageTypeID", langID);
            field.Add("RaceTypeID", raceTypeID);
            field.Add("Status", assignStatus);
            field.Add("JobTitle", jobTitle);
            return Dap1.ModelListSP<SYS_User_Extend>("Web_QuerySYSUser", field);
        }

        public List<CMR_Patient_Extend> Web_QueryDMCaseInfo(string name, string medicalNumber, int sexID, DateTime birthday, int raceTypeID, int assignStatus)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("Name", name);
            field.Add("MedicalRecordNumber", medicalNumber);
            field.Add("SexId", sexID);
            field.Add("Status", assignStatus);
            field.Add("RaceTypeID", raceTypeID);
            field.Add("Birthday", (birthday==DateTime.MinValue)? (DateTime?)null:birthday);
            return Dap1.ModelListSP<CMR_Patient_Extend>("Web_QueryDMCaseInfo", field);
        }

        public int AddMedicalTeam(SYS_Unit s,List<SYS_UserAssignUnit> UserAssign)
        {
            int nGID=0;
            try
            {
                Dictionary<String, Object> field1 = new Dictionary<string, object>();
                field1.Add("@UnitName", s.UnitName);
                field1.Add("@ParentUnitID", s.ParentUnitID);
                field1.Add("@UnitRankTypeID", s.UnitRankTypeID);
                var lPID = Dap.ModelListSP<int>("Web_AddSYSUnit", field1);
                 nGID = lPID.FirstOrDefault();
                if (nGID < 0)
                {
                    return -1;
                }

                foreach (var item in UserAssign)
                {
                    Dictionary<String, Object> field2 = new Dictionary<string, object>();
                    field2.Add("@UnitID", nGID);
                    field2.Add("@UserID", item.UserID);
                    Dap.NonQuerySP("Web_AddSYSUserAssignUnit", field2);
                }
            }catch (Exception ex)
            { throw ex; }
            return nGID;


        }

        public List<SYS_Unit_Extend> Web_GetSYSUnitUserByUnitID(int unit)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("UnitID", unit);
            return Dap.ModelListSP<SYS_Unit_Extend>("Web_GetSYSUnitUserByUnitID", field);
        }

        public void Web_UpdateSYSUnit(SYS_Unit m)
        {
            try
            {
                Dictionary<String, Object> field = new Dictionary<string, object>();
                field.Add("@UnitID", m.UnitID);
                field.Add("@UnitName", m.UnitName);
                field.Add("@ParentUnitID", m.ParentUnitID);
                Dap.NonQuerySP("Web_UpdateSYSUnit", field);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserAssign(int unitID,List<int> userAssign)
        {
            try
            {
                List<SYS_Unit_Extend> oldlist=Web_GetSYSUnitUserByUnitID(unitID);
              
                //停用被取消的功能
                var lDeleteUser = (from g in oldlist
                                     where!(from m in userAssign select m).Contains(g.UserID)
                                     select g.UserID).ToList();

                foreach (int nDUser in lDeleteUser)
                {
                    if (nDUser != 0)
                    {
                        Dictionary<String, Object> field = new Dictionary<string, object>();
                        field.Add("UnitID", unitID);
                        field.Add("UserID", nDUser);
                        field.Add("STATUS", 0);
                        Dap.NonQuerySP("Web_AddOrDeleteUserAssignUnit", field);
                       
                    }
                }

                //新增啟用的功能
                var lAddUser = (from m in userAssign
                                     where !(from g in oldlist  select g.UserID).Contains(m)
                                     select m).ToList();
                foreach (int nAUserID in lAddUser)
                {
                    if (nAUserID != 0)
                    {
                        Dictionary<String, Object> field = new Dictionary<string, object>();
                        field.Add("UnitID", unitID);
                        field.Add("UserID", nAUserID);
                        field.Add("STATUS", 1);
                        Dap.NonQuerySP("Web_AddOrDeleteUserAssignUnit", field);
                    }
                }
            }catch(Exception ex)
            {
                throw;
            }
        }

        public void UpdateDMAssign(int unitID, List<Int64> dmAssign)
        {
            try
            {
                List<DCGroupDMReportViewModel> oldlist = Web_GetDMReportBySYSUnitID(unitID);

                //停用被取消的功能
                var lDeleteUser = (from g in oldlist
                                   where !(from m in dmAssign select m).Contains(g.PatientID)
                                   select g.PatientID).ToList();

                foreach (int nDDMID in lDeleteUser)
                {
                    if (nDDMID != 0)
                    {
                        UserDap.Web_RemoveCGCareGroup(nDDMID, unitID);
                    }
                }

                //新增啟用的功能
                var lAddUser = (from m in dmAssign
                                where !(from g in oldlist select g.PatientID).Contains(m)
                                select m).ToList();
                foreach (int nADMID in lAddUser)
                {
                    if (nADMID != 0)
                    {
                        UserDap.Web_AddCGCareGroup(nADMID, unitID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Web_DeleteSYSUnit(int unitID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("UnitID", unitID);
            Dap.NonQuerySP("Web_DeleteSYSUnitAndUser", field);
        }

        public List<DCGroupReportViewModel> Web_GetSYSUnitReportByRankType11()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<DCGroupReportViewModel>("Web_GetSYSUnitReportByRankType11", field);
        }

        public List<DCGroupReportViewModel>  Web_GetSYSUnitReportByRankType21()
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            return Dap.ModelListSP<DCGroupReportViewModel>("Web_GetSYSUnitReportByRankType21", field);
        }

        public List<DCGroupDMReportViewModel> Web_GetDMReportBySYSUnitID(int unitID)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("CGUnitID", unitID);
            return Dap.ModelListSP<DCGroupDMReportViewModel>("Web_GetDMReportBySYSUnitID", field);
        }

        public List<DCGroupDMReportViewModel> Web_GetAllDMAndUnassignReport(int status)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("Status", status);
            return Dap.ModelListSP<DCGroupDMReportViewModel>("Web_GetAllDMAndUnassignReport", field);
        }

        public List<SYS_Unit_Extend> Web_GetAllUserAndUnassignReport(int status)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("Status", status);
            return Dap.ModelListSP<SYS_Unit_Extend>("Web_GetAllUserAndUnassignReport", field);
        }
    }
}