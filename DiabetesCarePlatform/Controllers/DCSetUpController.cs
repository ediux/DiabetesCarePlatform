using DiabetesCarePlatform.Models;
using DiabetesCarePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiabetesCarePlatform.Controllers
{
    public class DCSetUpController : Controller
    {
        DBRepository SP = new DBRepository();
       
        //
        // GET: /DCSetUp/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateDMIndex()
        {
         
            #region 基本資料 
            //血型
            var bloodTypeList = SP.Web_GetSYSBloodType();
            ViewBag.BloodTypeList = new SelectList(
           items: bloodTypeList,
           dataTextField: "BloodTypeName",
           dataValueField: "BloodTypeID"
           );
            //種族
            var raceTypeList = SP.Web_GetSYSRaceType();
            ViewBag.RaceTypeList = new SelectList(
            items: raceTypeList,
            dataTextField: "RaceTypeName",
            dataValueField: "RaceTypeID"
            );
            //居住情形
            var livingStatusList = SP.Web_GetSYSLivingStatus();
            ViewBag.LivingStatusList = new SelectList(
            items: livingStatusList,
            dataTextField: "Description",
            dataValueField: "LivingStatus"
            );
            //戶籍地址
            //現居地址
            #endregion
            #region 建立病人基本資料
            var ChronicList = SP.Web_GetPMRTagChronicName();
            //糖尿病類型
            var diabetesTypeList = SP.Web_GetDiabetesType();
            ViewBag.ChronicSubTypeList = new SelectList(
            items: diabetesTypeList,
            dataTextField: "ChronicSubName",
            dataValueField: "ChronicSubTypeID"
            );
            #endregion

            #region 關係聯絡人
            var relationshipList = SP.Web_GetSYSRelationshipType();
            ViewBag.RelationshipList = new SelectList(
           items: relationshipList,
           dataTextField: "Description",
           dataValueField: "RelationshipTypeID"
           );
            #endregion
            return View(new SetUpCreateAcountModel { BloodTypeList = bloodTypeList, RaceTypeeList = raceTypeList, LivingStatusList = livingStatusList, PMRTagNameCBList = ChronicList, RelationshipList = relationshipList, ChronicSubTypeList = diabetesTypeList });
        }

        public ActionResult CreateQRCode(int patientID)
        {
            if (patientID != 0)
            {
                string sPW = SP.Web_GetAPPVerifyCode(patientID);
                ViewBag.Code = sPW;
            }else
            {
                ViewBag.Code = "Error!";
            }
           // TempData["TmpSuccessMsg"] = "建立成功!";
            return View();
        }

        public JsonResult GetState()
        {
            var StateList = SP.Web_GetSYSState();
            return Json(StateList.ToList(), JsonRequestBehavior.AllowGet);

        }

        
        public JsonResult GetCityByStateId(string stateId)
        {
            int Id = 0;
            if(int.TryParse(stateId, out Id))
            {
            var city = SP.Web_GetSYSCity(Id);
            
           // var district = from a in allStates where a.StateID == Id select a;
            return Json(city);
            }
            return Json("");
        }

        public JsonResult GetDistrictByCityId(string cityId)
        {
           
            int Id = Convert.ToInt32(cityId);
            //List<SYS_District> allStates = SP.Web_GetSYSDistrict(Id);
            //var district = from a in allStates where a.StateID == Id select a;
            var district = SP.Web_GetSYSDistrict(Id);
            return Json(district);
        }

        public bool CheckMedicalRecordNumber(string medicalNumber)
        {
            bool bchk=false;
            if (medicalNumber.Trim().Length > 0)
            {
                bchk = SP.Web_GetMedicalRecordNumber(medicalNumber);
            }
            return bchk;
        }

    

        [HttpPost]
        public ActionResult AddDM1(FormCollection collection, List<PMRTagNameCBViewModel> PMRTagNameCBList)
        {
            int nPatientID = 0;
            try
            {
               
                List<PMR_PathologyBody> lPMR_PathologyBody = new List<PMR_PathologyBody>();
                DateTime dtNow = new DateTime();
                dtNow = DateTime.Now;
                #region 基本資料
                //血型
                var bloodTypeList = SP.Web_GetSYSBloodType();
                //種族
                var raceTypeList = SP.Web_GetSYSRaceType();
                //居住情形
                var livingStatusList = SP.Web_GetSYSLivingStatus();
                //戶籍地址
                int nRegisterStateID = 0;
                int.TryParse(collection["dropdownState"].ToString(), out nRegisterStateID);
                int nRegisterCityID = 0;
                int.TryParse(collection["dropdownCity"].ToString(), out nRegisterCityID);
                int nRegisterDistrictID = 0;
                if (collection["dropdownDistrict"]!=null)
                {
                    int.TryParse(collection["dropdownDistrict"].ToString(), out nRegisterDistrictID);
                }
                if (SP.Web_CheckAddressArea(nRegisterStateID, nRegisterCityID, nRegisterDistrictID).Count == 0)
                {
                    TempData["TmpErrMsg"] = "現居地址錯誤";
                    return RedirectToAction("Index");
                }
                //現居地址
               if(SP.Web_CheckAddressArea(1,1,1).Count==0)
               {
                    TempData["TmpErrMsg"] = "現居地址錯誤";
                    return RedirectToAction("Index");
               }
                #endregion
                #region 建立病人基本資料
              
                //糖尿病類型
                var diabetesTypeList = SP.Web_GetDiabetesType();
                int ndiabetesTypeID = diabetesTypeList.Where(x => x.ChronicSubTypeID == 1).Count();
                if(ndiabetesTypeID==0)
                {
                    TempData["TmpErrMsg"] = "糖尿病類型錯誤";
                    return RedirectToAction("Index");
                }
                //個人病史
                var ChronicList = SP.Web_GetPMRTagChronicName();
                 foreach (var item in PMRTagNameCBList)
                {
                    if (item.Checked == true)
                    {
                        int nChronicList = ChronicList.Where(x => x.PathologyID == item.PathologyID).Count();
                        if (nChronicList == 0)
                        {
                            TempData["TmpErrMsg"] = "個人病史類型錯誤";
                            return RedirectToAction("Index");
                            
                        }
                        else
                        {
                            lPMR_PathologyBody.Add(new PMR_PathologyBody() { PathologyID = item.PathologyID, InspectionDate = dtNow, ResultValue = "Y" });
                        }
                    }
                   
                }
                //過敏史
                 string sAllergyhistory = collection["Allergyhistory"].ToString().Trim();
                 if (sAllergyhistory.Length != 0)
                 {
                     lPMR_PathologyBody.Add(new PMR_PathologyBody() { PathologyID = 17, InspectionDate = dtNow, ResultValue = sAllergyhistory });
                 }
                #endregion

                #region 關係聯絡人
                var relationshipList = SP.Web_GetSYSRelationshipType();
                int nrelationshipList = relationshipList.Where(x => x.RelationshipTypeID == 1).Count();
                if(ndiabetesTypeID==0)
                {
                    TempData["TmpErrMsg"] = "關係聯絡人錯誤";
                    return RedirectToAction("Index");
                }
               
                #endregion

                //APP_User
                APP_User mAPP_User=new APP_User();
                mAPP_User.DiagnosisDate = dtNow;
                
                //step1
                //CMR_PatientKey
                CMR_PatientKey mCMR_PatientKey = new CMR_PatientKey();
                //MedicalRecordNumber
                string sMedicalRecordNumber = collection["MedicalRecordNumber"].ToString().Trim();
                mCMR_PatientKey.MedicalRecordNumber = sMedicalRecordNumber;
                mCMR_PatientKey.ChronicTypeID = 1;
                mCMR_PatientKey.ParentUnitID = 0;
                mCMR_PatientKey.CaseStatus = 0;
                mCMR_PatientKey.Enable = true;

                //CMR_PatientBase
                CMR_PatientBase mCMR_PatientBase = new CMR_PatientBase();
                string sName = collection["PatientName"].ToString().Trim();
                mCMR_PatientBase.PatientName = sName;
                mAPP_User.Name = sName;
                string sIdentityNumber = collection["IdentityNumber"].ToString().Trim();
                mCMR_PatientBase.IdentityNumber = sIdentityNumber;
                mAPP_User.IdentityNumber = sIdentityNumber;
                DateTime dtBirthday = new DateTime();
                DateTime.TryParse(collection["Birthday"].ToString(), out dtBirthday);
                mCMR_PatientBase.Birthday = dtBirthday;
                mAPP_User.Birthday = dtBirthday;
                decimal dBodyWeight = 0;
                decimal.TryParse(collection["Bodyweight"].ToString(), out dBodyWeight);
                mCMR_PatientBase.BodyWeight = dBodyWeight;
                mAPP_User.BodyWeight = dBodyWeight;
                decimal dBodyHeight = 0;
                decimal.TryParse(collection["Height"].ToString(), out dBodyHeight);
                mCMR_PatientBase.BodyHeight = dBodyHeight;
                mAPP_User.BodyHeight = dBodyHeight;
                int nSex = 0;
                int.TryParse(collection["sex"].ToString(), out nSex);
                mCMR_PatientBase.SexID = nSex;
                mAPP_User.SexID = nSex;
                int nRaceTypeID = 0;
                int.TryParse(collection["RaceTypeList"].ToString(), out nRaceTypeID);
                mCMR_PatientBase.RaceTypeID = nRaceTypeID;
                int nBloodTypeID = 0;
                int.TryParse(collection["BloodTypeList"].ToString(), out nBloodTypeID);
                mCMR_PatientBase.BloodTypeID = nBloodTypeID;
                string sDisabledID = collection["DisableNumber"].ToString().Trim();
                mCMR_PatientBase.DisabledID = sDisabledID;
                int nRegisterCountryID = 1;
                mCMR_PatientBase.RegisterCountryID = nRegisterCountryID;
               
                mCMR_PatientBase.RegisterStateID = nRegisterStateID;
               
                mCMR_PatientBase.RegisterCityID = nRegisterCityID;
                
                mCMR_PatientBase.RegisterDistrictID = nRegisterDistrictID;
                string sDomicileaddress = collection["Domicileaddress"].ToString().Trim();
                mCMR_PatientBase.RegisterAddress = sDomicileaddress;

                //CMR_PatientDetails
                CMR_PatientDetails mCMR_PatientDetails = new CMR_PatientDetails();
                mCMR_PatientDetails.eMail=collection["Email"].ToString().Trim();
                mAPP_User.MailAddress = collection["Email"].ToString().Trim();
                mCMR_PatientDetails.NowCountryID = 1;
                int nNowStateID = 0;
                int.TryParse(collection["dropdownLivingState"].ToString(), out nNowStateID);
                mCMR_PatientDetails.NowStateID = nNowStateID;
                int nNowCityID = 0;
                int.TryParse(collection["dropdownLivingCity"].ToString(), out nNowCityID);
                mCMR_PatientDetails.NowCityID = nNowCityID;
                int nNowDistrictID = 0;
                int.TryParse(collection["dropdownLivingDistrict"].ToString(), out nNowDistrictID);
                mCMR_PatientDetails.NowDistrictID = nNowDistrictID;
                mCMR_PatientDetails.NowAddress = collection["NowHomeAddress"].ToString().Trim();
                mCMR_PatientDetails.HomeTelphone = collection["telphone"].ToString().Trim();
                mCMR_PatientDetails.OfficeTelphone = collection["telphone"].ToString().Trim();
                mCMR_PatientDetails.CellPhone = collection["cellphone"].ToString().Trim();
                mAPP_User.MobileNumber = collection["cellphone"].ToString().Trim();
                //default app password cellphone
                mAPP_User.Password = collection["cellphone"].ToString().Trim();
               // mCMR_PatientDetails.eMail = collection["sex"].ToString().Trim();
                int nLivingStatus = 0;
                int.TryParse(collection["LivingStatusList"].ToString(), out nLivingStatus);
                mCMR_PatientDetails.LivingStatus = nLivingStatus;

                List<CMR_ContactPerson> lContactPerson = new List<CMR_ContactPerson>();
                int nCCount = 1;
                int.TryParse(collection["ContactCount"].ToString(), out nCCount);
                if (nCCount>=4)
                {
                   nCCount = 4;
                }
                else if (nCCount ==0)
                {
                    nCCount = 1;
                }
                for (int i = 1; i <= nCCount; i++)
                {
                    int nRelationshipID=0;
                    int.TryParse(collection["RelationshipList"+i].ToString() ,out nRelationshipID);
                    CMR_ContactPerson cp = new CMR_ContactPerson();
                    cp.RelationshipTypeID = nRelationshipID;
                    cp.ContactName=collection["familyName"+i].ToString().Trim();
                    cp.CellPhone=collection["familycellphone" + i].ToString().Trim();
                    cp.OfficeTelphone=collection["familytelphone" + i].ToString().Trim();
                    cp.HomeTelphone=collection["familytelphonenight"+ i].ToString().Trim();
                    lContactPerson.Add(cp);
                
                }

                //mCMR_ContactPerson
                //CMR_ContactPerson mCMR_ContactPerson = new CMR_ContactPerson();
                //mCMR_ContactPerson.RelationshipTypeID = 0;
                //mCMR_ContactPerson.ContactName = "";
                //mCMR_ContactPerson.HomeTelphone = "";
                //mCMR_ContactPerson.OfficeTelphone = "";
                //mCMR_ContactPerson.CellPhone = "";
           
                //for (int i = 0; i < 4; i++)
                //{
                //    DateTime dtInspectionDate = new DateTime();
                //    lPMR_PathologyBody.Add(new PMR_PathologyBody() { PathologyID = i, InspectionDate = dtInspectionDate, ResultValue = i+"value" });
                //}

                //PatientName
                PMR_PathologyHead mPMR_PathologyHead = new PMR_PathologyHead();
                //DateTime dtInspectionDate1 = new DateTime();
                mPMR_PathologyHead.InspectionDate = dtNow;
                mPMR_PathologyHead.DiagnosisDate = dtNow;
                mPMR_PathologyHead.ChronicTypeID = 1;
                int nChronicSubTypeID = 1;
                int.TryParse(collection["ChronicSubTypeList"].ToString(), out nChronicSubTypeID);
                mPMR_PathologyHead.ChronicSubTypeID = nChronicSubTypeID;
                mAPP_User.ChronicSubTypeID = nChronicSubTypeID;
                nPatientID = SP.Web_AddCMRPatient(mCMR_PatientKey, mCMR_PatientBase, mCMR_PatientDetails, mPMR_PathologyHead, lPMR_PathologyBody, lContactPerson, mAPP_User, 0);
                
                //if(mAPP_User.MailAddress!="")
                //{
                //    nAppID = SP.Web_AddAPPUser(mAPP_User);
                //}
                //MedicalRecordNumber
                //sex
                //IdentityNumber
                //Birthday
                //    cellphone
                //    telphone
                //        Domicileaddress
                //        NowHomeAddress
                //            DisableNumber


                //BloodTypeList
                //RaceTypeList
                //    dropdownState
                //    dropdownCity
                //        dropdownDistrict
                //        dropdownLivingState
                //            dropdownLivingCity
                //            dropdownLivingDistrict
                //int.TryParse(collection["LivingStatusList"].ToString(), out nPID);

                //Bodyweight
                //    Height
                //    Allergyhistory

                //step2


               // TempData["TmpSuccessMsg"] = "建立成功!";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
                return RedirectToAction("CreateDMIndex");
            }
            return RedirectToAction("CreateQRCode", new { patientID = nPatientID });
        }

        [HttpPost]
        public ActionResult AddDM3(FormCollection collection, List<PMRTagNameCBViewModel> PMRTagNameCBList)
        {
            try
            {
                List<PMR_PathologyBody> lPMR_PathologyBody = new List<PMR_PathologyBody>();
                DateTime dtNow = new DateTime();
                dtNow = DateTime.Now;
                #region 基本資料
                //血型
                var bloodTypeList = SP.Web_GetSYSBloodType();
                //種族
                var raceTypeList = SP.Web_GetSYSRaceType();
                //居住情形
                var livingStatusList = SP.Web_GetSYSLivingStatus();
                //戶籍地址
                int nRegisterStateID = 0;
                int.TryParse(collection["dropdownState"].ToString(), out nRegisterStateID);
                int nRegisterCityID = 0;
                int.TryParse(collection["dropdownCity"].ToString(), out nRegisterCityID);
                int nRegisterDistrictID = 0;
                if (collection["dropdownDistrict"] != null)
                {
                    int.TryParse(collection["dropdownDistrict"].ToString(), out nRegisterDistrictID);
                }
                if (SP.Web_CheckAddressArea(nRegisterStateID, nRegisterCityID, nRegisterDistrictID).Count == 0)
                {
                    TempData["TmpErrMsg"] = "現居地址錯誤";
                    return RedirectToAction("Index");
                }
                //現居地址
                if (SP.Web_CheckAddressArea(1, 1, 1).Count == 0)
                {
                    TempData["TmpErrMsg"] = "現居地址錯誤";
                    return RedirectToAction("Index");
                }
                #endregion
                #region 建立病人基本資料

                //糖尿病類型
                var diabetesTypeList = SP.Web_GetDiabetesType();
                int ndiabetesTypeID = diabetesTypeList.Where(x => x.ChronicSubTypeID == 1).Count();
                if (ndiabetesTypeID == 0)
                {
                    TempData["TmpErrMsg"] = "糖尿病類型錯誤";
                    return RedirectToAction("Index");
                }
                //個人病史
                var ChronicList = SP.Web_GetPMRTagChronicName();
                foreach (var item in PMRTagNameCBList)
                {
                    if (item.Checked == true)
                    {
                        int nChronicList = ChronicList.Where(x => x.PathologyID == item.PathologyID).Count();
                        if (nChronicList == 0)
                        {
                            TempData["TmpErrMsg"] = "個人病史類型錯誤";
                            return RedirectToAction("Index");

                        }
                        else
                        {
                            lPMR_PathologyBody.Add(new PMR_PathologyBody() { PathologyID = item.PathologyID, InspectionDate = dtNow, ResultValue = "Y" });
                        }
                    }

                }
                //過敏史
                string sAllergyhistory = collection["Allergyhistory"].ToString().Trim();
                if (sAllergyhistory.Length != 0)
                {
                    lPMR_PathologyBody.Add(new PMR_PathologyBody() { PathologyID = 17, InspectionDate = dtNow, ResultValue = sAllergyhistory });
                }
                #endregion

                #region 關係聯絡人
                var relationshipList = SP.Web_GetSYSRelationshipType();
                int nrelationshipList = relationshipList.Where(x => x.RelationshipTypeID == 1).Count();
                if (ndiabetesTypeID == 0)
                {
                    TempData["TmpErrMsg"] = "關係聯絡人錯誤";
                    return RedirectToAction("Index");
                }

                #endregion


                //APP_User
                APP_User mAPP_User=new APP_User();
                mAPP_User.DiagnosisDate = dtNow;
                int nAppUserID = 0;
                int.TryParse(collection["hAppUserID"].ToString(), out nAppUserID);
                mAPP_User.AppUserID = nAppUserID;

                //step1
                //CMR_PatientKey
                CMR_PatientKey mCMR_PatientKey = new CMR_PatientKey();
                //MedicalRecordNumber
                string sMedicalRecordNumber = collection["MedicalRecordNumber"].ToString().Trim();
                mCMR_PatientKey.MedicalRecordNumber = sMedicalRecordNumber;
                mCMR_PatientKey.ChronicTypeID = 1;
                mCMR_PatientKey.ParentUnitID = 0;
                mCMR_PatientKey.CaseStatus = 0;
                mCMR_PatientKey.Enable = true;

                //CMR_PatientBase
                CMR_PatientBase mCMR_PatientBase = new CMR_PatientBase();
                string sName = collection["PatientName"].ToString().Trim();
                mCMR_PatientBase.PatientName = sName;
                mAPP_User.Name = sName;
                string sIdentityNumber = collection["IdentityNumber"].ToString().Trim();
                mCMR_PatientBase.IdentityNumber = sIdentityNumber;
                mAPP_User.IdentityNumber = sIdentityNumber;
                DateTime dtBirthday = new DateTime();
                DateTime.TryParse(collection["Birthday"].ToString(), out dtBirthday);
                mCMR_PatientBase.Birthday = dtBirthday;
                mAPP_User.Birthday = dtBirthday;
                decimal dBodyWeight = 0;
                decimal.TryParse(collection["Bodyweight"].ToString(), out dBodyWeight);
                mCMR_PatientBase.BodyWeight = dBodyWeight;
                mAPP_User.BodyWeight = dBodyWeight;
                decimal dBodyHeight = 0;
                decimal.TryParse(collection["Height"].ToString(), out dBodyHeight);
                mCMR_PatientBase.BodyHeight = dBodyHeight;
                mAPP_User.BodyHeight = dBodyHeight;
                int nSex = 0;
                int.TryParse(collection["sex"].ToString(), out nSex);
                mCMR_PatientBase.SexID = nSex;
                mAPP_User.SexID = nSex;
                int nRaceTypeID = 0;
                int.TryParse(collection["RaceTypeList"].ToString(), out nRaceTypeID);
                mCMR_PatientBase.RaceTypeID = nRaceTypeID;
                int nBloodTypeID = 0;
                int.TryParse(collection["BloodTypeList"].ToString(), out nBloodTypeID);
                mCMR_PatientBase.BloodTypeID = nBloodTypeID;
                string sDisabledID = collection["DisableNumber"].ToString().Trim();
                mCMR_PatientBase.DisabledID = sDisabledID;
                int nRegisterCountryID = 1;
                mCMR_PatientBase.RegisterCountryID = nRegisterCountryID;
               
                mCMR_PatientBase.RegisterStateID = nRegisterStateID;
               
                mCMR_PatientBase.RegisterCityID = nRegisterCityID;
                
                mCMR_PatientBase.RegisterDistrictID = nRegisterDistrictID;
                string sDomicileaddress = collection["Domicileaddress"].ToString().Trim();
                mCMR_PatientBase.RegisterAddress = sDomicileaddress;

                //CMR_PatientDetails
                CMR_PatientDetails mCMR_PatientDetails = new CMR_PatientDetails();
                mCMR_PatientDetails.eMail=collection["Email"].ToString().Trim();
                mAPP_User.MailAddress = collection["Email"].ToString().Trim();
                mCMR_PatientDetails.NowCountryID = 1;
                int nNowStateID = 0;
                int.TryParse(collection["dropdownLivingState"].ToString(), out nNowStateID);
                mCMR_PatientDetails.NowStateID = nNowStateID;
                int nNowCityID = 0;
                int.TryParse(collection["dropdownLivingCity"].ToString(), out nNowCityID);
                mCMR_PatientDetails.NowCityID = nNowCityID;
                int nNowDistrictID = 0;
                int.TryParse(collection["dropdownLivingDistrict"].ToString(), out nNowDistrictID);
                mCMR_PatientDetails.NowDistrictID = nNowDistrictID;
                mCMR_PatientDetails.NowAddress = collection["NowHomeAddress"].ToString().Trim();
                mCMR_PatientDetails.HomeTelphone = collection["telphone"].ToString().Trim();
                mCMR_PatientDetails.OfficeTelphone = collection["telphone"].ToString().Trim();
                mCMR_PatientDetails.CellPhone = collection["cellphone"].ToString().Trim();
                mAPP_User.MobileNumber = collection["cellphone"].ToString().Trim();
                //default app password cellphone
                mAPP_User.Password = collection["cellphone"].ToString().Trim();
               // mCMR_PatientDetails.eMail = collection["sex"].ToString().Trim();
                int nLivingStatus = 0;
                int.TryParse(collection["LivingStatusList"].ToString(), out nLivingStatus);
                mCMR_PatientDetails.LivingStatus = nLivingStatus;

                List<CMR_ContactPerson> lContactPerson = new List<CMR_ContactPerson>();
                int nCCount = 1;
                int.TryParse(collection["ContactCount"].ToString(), out nCCount);
                if (nCCount>=4)
                {
                   nCCount = 4;
                }
                else if (nCCount ==0)
                {
                    nCCount = 1;
                }
                for (int i = 1; i <= nCCount; i++)
                {
                    int nRelationshipID=0;
                    int.TryParse(collection["RelationshipList"+i].ToString() ,out nRelationshipID);
                    CMR_ContactPerson cp = new CMR_ContactPerson();
                    cp.RelationshipTypeID = nRelationshipID;
                    cp.ContactName=collection["familyName"+i].ToString().Trim();
                    cp.CellPhone=collection["familycellphone" + i].ToString().Trim();
                    cp.OfficeTelphone=collection["familytelphone" + i].ToString().Trim();
                    cp.HomeTelphone=collection["familytelphonenight"+ i].ToString().Trim();
                    lContactPerson.Add(cp);
                
                }

            

                //PatientName
                PMR_PathologyHead mPMR_PathologyHead = new PMR_PathologyHead();
                //DateTime dtInspectionDate1 = new DateTime();
                mPMR_PathologyHead.InspectionDate = dtNow;
                mPMR_PathologyHead.DiagnosisDate = dtNow;
                mPMR_PathologyHead.ChronicTypeID = 1;
                int nChronicSubTypeID = 1;
                int.TryParse(collection["ChronicSubTypeList"].ToString(), out nChronicSubTypeID);
                mPMR_PathologyHead.ChronicSubTypeID = nChronicSubTypeID;
                mAPP_User.ChronicSubTypeID = nChronicSubTypeID;

                SP.Web_AddCMRPatient(mCMR_PatientKey, mCMR_PatientBase, mCMR_PatientDetails, mPMR_PathologyHead, lPMR_PathologyBody, lContactPerson, mAPP_User,1);

                //update 
                //SP.Web_UpdateAPPUser(mAPP_User);


                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
                return RedirectToAction("CreateExistAccountDMIndex");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ConfirmApp(FormCollection collection)
        {
           if( collection["AppID"]!=null)
           {
               return RedirectToAction("CreateExistAccountDMIndex", new { appID = collection["AppID"].ToString() });
           }
           else
           {
               return View("Index");
           }
           
        }

        public JsonResult VerifyAccount(string accout)
         {

            
             //List<SYS_District> allStates = SP.Web_GetSYSDistrict(Id);
             //var district = from a in allStates where a.StateID == Id select a;
             //var district = SP.Web_GetSYSDistrict(1);
            
             Dictionary<string, string> field = new Dictionary<string, string>();
             List<APP_User> lUser = SP.Web_GetAPPUserByMail(accout.Trim());
             if (lUser.Count != 0)
             {
                 string sName = lUser.Select(x => x.Name).FirstOrDefault();
                 int nID = lUser.Select(x => x.AppUserID).FirstOrDefault();
                 DateTime dtBirthday = lUser.Select(x => x.Birthday).FirstOrDefault();
                 int nSex = lUser.Select(x => x.SexID).FirstOrDefault();
                 string sSex = "";
                 if (nSex == 0)
                 {
                     sSex = "女";
                 }
                 else
                 {
                     sSex = "男";
                 }
                 field.Add("姓名", sName);
                 field.Add("生日", dtBirthday.ToShortDateString());
                 field.Add("ID", nID.ToString());
                 field.Add("性別", sSex);
             }
             if (field.Count==0)
             {
                 return Json("");
             }
             else
             { 
                 return Json(field);
             }
            
         }

        public ActionResult CreateExistAccountDMIndex( string appID)
        {
            List<APP_User> lUser = new List<APP_User>();
            if(appID!=null)
            {
                int nAppID=0;
                int.TryParse(appID.Trim(),out nAppID);
                lUser=SP.Web_GetAPPUserInfo(nAppID);
            }
            else
            {
                return RedirectToAction("CreateDMIndex");
            }
            #region 基本資料
            //血型
            var bloodTypeList = SP.Web_GetSYSBloodType();
            ViewBag.BloodTypeList = new SelectList(
           items: bloodTypeList,
           dataTextField: "BloodTypeName",
           dataValueField: "BloodTypeID"
           );
            //種族
            var raceTypeList = SP.Web_GetSYSRaceType();
            ViewBag.RaceTypeList = new SelectList(
            items: raceTypeList,
            dataTextField: "RaceTypeName",
            dataValueField: "RaceTypeID"
            );
            //居住情形
            var livingStatusList = SP.Web_GetSYSLivingStatus();
            ViewBag.LivingStatusList = new SelectList(
            items: livingStatusList,
            dataTextField: "Description",
            dataValueField: "LivingStatus"
            );
            //戶籍地址
            //現居地址
            #endregion
            #region 建立病人基本資料
            var ChronicList = SP.Web_GetPMRTagChronicName();
            //糖尿病類型
            var diabetesTypeList = SP.Web_GetDiabetesType();
            ViewBag.ChronicSubTypeList = new SelectList(
            items: diabetesTypeList,
            dataTextField: "ChronicSubName",
            dataValueField: "ChronicSubTypeID"
            );
            #endregion

            #region 關係聯絡人
            var relationshipList = SP.Web_GetSYSRelationshipType();
            ViewBag.RelationshipList = new SelectList(
           items: relationshipList,
           dataTextField: "Description",
           dataValueField: "RelationshipTypeID"
           );
            #endregion
            return View(new SetUpCreateAcountModel { BloodTypeList = bloodTypeList, RaceTypeeList = raceTypeList, LivingStatusList = livingStatusList, PMRTagNameCBList = ChronicList, RelationshipList = relationshipList, ChronicSubTypeList = diabetesTypeList,APPUserList=lUser });

        }

        [HttpPost]
        public ActionResult AddDM2(FormCollection collection)
        {

            return Redirect(Url.Action("TEST", "DCSetUp") + "#Package");
        }
        public ActionResult TEST(int Tabs = 5)
        {
            var tabs = new List<string> { "", "", "","",""};
            tabs[Tabs - 1] = "active";
            return View(new SetUpCreateAcountModel { Tabs = tabs });
     
        }
	}
}