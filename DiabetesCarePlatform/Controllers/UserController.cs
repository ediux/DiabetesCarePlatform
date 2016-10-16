using DiabetesCarePlatform.Models;
using DiabetesCarePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiabetesCarePlatform.Controllers
{
    public class UserController : Controller
    {
        UserRepository SP = new UserRepository();
        DBRepository DBSP = new DBRepository();
        #region User
        [Authorize]
        public ActionResult Index()
        {
            UserManagementPage model = new UserManagementPage();
            model.UserList = SP.Web_GetSYSUserList();
            foreach (var item in model.UserList)
            {
                item.UnitList = SP.Web_GetSYSUserAssignUnit(item.UserID);
            }
            model.UnitList = SP.Web_GetSYSUnit();
            return View(model);
        }
        [Authorize]
        public ActionResult CreateUser()
        {
            UserManagementPage model = new UserManagementPage();
            model.RaceTypeList = DBSP.Web_GetSYSRaceType();
            model.LanguageTypeList = SP.Web_GetSYSLanguageType();
            model.StateList = DBSP.Web_GetSYSState();
            model.UnitList = SP.Web_GetSYSUnit();
            model.SexTypeList = SP.Web_GetSYSSexType();
            model.UnitTree = SetUnitTree(model.UnitList);
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddUser(FormCollection collection)
        {
            try
            {
                SYS_User one = new SYS_User();
                one.Account = collection["Account"];
                one.PassWord = collection["PassWord"];
                one.Name = collection["Name"];
                one.SexID = Convert.ToInt16(collection["SexID"]);
                one.JobTitle = collection["JobTitle"];
                one.IdentityNumber = collection["IdentityNumber"];
                one.Birthday = collection["Birthday"];
                one.RaceTypeID = Convert.ToInt16(collection["RaceTypeID"]);
                one.LanguageTypeID = Convert.ToInt16(collection["LanguageTypeID"]);
                one.CountryID = 1;
                one.StateID = Convert.ToInt16(collection["StateID"]);
                one.CityID = Convert.ToInt16(collection["CityID"]);
                one.DistrictID = Convert.ToInt16(collection["DistrictID"]);
                one.Address = collection["Address"];
                one.HomeTelphone = collection["HomeTelphone"];
                one.OfficeTelphone = collection["OfficeTelphone"];
                one.CellPhone = collection["CellPhone"];
                one.eMail = collection["eMail"];
                one.ParentUnitID = Common.UserInfoObj.ParentUnitID;
                var output = SP.SP_UserCreate(one);
                if (output != null && output.ContainsKey("UserID"))
                {
                    int UserID = Convert.ToInt16(output["UserID"]);
                    AssignUserUnit(UserID, collection["UnitTree"]);
                }
               
                TempData["TmpSuccessMsg"] = "新增成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult EditUser(int ID)
        {
            try
            {
                UserManagementPage model = new UserManagementPage();
                model.User = SP.Web_GetSYSUserByID(ID);
                model.User.UnitList = SP.Web_GetSYSUserAssignUnit(ID);
                model.RaceTypeList = DBSP.Web_GetSYSRaceType();
                model.LanguageTypeList = SP.Web_GetSYSLanguageType();
                model.StateList = DBSP.Web_GetSYSState();
                model.UnitList = SetChecked(SP.Web_GetSYSUnit(), model.User.UnitList);
                model.CityList = model.User.StateID > 0 ? DBSP.Web_GetSYSCity(model.User.StateID) : new List<SYS_City>();
                model.DistrictList = model.User.CityID > 0 ? DBSP.Web_GetSYSDistrict(model.User.CityID) : new List<SYS_District>();
                model.SexTypeList = SP.Web_GetSYSSexType();
                model.UnitTree = SetUnitTree(model.UnitList);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateUser(FormCollection collection)
        {
            try
            {
                SYS_User one = new SYS_User();
                one.UserID = Convert.ToInt16(collection["UserID"]);
                one.PassWord = collection["PassWord"];
                one.Name = collection["Name"];
                one.SexID = Convert.ToInt16(collection["SexID"]);
                one.JobTitle = collection["JobTitle"];
                one.IdentityNumber = collection["IdentityNumber"];
                one.Birthday = collection["Birthday"];
                one.RaceTypeID = Convert.ToInt16(collection["RaceTypeID"]);
                one.LanguageTypeID = Convert.ToInt16(collection["LanguageTypeID"]);
                one.StateID = Convert.ToInt16(collection["StateID"]);
                one.CountryID = 1;
                one.CityID = Convert.ToInt16(collection["CityID"]);
                one.DistrictID = Convert.ToInt16(collection["DistrictID"]);
                one.Address = collection["Address"];
                one.HomeTelphone = collection["HomeTelphone"];
                one.OfficeTelphone = collection["OfficeTelphone"];
                one.CellPhone = collection["CellPhone"];
                one.eMail = collection["eMail"];
                SP.SP_UserEdit(one);
                AssignUserUnit(one.UserID, collection["UnitTree"]);
                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public ActionResult SetUserStatus(int UserID, int Status)
        {
            try
            {
                if (Status == -1)
                {
                    SP.SP_UserRemove(UserID);
                    TempData["TmpSuccessMsg"] = "刪除成功";
                }
                else
                {
                    SP.SP_UserEnable(UserID, Status);
                    TempData["TmpSuccessMsg"] = Status == 1 ? "啟用成功" : "停用成功";
                }
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
        private List<SYS_Unit> SetChecked(List<SYS_Unit> list, List<int> UserUnit)
        {
            foreach (var item in list)
            {
                foreach (int u in UserUnit)
                {
                    if (item.UnitID == u)
                    {
                        item.Checked = true;
                        break;
                    }
                }
            }
            return list;
        }
        private List<JsTree> SetUnitTree(List<SYS_Unit> list)
        {
            List<JsTree> tree = new List<JsTree>();
            foreach (var root in list)
            {
                if (root.UnitRankTypeID == 11)
                {
                    JsTree node = new JsTree();
                    node.text = root.UnitName;
                    node.id = root.UnitID.ToString();
                    node.state = new JsTreeState { selected = root.Checked };
                    var leaves = list.Where(t => t.ParentUnitID == root.UnitID).ToList();
                    if (leaves.Count > 0)
                    {
                        node.children = new List<JsTree>();
                        foreach (var leaf in leaves)
                        {
                            JsTree subnode = new JsTree();
                            subnode.text = leaf.UnitName;
                            subnode.id = leaf.UnitID.ToString();
                            subnode.state = new JsTreeState { selected = leaf.Checked };
                            node.children.Add(subnode);
                        }
                    }
                    tree.Add(node);
                }
            }
            return tree;
        }
        private void AssignUserUnit(int UserID, string UnitTree)
        {
            var newUnit = new List<int>();
            if (UnitTree.Length > 0)
            { newUnit = UnitTree.Split(',').Select(Int32.Parse).ToList(); }
            var dbUnit = SP.Web_GetSYSUserAssignUnit(UserID);
            foreach (var dbu in dbUnit)
            {
                bool isKeep = false;
                foreach (var newu in newUnit)
                {
                    if (dbu == newu)
                    {
                        isKeep = true;
                        break;
                    }
                }
                if (!isKeep)
                {
                    SP.SP_UserRemoveUnit(UserID, dbu);
                }
            }

            foreach (var newu in newUnit)
            {
                bool isExists = false;
                foreach (var dbu in dbUnit)
                {
                    if (newu == dbu)
                    {
                        isExists = true;
                        break;
                    }
                }
                if (!isExists)
                {
                    SP.SP_UserAssignUnit(UserID, newu);
                }
            }
        }

        #endregion

        #region Member
        [Authorize]
        public ActionResult Member()
        {
            MemberPage model = new MemberPage();
            model.UserList = SP.Web_GetAppUserList();
            foreach (var item in model.UserList)
            {
                item.UnitList = SP.Web_GetCGCareGroup(item.PatientID);
            }
            model.SexTypeList = SP.Web_GetSYSSexType();
            var unitlist=SP.Web_GetSYSUnit();
            model.UnitTree = SetMemberUnitTree(unitlist);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditMember(FormCollection collection)
        {
            try
            {
                APP_User model = new APP_User();
                model.AppUserID = Convert.ToInt16(collection["AppUserID"]);
                model.Enable = collection["Enable"] == "on";
                model.PaymentType = Convert.ToInt16(collection["PaymentType"]);
                SP.Web_EditAppUser(model);
                var PatientID = Convert.ToInt16(collection["PatientID"]);
                AssignPatientUnit(PatientID, collection["UnitTree"]);
                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("Member");
        }

        private List<JsTree> SetMemberUnitTree(List<SYS_Unit> list)
        {
            List<JsTree> tree = new List<JsTree>();
            foreach (var root in list)
            {
                if (root.UnitRankTypeID == 11)
                {
                    JsTree node = new JsTree();
                    node.text = root.UnitName;
                    node.id = root.UnitID.ToString();
                    node.state = new JsTreeState { disabled = true };
                    var leaves = list.Where(t => t.ParentUnitID == root.UnitID).ToList();
                    if (leaves.Count > 0)
                    {
                        node.children = new List<JsTree>();
                        foreach (var leaf in leaves)
                        {
                            JsTree subnode = new JsTree();
                            subnode.text = leaf.UnitName;
                            subnode.id = leaf.UnitID.ToString();
                            subnode.state = new JsTreeState { selected = false };
                            node.children.Add(subnode);
                        }
                        tree.Add(node);
                    }
                    
                }
            }
            return tree;
        }

        private void AssignPatientUnit(int PatientID, string UnitTree)
        {
            var newUnit = new List<int>();
            if (UnitTree.Length > 0)
            { newUnit = UnitTree.Split(',').Select(Int32.Parse).ToList(); }
            var dbUnit = SP.Web_GetCGCareGroup(PatientID);
            foreach (var dbu in dbUnit)
            {
                bool isKeep = false;
                foreach (var newu in newUnit)
                {
                    if (dbu == newu)
                    {
                        isKeep = true;
                        break;
                    }
                }
                if (!isKeep)
                {
                    SP.Web_RemoveCGCareGroup(PatientID, dbu);
                }
            }

            foreach (var newu in newUnit)
            {
                bool isExists = false;
                foreach (var dbu in dbUnit)
                {
                    if (newu == dbu)
                    {
                        isExists = true;
                        break;
                    }
                }
                if (!isExists)
                {
                    SP.Web_AddCGCareGroup(PatientID, newu);
                }
            }
        } 
        #endregion
    }
}