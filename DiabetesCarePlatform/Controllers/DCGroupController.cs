using DiabetesCarePlatform.Models;
using DiabetesCarePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiabetesCarePlatform.Controllers
{
    public class DCGroupController : Controller
    {
        //
        UserRepository UERSP = new UserRepository();
        DCGroupRepository DCSP = new DCGroupRepository();
        DBRepository DBSP = new DBRepository();
        // GET: /DCGroup/
           [Authorize]
        public ActionResult Index(int Tabs = 1)
        { 
            var tabs = new List<string> { "", "" };
            tabs[Tabs - 1] = "active";
            DCGroupIndexViewModel model = new DCGroupIndexViewModel();
            model.ManagerLevelReport = DCSP.Web_GetSYSUnitReportByRankType11();
            model.GroupLevelReport = DCSP.Web_GetSYSUnitReportByRankType21();
            model.Tabs = tabs;

            return View(model);
        }

           [Authorize]
           public JsonResult GetUnitInfo(string ID)
           {
                 List<SYS_Unit_Extend> lUser = new List<SYS_Unit_Extend>();
                if (ID == "0")
               {
                   lUser = DCSP.Web_GetAllUserAndUnassignReport(0);
                   return Json(lUser);
               }
               if(ID == "1")
               {
                   lUser = DCSP.Web_GetAllUserAndUnassignReport(1);
                   return Json(lUser);
               }
             
               int nID = 0;
               int.TryParse(ID, out nID);
              
               if (nID == 0)
               {
                   return Json(lUser);
               }
               lUser = DCSP.Web_GetSYSUnitUserByUnitID(nID);
               return Json(lUser);
           }

           [Authorize]
           public JsonResult GetDMInfo(string ID)
           {
               List<DCGroupDMReportViewModel> lDM = new List<DCGroupDMReportViewModel>();
               if (ID == "0")
               {
                   lDM = DCSP.Web_GetAllDMAndUnassignReport(0);
                   return Json(lDM);
               }
               if(ID == "1")
               {
                   lDM = DCSP.Web_GetAllDMAndUnassignReport(1);
                   return Json(lDM);
               }
               int nID = 0;
               int.TryParse(ID, out nID);
               if (nID == 0)
               {
                   return Json(lDM);
               }
               lDM = DCSP.Web_GetDMReportBySYSUnitID(nID);
               return Json(lDM);
           }
           

        public ActionResult MedicalTeamMember()
        {
            return View();
        }

        public ActionResult MedicalTeamGroup()
        {
            return View();
        }

        public ActionResult MedicalGroup()
        {
            return View();
        }
        [Authorize]
        public ActionResult EditTeamDM( int ID)
        {
            MedicalTeamViewModel model = new MedicalTeamViewModel();
            model.DMList = DCSP.Web_GetDMReportBySYSUnitID(ID);
            var unitlist = UERSP.Web_GetSYSUnit();
            model.Unit = unitlist.Where(x => x.UnitID == ID).FirstOrDefault();
            if (model.Unit == null)
            {
                TempData["TmpErrMsg"] = "此團隊已不存在";
                return RedirectToAction("Index", new { Tabs = 1 });
            }
            List<SYS_Unit> lUnit = unitlist.Where(x => x.UnitRankTypeID == 11).ToList();
            model.UnitList = lUnit;
            model.RaceTypeList = DBSP.Web_GetSYSRaceType();
            model.LanguageTypeList = UERSP.Web_GetSYSLanguageType();
            model.SexTypeList = UERSP.Web_GetSYSSexType();
            return View(model);
        }

         [Authorize]
        public JsonResult GetDMQueryResult(string Name, string MedicalNumber, string SexID, string Birthday, string RaceTypeID, string Status)
        {

            List<CMR_Patient_Extend> lUser = new List<CMR_Patient_Extend>();
            int nSexID=-1;
            int.TryParse(SexID, out nSexID);

          

            int nRaceTypeID = -1;
            int.TryParse(RaceTypeID, out nRaceTypeID);
            DateTime dtBirthday = new DateTime();
            if (Birthday.Trim()=="")
            {
                dtBirthday = DateTime.MinValue;
            }
            else
            {
                DateTime.TryParse(Birthday.Trim(), out dtBirthday);
            }
            
            int nStatus=0;
            if (Status == "false")
            {
                //全選
                nStatus = -1;
            }
           

             if (nStatus == -1 &&(Birthday.Trim() != "" || MedicalNumber.Trim() != "" || Name.Trim() != "" || nSexID != -1 || nRaceTypeID != -1))
            {

                lUser = DCSP.Web_QueryDMCaseInfo(Name.Trim(), MedicalNumber.Trim(), nSexID, dtBirthday, nRaceTypeID, nStatus);
            }
            else if (nStatus == 0)
             {
                 lUser = DCSP.Web_QueryDMCaseInfo(Name.Trim(), MedicalNumber.Trim(), nSexID, dtBirthday, nRaceTypeID, nStatus);
             }

           
            return Json(lUser);
        }

         [Authorize]
        public ActionResult CreateMedicalTeam()
        {
            MedicalTeamViewModel model = new MedicalTeamViewModel();
           var unitlist= UERSP.Web_GetSYSUnit();
           List<SYS_Unit> lUnit = unitlist.Where(x=>x.UnitRankTypeID==11).ToList();
            model.UnitList = lUnit;
            model.RaceTypeList = DBSP.Web_GetSYSRaceType();
            model.LanguageTypeList = UERSP.Web_GetSYSLanguageType();
            model.SexTypeList = UERSP.Web_GetSYSSexType();
            return View(model);
           
        }
        [Authorize]
        public JsonResult GetQueryResult(string Name,string SexID,string LanguageTypeID, string JobTitle, string RaceTypeID,string Status )
        {

            List<SYS_User_Extend> lUser = new List<SYS_User_Extend>();
            int nSexID=-1;
            int.TryParse(SexID, out nSexID);

            int nLanguageTypeID = -1;
            int.TryParse(LanguageTypeID, out nLanguageTypeID);

            int nRaceTypeID = -1;
            int.TryParse(RaceTypeID, out nRaceTypeID);

            int nStatus = 0;//未分派
            if (Status=="false")
            {
                //全選
                nStatus = -1;
            }
           
            if (nStatus == -1 &&( JobTitle.Trim() != "" || Name.Trim() != "" || nSexID != -1 || nLanguageTypeID != -1 || nRaceTypeID != -1))
            {
                lUser = DCSP.Web_QuerySYSUser(Name.Trim(), nSexID, nRaceTypeID, nLanguageTypeID, JobTitle.Trim(), nStatus);
            }
            else if (nStatus==0)
            {
                lUser = DCSP.Web_QuerySYSUser(Name.Trim(), nSexID, nRaceTypeID, nLanguageTypeID, JobTitle.Trim(), nStatus);
            }

           
            return Json(lUser);
        }

        [Authorize]
        public ActionResult EditMedicalTeam( int ID)
        {
            MedicalTeamViewModel model = new MedicalTeamViewModel();
            model.UserList = DCSP.Web_GetSYSUnitUserByUnitID(ID);
            var unitlist = UERSP.Web_GetSYSUnit();
            model.Unit = unitlist.Where(x => x.UnitID == ID).FirstOrDefault();
            if(model.Unit==null)
            {
                TempData["TmpErrMsg"] = "此團隊已不存在";
                return RedirectToAction("Index");
            }
            List<SYS_Unit> lUnit = unitlist.Where(x => x.UnitRankTypeID == 11).ToList();
            model.UnitList = lUnit;
            model.RaceTypeList = DBSP.Web_GetSYSRaceType();
            model.LanguageTypeList = UERSP.Web_GetSYSLanguageType();
            model.SexTypeList = UERSP.Web_GetSYSSexType();
            return View(model);
        }

        public JsonResult UpdateGeoupName(string GroupName, string GroupID,string ParentUnitID)
        {
            if(GroupName.Trim().Length!=0)
            { 
            int nGroupID = 0;
            int.TryParse(GroupID, out nGroupID);
            int nParentUnitID = 0;
            int.TryParse(ParentUnitID, out nParentUnitID);
            SYS_Unit m = new SYS_Unit();
            m.UnitID = nGroupID;
            m.UnitName = GroupName.Trim();
            m.ParentUnitID = nParentUnitID;
            DCSP.Web_UpdateSYSUnit(m);
            }
            else
            {
                return Json(new { Success = "False", responseText = "團隊名稱不可空白" });
            }
            return Json("");
        }

         [Authorize]
        [HttpPost]
        public ActionResult AddGroup(FormCollection collection)
        {
            int nTab = 1;
            try
            {
                
                string sGroupName = collection["Group"].ToString().Trim();
                int nParentUnitID = -1;
                int.TryParse(collection["ParentUnitID"], out nParentUnitID);
                int nType = 11;
                if (nParentUnitID == -1)
                {
                    nType = 11;
                }
                else
                {
                    nType = 21;
                    nTab = 2;
                }

                SYS_Unit u = new SYS_Unit();
                u.UnitName = sGroupName;
                u.UnitRankTypeID = nType;
                u.ParentUnitID = nParentUnitID;



                List<SYS_UserAssignUnit> lUser = new List<SYS_UserAssignUnit>();
                string sUserID = collection["AddUserID"].ToString();

                if (sUserID.Length != 0)
                {
                    string[] sUser = sUserID.TrimEnd(',').Split(',');
                    for (int i = 0; i < sUser.Length; i++)
                    {
                        int nUserID = 0;
                        int.TryParse(sUser[i], out nUserID);
                        SYS_UserAssignUnit ua = new SYS_UserAssignUnit();
                        ua.UserID = nUserID;
                        lUser.Add(ua);

                    }
                }
                DCSP.AddMedicalTeam(u, lUser);
                TempData["TmpSuccessMsg"] = "新增成功";
            }catch(Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("Index", new { Tabs = nTab });
        }

        [HttpPost]
         public ActionResult UpdateGroup(FormCollection collection)
         {
             int nTab = 1;
             try
             {
                 string sIDRank = collection["UIDRank"].ToString();
                 if(sIDRank=="21")
                 {
                     nTab = 2;
                 }
                 List<int> lUser = new List<int>();
                 string sUserID = collection["AddUserID"].ToString();
                 int nUnitID = 0;
                 int.TryParse(collection["UnitID"].ToString(), out nUnitID);
                
                 if (sUserID.Length != 0)
                 {
                     string[] sUser = sUserID.TrimEnd(',').Split(',');
                     for (int i = 0; i < sUser.Length; i++)
                     {
                         int nUserID = 0;
                         int.TryParse(sUser[i], out nUserID);
                         lUser.Add(nUserID);

                     }
                 }

                 DCSP.UpdateUserAssign(nUnitID, lUser);
                 TempData["TmpSuccessMsg"] = "更新成功";
             }
             catch (Exception ex)
             {
                 TempData["TmpErrMsg"] = ex.Message;
             }
             return RedirectToAction("Index", new { Tabs = nTab });
         }

        [HttpPost]
        public ActionResult UpdateDM(FormCollection collection)
        {

            try
            {
                List<Int64> lUser = new List<Int64>();
                string sUserID = collection["AddUserID"].ToString();
                int nUnitID = 0;
                int.TryParse(collection["UnitID"].ToString(), out nUnitID);

                if (sUserID.Length != 0)
                {
                    string[] sUser = sUserID.TrimEnd(',').Split(',');
                    for (int i = 0; i < sUser.Length; i++)
                    {
                        Int64 nUserID = 0;
                        Int64.TryParse(sUser[i], out nUserID);
                        lUser.Add(nUserID);

                    }
                }

                DCSP.UpdateDMAssign(nUnitID, lUser);
                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("Index", new { Tabs = 2 });
        }

        [HttpPost]
        public ActionResult DeleteGroup(int ID)
        {
             try
             {

                 DCSP.Web_DeleteSYSUnit(ID);
                 TempData["TmpSuccessMsg"] = "刪除成功";
             }
             catch (Exception ex)
             {
                 TempData["TmpErrMsg"] = ex.Message;
             }
             return RedirectToAction("Index", new { Tabs = 1 });
        }
       
	}
}