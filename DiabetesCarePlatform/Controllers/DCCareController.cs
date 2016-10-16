using DiabetesCarePlatform.Models;
using DiabetesCarePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiabetesCarePlatform.Controllers
{
    public class DCCareController : Controller
    {
        protected DCCareRepository SP = new DCCareRepository();
        protected DBRepository CommonSP = new DBRepository();

        //
        // GET: /DCCare/
        [Authorize]
        public ActionResult Index()
        {
            List<SYS_SexType> lSexType = new List<SYS_SexType>();
            //List<DCCareIndexViewModel> lDM = new List<DCCareIndexViewModel>();
            lSexType = CommonSP.Web_GetSYSSexType();
            return View(lSexType);
        }

        [Authorize]
        public ActionResult DCItemView()
        {
            return View();
        }

        [Authorize]
        public ActionResult DMIndex(string PatientID)
        {
            return View();
        }

        // 子功能Menu
        public ActionResult DCIndexMenu(string PatientID)
        {
            var lBP = SP.Web_GetDMCareMemberByUserID(int.Parse(PatientID));
            var UserData = (from data in lBP
                            where data.PatientID == int.Parse(PatientID)
                            select data).FirstOrDefault();

            return PartialView("_DCIndexMenuPartial", new DCCareIndexUserViewModel { UserDataModel = UserData });
        }
       
        public JsonResult GetDMCareQueryResult(string Name, string MedicalRecordNumber, string HomeTelphone, string CellPhone, string SexID)
        {
            List<DCCareIndexViewModel> lDM = new List<DCCareIndexViewModel>();
            int nSexID = -1;
            int.TryParse(SexID, out nSexID);

            lDM = SP.Web_QueryDMCareInfoByUserID(Name.Trim(), MedicalRecordNumber.Trim(), nSexID, HomeTelphone.Trim(), CellPhone.Trim());
            return Json(lDM);
        }

        #region [ 取得系統參數 ]

        // 性別
        public JsonResult GetSYSSexType()
        {
            var List = CommonSP.Web_GetSYSSexType();
            return Json(List);
        }

        // 糖尿病類型
        public JsonResult GetSYSChronicSubType()
        {
            var List = CommonSP.Web_GetDiabetesType();
            return Json(List);
        }

        // 血型
        public JsonResult GetSYSBloodType()
        {
            var List = CommonSP.Web_GetSYSBloodType();
            return Json(List);
        }

        // RH血型
        public JsonResult GetSYSBloodRHType()
        {
            var List = CommonSP.Web_GetSYSBloodRhType();
            return Json(List);
        }

        // 民族
        public JsonResult GetSYSRaceType()
        {
            var List = CommonSP.Web_GetSYSRaceType();
            return Json(List);
        }

        // 語言
        public JsonResult GetSYSLanguageType()
        {
            var List = CommonSP.Web_GetSYSLanguageType();
            return Json(List);
        }

        // 宗教
        public JsonResult GetSYSReligionType()
        {
            var List = CommonSP.Web_GetSYSReligionType();
            return Json(List);
        }

        // 婚姻狀況
        public JsonResult GetSYSMaritalStatus()
        {
            var List = CommonSP.Web_GetSYSMaritalStatus();
            return Json(List);
        }

        // 教育程度
        public JsonResult GetSYSEducationLevel()
        {
            var List = CommonSP.Web_GetSYSEducationLevel();
            return Json(List);
        }

        // 職業
        public JsonResult GetSYSProfessionType()
        {
            var List = CommonSP.Web_GetSYSProfessionType();
            return Json(List);
        }

        // 居住狀況
        public JsonResult GetSYSLivingStatus()
        {
            var List = CommonSP.Web_GetSYSLivingStatus();
            return Json(List);
        }

        // 吸菸習慣
        public JsonResult GetSYSSmokeType()
        {
            var List = CommonSP.Web_GetSYSSmokeType();
            return Json(List);
        }

        // 飲酒習慣
        public JsonResult GetSYSDrinkType()
        {
            var List = CommonSP.Web_GetSYSDrinkType();
            return Json(List);
        }

        // 檳榔習慣
        public JsonResult GetSYSArecaType()
        {
            var List = CommonSP.Web_GetSYSArecaType();
            return Json(List);
        }

        // 省
        public JsonResult GetState()
        {
            var StateList = CommonSP.Web_GetSYSState();
            return Json(StateList.ToList(), JsonRequestBehavior.AllowGet);
        }

        // 市
        public JsonResult GetCityByStateId(string stateId)
        {
            int Id = 0;
            if (int.TryParse(stateId, out Id))
            {
                var city = CommonSP.Web_GetSYSCity(Id);
                return Json(city);
            }
            return Json("");
        }

        // 區
        public JsonResult GetDistrictByCityId(string cityId)
        {
            int Id = Convert.ToInt32(cityId);
            var district = CommonSP.Web_GetSYSDistrict(Id);
            return Json(district);
        }

        #endregion

        #region [ 基本資料 ]
        [Authorize]
        public ActionResult BasicInformation(int PatientID)
        {
            var BID = SP.Web_GetCMRBasicInformation(PatientID);
            var PersonList = SP.Web_GetCMRContactPerson(PatientID);
            var PMRList = SP.Web_GetPMRPathology(PatientID);
            return View(new BasicInformationModel { BIDMItem = BID, ContactPersonList = PersonList, PathologyList = PMRList });
        }

        [HttpPost]
        public ActionResult EditBasicInformation(FormCollection collection)
        {
            try
            {
                CMR_PatientBase Model = new CMR_PatientBase();
                CMR_PatientDetails ModelDetail = new CMR_PatientDetails();
                CMR_PatientKey ModelKey = new CMR_PatientKey();

                Model.PatientID = Convert.ToInt16(collection["PatientID"]);
                Model.PatientName = collection["PatientName"];
                Model.SexID = Convert.ToInt16(collection["SexType"]);
                DateTime dtBirthday = new DateTime();
                DateTime.TryParse(collection["Birthday"].ToString(), out dtBirthday);
                Model.Birthday = dtBirthday;
                Model.BloodTypeID = Convert.ToInt16(collection["BloodType"]);
                Model.BloodRhTypeID = Convert.ToInt16(collection["BloodRhType"]);
                Model.RaceTypeID = Convert.ToInt16(collection["RaceType"]);
                Model.LanguageTypeID = Convert.ToInt16(collection["LanguageType"]);
                Model.ReligionTypeID = Convert.ToInt16(collection["ReligionType"]);
                Model.EducationLevelID = Convert.ToInt16(collection["EducationLevel"]);
                Model.DisabledID = collection["DisabledID"];
                Model.Section = 1;
                SP.Web_EditCMRPatientBase(Model);

                ModelKey.PatientID = Convert.ToInt16(collection["PatientID"]);
                ModelKey.ChronicSubTypeID = Convert.ToInt16(collection["ChronicSubType"]);
                ModelKey.Section = 1;
                SP.Web_EditCMRPatientKey(ModelKey);

                ModelDetail.PatientID = Convert.ToInt16(collection["PatientID"]);
                ModelDetail.ProfessionID = Convert.ToInt16(collection["ProfessionType"]);
                ModelDetail.Section = 1;
                SP.Web_EditCMRPatientDetails(ModelDetail);


                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            //return RedirectToAction("BasicInformation", collection["PatientID"]);
            return RedirectToAction("BasicInformation", new { PatientID = collection["PatientID"] });
        }

        public ActionResult EditHobby(FormCollection collection)
        {
            try
            {
                CMR_PatientBase Model = new CMR_PatientBase();
                CMR_PatientDetails ModelDetail = new CMR_PatientDetails();

                Model.PatientID = Convert.ToInt16(collection["PatientID"]);
                Model.MaritalStatus = Convert.ToInt16(collection["MaritalStatus"]);
                Model.Section = 2;

                SP.Web_EditCMRPatientBase(Model);

                ModelDetail.PatientID = Convert.ToInt16(collection["PatientID"]);
                ModelDetail.LivingStatus = Convert.ToInt16(collection["LivingStatus"]);
                ModelDetail.SmokeTypeID = Convert.ToInt16(collection["SmokeType"]);
                ModelDetail.DrinkTypeID = Convert.ToInt16(collection["DrinkType"]);
                ModelDetail.ArecaTypeID = Convert.ToInt16(collection["ArecaType"]);

                ModelDetail.Section = 2;
                SP.Web_EditCMRPatientDetails(ModelDetail);

                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            //return RedirectToAction("BasicInformation", collection["PatientID"]);
            return RedirectToAction("BasicInformation", new { PatientID = collection["PatientID"] });
        }

        public ActionResult EditContact(FormCollection collection)
        {
            try
            {
                //CMR_PatientBase Model = new CMR_PatientBase();
                //CMR_PatientDetails ModelDetail = new CMR_PatientDetails();

                //Model.PatientID = Convert.ToInt16(collection["PatientID"]);
                //Model.MaritalStatus = Convert.ToInt16(collection["MaritalStatus"]);
                //Model.Section = 2;

                //SP.Web_EditCMRPatientBase(Model);

                //ModelDetail.PatientID = Convert.ToInt16(collection["PatientID"]);
                //ModelDetail.LivingStatus = Convert.ToInt16(collection["LivingStatus"]);
                //ModelDetail.SmokeTypeID = Convert.ToInt16(collection["SmokeType"]);
                //ModelDetail.DrinkTypeID = Convert.ToInt16(collection["DrinkType"]);
                //ModelDetail.ArecaTypeID = Convert.ToInt16(collection["ArecaType"]);

                //ModelDetail.Section = 2;
                //SP.Web_EditCMRPatientDetails(ModelDetail);

                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("BasicInformation", new { PatientID = collection["PatientID"] });
        }

        public ActionResult EditPMRHitory(FormCollection collection)
        {
            try
            {    
                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("BasicInformation", new { PatientID = collection["PatientID"] });
        }


        public ActionResult EditContactPerson(FormCollection collection)
        {
            try
            {
                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("BasicInformation", new { PatientID = collection["PatientID"] });
        }
        

        #endregion

        #region [ 個人設定 ]
        [Authorize]
        public ActionResult Setting(int PatientID)
        {
            var unitlist = SP.Web_GetCareGroupXUserUnit(PatientID);
            if (unitlist.Count > 0)
            {
                var CGUnitID = unitlist[0];
                CGUnitSetting setting = new CGUnitSetting();
                setting.CGUnitID = CGUnitID;
                var confing = SP.Web_GetCMRDiabetesAlertConfig(PatientID, CGUnitID);
                setting.Config = confing == null ? new CMR_DiabetesAlertConfig() : confing;
                var types = SP.Web_GetSYSMealTypeTimingType();
                var plans = SP.Web_GetCMRDiabetesPlan(PatientID, CGUnitID);
                setting.PlanList = SetPatientPlan(types, plans);
                return View(new DCCare_SettingPage { PatientID = PatientID, CGUnitSettings = setting });
            }
            else
            {
                TempData["TmpErrMsg"] = "所屬單位不同";
                return RedirectToAction("Index");
            }
        }
        private List<MealTypeTimingType> SetPatientPlan(List<MealTypeTimingType> MealTypeTimingType, List<CMR_DiabetesPlan> PlanList)
        {
            foreach (var item in MealTypeTimingType)
            {
                var one = PlanList.Find(p => p.MealTypeID == item.MealTypeID && p.TimingTypeID == item.TimingTypeID);
                item.Checked = (one != null);
            }
            return MealTypeTimingType;
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateCMRDiabetesAlertConfig(FormCollection collection)
        {
            int PatientID = Convert.ToInt16(collection["PatientID"]);
            try
            {
                CMR_DiabetesAlertConfig model = new CMR_DiabetesAlertConfig();
                model.PatientID = PatientID;
                model.CGUnitID = Convert.ToInt16(collection["CGUnitID"]);
                model.BeforeMealLow = Convert.ToDecimal(collection["BeforeMealLow"]);
                model.BeforeMealHigh = Convert.ToDecimal(collection["BeforeMealHigh"]);
                model.AfterMealLow = Convert.ToDecimal(collection["AfterMealLow"]);
                model.AfterMealHigh = Convert.ToDecimal(collection["AfterMealHigh"]);
                model.OthersLow = Convert.ToDecimal(collection["OthersLow"]);
                model.OthersHigh = Convert.ToDecimal(collection["OthersHigh"]);
                model.MissingCount = Convert.ToInt16(collection["MissingCount"]);
                SP.Web_EditCMRDiabetesAlertConfig(model);
                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("Setting", new { PatientID = PatientID });
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateCMRDiabetesPlan(FormCollection collection)
        {
            int PatientID = Convert.ToInt16(collection["PatientID"]);
            int CGUnitID = Convert.ToInt16(collection["CGUnitID"]);
            try
            {
                var newPlan = new List<CMR_DiabetesPlan>();
                string planstr = collection["Plan"];
                if (planstr != null && planstr.Length > 0)
                {
                    var planlist = planstr.Split(',');
                    foreach (var item in planlist)
                    {
                        var mealtypeid = Convert.ToInt16(item.Split('-')[0]);
                        var timingtypeid = Convert.ToInt16(item.Split('-')[1]);
                        CMR_DiabetesPlan p = new CMR_DiabetesPlan();
                        p.PatientID = PatientID;
                        p.CGUnitID = CGUnitID;
                        p.MealTypeID = mealtypeid;
                        p.TimingTypeID = timingtypeid;
                        newPlan.Add(p);
                    }
                }
                var dbPlan = SP.Web_GetCMRDiabetesPlan(PatientID, CGUnitID);
                foreach (var dbone in dbPlan)
                {
                    bool isKeep = false;
                    foreach (var newone in newPlan)
                    {
                        if (dbone.MealTypeID == newone.MealTypeID && dbone.TimingTypeID == newone.TimingTypeID)
                        {
                            isKeep = true;
                            break;
                        }
                    }
                    if (!isKeep)
                    {
                        SP.Web_EditCMRDiabetesPlan(dbone, false);
                    }
                }

                foreach (var newone in newPlan)
                {
                    bool isExists = false;
                    foreach (var dbone in dbPlan)
                    {
                        if (dbone.MealTypeID == newone.MealTypeID && dbone.TimingTypeID == newone.TimingTypeID)
                        {
                            isExists = true;
                            break;
                        }
                    }
                    if (!isExists)
                    {
                        SP.Web_EditCMRDiabetesPlan(newone, true);
                    }
                }
                TempData["TmpSuccessMsg"] = "更新成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }
            return RedirectToAction("Setting", new { PatientID = PatientID });
        }

        #endregion
        
        #region [ 服務紀錄 ]
        [Authorize]
        public ActionResult ServiceRecord(int PatientID)
        {
            DCCare_ServiceRecordPage model = new DCCare_ServiceRecordPage();
            model.PatientID = PatientID;
            model.RecordList = SP.Web_GetCGServiceRecord(PatientID);
            model.ServiceRecordType = SP.Web_GetSYSServiceRecordType();
            model.ServiceResult = SP.Web_GetSYSServiceResult();
            model.ServiceType = SP.Web_GetSYSServiceType();
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddServiceRecord(FormCollection collection)
        {
            int PatientID = Convert.ToInt16(collection["PatientID"]);
            try
            {
                CG_ServiceRecord model = new CG_ServiceRecord();
                model.PatientID = PatientID;
                model.ServiceDate = collection["ServiceDate"];
                model.StartTime = collection["StartTime"];
                model.EndTime = collection["EndTime"];
                model.ServiceRecordTypeID = Convert.ToInt16(collection["ServiceRecordTypeID"]);
                model.ServiceResultID = Convert.ToInt16(collection["ServiceResultID"]);
                model.ServiceResultNote = collection["ServiceResultNote"];
                model.ServiceTypeID = Convert.ToInt16(collection["ServiceTypeID"]);
                model.ServiceTypeNote = collection["ServiceTypeNote"];
                model.Note = collection["Note"];
                model.ResponseMessage = collection["ResponseMessage"];
                SP.Web_AddCGServiceRecord(model);
                TempData["TmpSuccessMsg"] = "新增成功";
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
            }

            return RedirectToAction("ServiceRecord", new { PatientID = PatientID });
        }

        #endregion

        #region [ 血糖紀錄 ]
        [Authorize]
        public ActionResult PatientBloodSugar(int PatientID, int GlucoseDay = 7)
        {
            var list = SP.Web_GetPatientBloodSugar(PatientID, GlucoseDay);
            var config = GetCMRDiabetesAlertConfig(PatientID);
            DCCare_BloodSugarPage model = new DCCare_BloodSugarPage();
            model.PatientID = PatientID;
            model.GlucoseDay = GlucoseDay;
            model.MealTimingType = SP.Web_GetSYSMealTypeTimingType();

            model.TopHighValue = Convert.ToInt16(list.Max(x => x.ResultValue));
            model.TopLowValue = Convert.ToInt16(list.Min(x => x.ResultValue));
            model.AvgValue = Convert.ToInt16(list.Average(x => x.ResultValue));
            model.TotalCount = list.Count();
            model.HigherCount = list.Count(x => (x.ResultValue > config.BeforeMealHigh && x.MealTypeID == 1)
                                                || (x.ResultValue > config.AfterMealHigh && x.MealTypeID == 2)
                                                || (x.ResultValue > config.OthersHigh && x.MealTypeID == 0));
            model.LowerCount = list.Count(x => (x.ResultValue < config.BeforeMealLow && x.MealTypeID == 1)
                                                || (x.ResultValue < config.AfterMealLow && x.MealTypeID == 2)
                                                || (x.ResultValue < config.OthersLow && x.MealTypeID == 0));
            model.GoodCount = list.Count - model.HigherCount - model.LowerCount;

            model.SectionCountData = SetSectionCountData(list);
            model.BoundCountData = SetBoundCountData(model.HigherCount, model.LowerCount, model.GoodCount);
            model.TrendData = SetTrendData(list, model.MealTimingType);
            model.BeforeAfterMealData = SetBeforeAfterMealData(list, model.MealTimingType);
            model.TableData = SetTableData(list, model.MealTimingType);
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult PatientBloodSugarPost(int PatientID, int GlucoseDay)
        {
            return RedirectToAction("PatientBloodSugar", new { PatientID = PatientID, GlucoseDay = GlucoseDay });
        }
        private CMR_DiabetesAlertConfig GetCMRDiabetesAlertConfig(int PatientID)
        {
            var unitlist = SP.Web_GetCareGroupXUserUnit(PatientID);
            var confing = new CMR_DiabetesAlertConfig();
            if (unitlist.Count > 0)
            {
                var CGUnitID = unitlist[0];
                confing = SP.Web_GetCMRDiabetesAlertConfig(PatientID, CGUnitID);
            }
            if (confing == null || confing.PatientID == 0)
            {
                confing = new CMR_DiabetesAlertConfig { BeforeMealLow = 120, BeforeMealHigh = 200, AfterMealLow = 120, AfterMealHigh = 130, OthersLow = 120, OthersHigh = 120 };
            }
            return confing;
        }
        private BloodSugarTable SetTableData(List<U_BloodSugar> list, List<MealTypeTimingType> MealTimingType)
        {

            var dates = list.GroupBy(a => a.RecordTime).Select(g => g.First()).ToList();
            var labels = new List<string>();
            foreach (var item in dates)
            {
                labels.Add(item.RecordTime);
            }
            List<BloodSugarTableRow> body = new List<BloodSugarTableRow>();
            foreach (var date in labels)
            {
                BloodSugarTableRow row = new BloodSugarTableRow();
                row.RecordDate = date;
                row.RecordValue = new List<U_BloodSugar>();
                foreach (var timing in MealTimingType)
                {
                    var value = list.Find(x => x.RecordTime == date && x.TimingTypeID == timing.TimingTypeID && x.MealTypeID == timing.MealTypeID);
                    row.RecordValue.Add(value);
                }
                body.Add(row);
            }
            List<decimal> counts = new List<decimal>();
            List<decimal> avgs = new List<decimal>();
            foreach (var timing in MealTimingType)
            {
                var count = list.FindAll(x => x.TimingTypeID == timing.TimingTypeID && x.MealTypeID == timing.MealTypeID).Count;
                var avg = list.FindAll(x => x.TimingTypeID == timing.TimingTypeID && x.MealTypeID == timing.MealTypeID).Average(a => a.ResultValue);
                counts.Add(count);
                avgs.Add(avg);
            }
            BloodSugarTable data = new BloodSugarTable();
            data.Body = body;
            data.Foot = new List<BloodSugarTableRow>();
            data.Foot.Add(new BloodSugarTableRow { RecordDate = "平均", Value = avgs });
            data.Foot.Add(new BloodSugarTableRow { RecordDate = "比數", Value = counts });
            return data;
        }
        private LineChart SetTrendData(List<U_BloodSugar> list, List<MealTypeTimingType> MealTimingType)
        {
            List<string> colors = new List<string> { "#1976D2", "#F44336", "#FFB74D", "#009688", "#673AB7", "#2196F3", "#E91E63", "#212121", "#FFFF33" };
            LineChart chart = new LineChart();
            var dates = list.GroupBy(a => a.RecordTime).Select(g => g.First()).ToList();
            var labels = new List<string>();
            foreach (var item in dates)
            {
                labels.Add(item.RecordTime);
            }
            chart.labels = labels;
            chart.datasets = new List<LineChartData>();
            var index = 0;
            foreach (var timing in MealTimingType)
            {
                LineChartData lcdata = new LineChartData();
                lcdata.label = timing.MealTypeName + timing.TimingTypeName;
                lcdata.metadata = timing.MealTypeID + "-" + timing.TimingTypeID;
                lcdata.strokeColor = colors[index];
                lcdata.pointColor = colors[index];
                List<string> data = new List<string>();
                foreach (var item in labels)
                {
                    var value = list.Find(x => x.RecordTime == item && x.TimingTypeID == timing.TimingTypeID && x.MealTypeID == timing.MealTypeID);
                    data.Add(value != null ? value.ResultValue.ToString() : null);
                }
                lcdata.data = data;
                lcdata.fillColor = "rgba(255, 255, 255,0.2)";
                lcdata.pointStrokeColor = "#fff";
                lcdata.pointHighlightFill = "#fff";
                lcdata.pointHighlightStroke = "rgba(151,187,205,1)";

                chart.datasets.Add(lcdata);
                index++;
            }
            return chart;
        }
        private List<PieChartData> SetBoundCountData(int HigherCount, int LowerCount, int GoodCount)
        {
            int total = HigherCount + LowerCount + GoodCount;
            List<PieChartData> chart = new List<PieChartData>();
            chart.Add(new PieChartData
            {
                value = GetPercentage(HigherCount, total),
                color = "#F7464A",
                highlight = "#FF5A5E",
                label = "過高",
                labelColor = "black",
                labelFontSize = 16
            });
            chart.Add(new PieChartData
            {
                value = GetPercentage(GoodCount, total),
                color = "#46BFBD",
                highlight = "#5AD3D1",
                label = "良好",
                labelColor = "black",
                labelFontSize = 16
            });
            chart.Add(new PieChartData
            {
                value = GetPercentage(LowerCount, total),
                color = "#FDB45C",
                highlight = "#FFC870",
                label = "過低",
                labelColor = "black",
                labelFontSize = 16
            });
            return chart;
        }
        private BarChart SetSectionCountData(List<U_BloodSugar> list)
        {
            int MaxValue = Convert.ToInt16(list.Max(x => x.ResultValue));
            int SectionCount = ((MaxValue - 100) / 30) + 1;
            List<string> labels = new List<string>();
            List<int> data = new List<int>();
            for (int i = 0; i < SectionCount; i++)
            {
                int LowerBound = 100 + (i * 30);
                int UpperBound = LowerBound + 30 - 1;
                labels.Add(string.Format("{0}-{1}", LowerBound, UpperBound));
                data.Add(list.Count(x => x.ResultValue >= LowerBound && x.ResultValue <= UpperBound));
            }

            BarChart chart = new BarChart();
            chart.labels = labels;
            BarChartData datasets = new BarChartData();
            datasets.data = data;
            datasets.fillColor = "rgba(160,160,50,0.5)";
            datasets.strokeColor = "rgba(220,220,220,0.8)";
            datasets.highlightFill = "rgba(220,220,220,0.75)";
            datasets.highlightStroke = "rgba(220,220,220,1)";
            chart.datasets = new List<BarChartData> { datasets };
            return chart;
        }
        private BarChart SetBeforeAfterMealData(List<U_BloodSugar> list, List<MealTypeTimingType> MealTimingType)
        {
            var dates = list.GroupBy(a => a.RecordTime).Select(g => g.First()).ToList();
            var meals = MealTimingType.FindAll(b => b.MealTypeID > 0).GroupBy(a => a.MealTypeID).Select(g => g.First()).ToList();
            List<string> labels = new List<string>();
            List<int> data1 = new List<int>();
            List<int> data2 = new List<int>();
            foreach (var item in dates)
            {
                string date = item.RecordTime;
                foreach (var m in meals)
                {
                    var value1 = list.Find(v => v.RecordTime == date && v.MealTypeID == m.MealTypeID && v.TimingTypeID == 1);
                    var value2 = list.Find(v => v.RecordTime == date && v.MealTypeID == m.MealTypeID && v.TimingTypeID == 2);
                    if (value1 != null || value2 != null)
                    {
                        labels.Add(date + m.MealTypeName);
                        data1.Add(value1 != null ? Convert.ToInt16(value1.ResultValue) : 0);
                        data2.Add(value2 != null ? Convert.ToInt16(value2.ResultValue) : 0);
                    }
                }
            }


            BarChart chart = new BarChart();
            chart.labels = labels;
            BarChartData dataset1 = new BarChartData();
            dataset1.data = data1;
            dataset1.label = "餐前";
            dataset1.fillColor = "rgba(52, 143, 226, 0.6)";
            dataset1.strokeColor = "rgba(52, 143, 226, 0.8)";
            dataset1.highlightFill = "rgba(52, 143, 226, 0.8)";
            dataset1.highlightStroke = "rgba(52, 143, 226, 1)";
            BarChartData dataset2 = new BarChartData();
            dataset2.data = data2;
            dataset2.label = "餐後";
            dataset2.fillColor = "rgba(0, 172, 172, 0.6)";
            dataset2.strokeColor = "rgba(0, 172, 172, 0.8)";
            dataset2.highlightFill = "rgba(0, 172, 172, 0.8)";
            dataset2.highlightStroke = "rgba(0, 172, 172, 1)";
            chart.datasets = new List<BarChartData> { dataset1, dataset2 };
            return chart;
        }
        private int GetPercentage(int value1, int value2)
        {
            double v1 = Convert.ToDouble(value1);
            double v2 = Convert.ToDouble(value2);
            double hundred = 100;
            int result = Convert.ToInt16(((v1 / v2) * hundred));
            return result;
        }

        #endregion

        #region [ 血壓紀錄 ]
        [Authorize]
        public ActionResult PatientBloodPressure(int PatientID, int PressureDay = 7)
        {
            List<BloodPressureData> lBP = new List<BloodPressureData>();
            lBP = SP.Web_GetPatientPressureRecord(PatientID, PressureDay);

            DCCare_BloodPressurePage model = new DCCare_BloodPressurePage();
            model.PatientID = PatientID;
            model.PressureDay = PressureDay;
            model.PressureList = lBP;

            model.Systolic_TopHighValue = Convert.ToInt16(lBP.Max(x => x.Systolic));
            model.Systolic_TopLowValue = Convert.ToInt16(lBP.Min(x => x.Systolic));
            model.Systolic_AvgValue = Convert.ToInt16(lBP.Average(x => x.Systolic));

            model.Diastolic_TopHighValue = Convert.ToInt16(lBP.Max(x => x.Diastolic));
            model.Diastolic_TopLowValue = Convert.ToInt16(lBP.Min(x => x.Diastolic));
            model.Diastolic_AvgValue = Convert.ToInt16(lBP.Average(x => x.Diastolic));

            model.Heartbeat_TopHighValue = Convert.ToInt16(lBP.Max(x => x.Heartbeat));
            model.Heartbeat_TopLowValue = Convert.ToInt16(lBP.Min(x => x.Heartbeat));
            model.Heartbeat_AvgValue = Convert.ToInt16(lBP.Average(x => x.Heartbeat));

            model.Diastolic_TotalCount = lBP.Count();
            model.Diastolic_HigherCount = lBP.Count(x => x.Diastolic > 160);
            model.Diastolic_LowerCount = lBP.Count(x => x.Diastolic < 110);
            model.Diastolic_GoodCount = lBP.Count(x => x.Diastolic <= 160 && x.Diastolic >= 110);

            model.Systolic_TotalCount = lBP.Count();
            model.Systolic_HigherCount = lBP.Count(x => x.Systolic > 160);
            model.Systolic_LowerCount = lBP.Count(x => x.Systolic < 110);
            model.Systolic_GoodCount = lBP.Count(x => x.Systolic <= 160 && x.Systolic >= 110);

            model.Heartbeat_TotalCount = lBP.Count();
            model.Heartbeat_HigherCount = lBP.Count(x => x.Heartbeat > 160);
            model.Heartbeat_LowerCount = lBP.Count(x => x.Heartbeat < 110);
            model.Heartbeat_GoodCount = lBP.Count(x => x.Heartbeat <= 160 && x.Heartbeat >= 110);

            //model.SectionCountData = SetSectionCountData(lBP);
            model.Heartbeat_BoundCountData = SetBoundCountData(model.Heartbeat_HigherCount, model.Heartbeat_LowerCount, model.Heartbeat_GoodCount);
            model.Systolic_BoundCountData = SetBoundCountData(model.Systolic_HigherCount, model.Systolic_LowerCount, model.Systolic_GoodCount);
            model.Diastolic_BoundCountData = SetBoundCountData(model.Diastolic_HigherCount, model.Diastolic_LowerCount, model.Diastolic_GoodCount);
            string[] sBPType = new string[] { "Systolic", "Diastolic", "Heartbeat" };
            model.TrendData = SetBloodPressureTrendData(lBP, sBPType);
            //model.TableData = SetTableData(list, model.MealTimingType);
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult PatientBloodPressurePost(int PatientID, int PressureDay)
        {
            return RedirectToAction("PatientBloodPressure", new { PatientID = PatientID, PressureDay = PressureDay });
        }

        private LineChart SetBloodPressureTrendData(List<BloodPressureData> list, string[] BloodPressureType)
        {
            List<string> colors = new List<string> { "#1976D2", "#F44336", "#FFB74D", "#009688", "#673AB7", "#2196F3", "#E91E63", "#212121", "#FFFF33" };
            LineChart chart = new LineChart();
            var dates = list.GroupBy(a => a.RecordTime).Select(g => g.First()).ToList();
            var labels = new List<string>();
            var labelsFormate = new List<string>();
            foreach (var item in dates)
            {
                labels.Add(item.RecordTime.ToString());
                labelsFormate.Add(string.Format("{0:f}", item.RecordTime));
            }
            chart.labels = labelsFormate;
            chart.datasets = new List<LineChartData>();
            var index = 0;
            foreach (var type in BloodPressureType)
            {
                LineChartData lcdata = new LineChartData();
                lcdata.label = type;
                lcdata.metadata = type;
                lcdata.strokeColor = colors[index];
                lcdata.pointColor = colors[index];
                List<string> data = new List<string>();
                foreach (var item in labels)
                {
                    var value = list.Find(x => x.RecordTime.ToString() == item);
                    data.Add(value != null ? value.GetType().GetProperty(type).GetValue(value).ToString() : null);
                }
                lcdata.data = data;
                lcdata.fillColor = "rgba(255, 255, 255,0.2)";
                lcdata.pointStrokeColor = "#fff";
                lcdata.pointHighlightFill = "#fff";
                lcdata.pointHighlightStroke = "rgba(151,187,205,1)";

                chart.datasets.Add(lcdata);
                index++;
            }
            return chart;
        }

        //[Authorize]
        //public ActionResult PatientBloodPressure(int PatientID)
        //{
        //    List<BloodPressureViewModel> lBP = new List<BloodPressureViewModel>();
        //    lBP = SP.Web_GetPatientPressureRecord(PatientID, 7);
        //    return View(lBP);
        //}
        #endregion

        //服藥紀錄
        public ActionResult PatientMedicalRecord(int PatientID)
        {
            List<MedicalRecordViewModel> lMR = new List<MedicalRecordViewModel>();
            lMR = SP.Web_GetPatientMedicineRecord(PatientID);
            return View(lMR);
        }

        // 紀錄
        public ActionResult Record(string RecordItem)
        {
            ViewData["RecordItem"] = RecordItem;
            return View();
        }

        // 新增紀錄
        public ActionResult RecordAdd(string RecordItem)
        {
            ViewData["RecordItem"] = RecordItem;
            return View();
        }

    }
}