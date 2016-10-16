using DiabetesCarePlatform.Helpers.JSON.Zoom;
using DiabetesCarePlatform.Models.Datas;
using DiabetesCarePlatform.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiabetesCarePlatform.Helpers.ZoomSupports;
using DiabetesCarePlatform.Models.Interfaces;
using DiabetesCarePlatform.Models.ZoomNetMeeting;
using DiabetesCarePlatform.Helpers.MVCExtras;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
namespace DiabetesCarePlatform.Controllers
{
    public class VideoScheduleController : Controller
    {

        private Services.Interfaces.IZoomNetMeetingService zoomnetmeetingservice;

        public VideoScheduleController(Services.Interfaces.IZoomNetMeetingService ZoomNetMeetingService)
        {
            zoomnetmeetingservice = ZoomNetMeetingService;
        }

        #region Page: Index
        // GET: VideoSchedule
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index()
        {
            try
            {
                var model = zoomnetmeetingservice.GetVideoMeetingScheduleDashboard(this);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }

        #region 會議室預約
        /// <summary>
        /// 建立會議預約
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [OutputCache(NoStore = true, Duration = 0)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                //建立會議預約
                var model = zoomnetmeetingservice.CreateNetMeeting(this, collection);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
                return RedirectToAction("Index");
            }


        }
        #endregion

        #region 會議預約修改(非日曆控件AJAX處理)
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult ModifyMeetingEventDialog(string eventid, string UserKey)
        {
            try
            {
                int UserId = 0;

                if (!string.IsNullOrEmpty(UserKey))
                    UserId = zoomnetmeetingservice.GetUserIdByKey(UserKey);

                var result = zoomnetmeetingservice.GetVideoMeetingScheduleDashboard(this);
                if (!result.Schedules.Any())
                {
                    TempData["TmpErrMsg"] = "找不到此事件!";
                    return RedirectToAction("Index");
                }
                var eventdata = result.Schedules.Where(w => w.id == eventid).Distinct().First();

                if (eventdata == null)
                {
                    TempData["TmpErrMsg"] = "找不到此預約資料!";
                    return RedirectToAction("Index");
                }
                DateTime shiftdt = DateTime.Parse(eventdata.extraData.ShiftDate);

                ViewBag.DW = (int)shiftdt.DayOfWeek;

                return PartialView("ModifyMeetingEvent", eventdata);
            }
            catch (Exception ex)
            {
                TempData["TmpErrMsg"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult ModifyMeetingEventDialog(FormCollection collection)
        {
            try
            {
                string ShiftDate = collection["ShiftDate"];
                string NewShiftDate = collection["NewShiftDate"];
                string s_roomid = collection["roomid"];
                string uuid = collection["uuid"];
                string meetingid = collection["meetingid"];
                string s_TimeSectionId = collection["TimeSectionId"];
                string s_New_TimeSectionId = collection["NewTimeSectionId"];
                string UserId = collection["UserKey"];
                string NewUserId = UserId;

                int RoomId = int.Parse(s_roomid);
                int TimeSectionId = int.Parse(s_TimeSectionId);
                int NewTimeSectionId = int.Parse(s_New_TimeSectionId);

                var times = zoomnetmeetingservice.GetAllServiceTime();
                TimeSpan OriStartTime = times.Where(w => w.TimeSectionId == TimeSectionId).Select(s => s.StartTime).SingleOrDefault();
                TimeSpan NewStartTime = times.Where(w => w.TimeSectionId == NewTimeSectionId).Select(s => s.StartTime).SingleOrDefault();

                DateTime dtShiftDate = DateTime.Parse(ShiftDate);
                dtShiftDate = dtShiftDate.AddTicks(OriStartTime.Ticks);

                DateTime dtNewShiftDate = DateTime.Parse(NewShiftDate);
                dtNewShiftDate = dtNewShiftDate.AddTicks(NewStartTime.Ticks);

                TimeSpan Start = dtNewShiftDate.TimeOfDay;

                int New_TimeSectionId = int.Parse(s_New_TimeSectionId);

                zoomnetmeetingservice.ModifyNetMeeting(this, RoomId, uuid, meetingid, TimeSectionId, New_TimeSectionId, dtShiftDate, dtNewShiftDate, UserId, NewUserId);
                //修改日期

            }
            catch (Exception ex)
            {
                //修改日期
                TempData["TmpErrMsg"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region 動態取得服務時段
        public ActionResult DynamicFetchServiceTimes(string shiftdate)
        {
            DateTime date = DateTime.Parse(shiftdate);
            var model = zoomnetmeetingservice.GetMeetingRoomsRemainTable(date);
            return PartialView(model);
        }

        public ActionResult DynamicFetchServiceTimesDropDownList(int DayOfWeek)
        {
            var model = zoomnetmeetingservice.GetAllAssignedTime()
                    .Where(w => w.DayofWeek == (DayOfWeek + 1));

            return PartialView(model);
        }
        #endregion

        #region 新增預約事件對話框
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult GetDayofWeekRemains(string date, bool isStaticLabel)
        {
            DateTime currentDayOfWeek = DateTime.Parse(date);
            ViewBag.DayOfWeek = (int)currentDayOfWeek.DayOfWeek;
            ViewBag.ShiftDate = currentDayOfWeek;
            ViewBag.Static = isStaticLabel;

            var servicetimes = zoomnetmeetingservice.GetMeetingRoomsRemainTable(currentDayOfWeek);

            //return PartialView("_GuestbookTop1Data", guestbook);
            //限定同網站的Ajax專用
            if (Request.IsAjaxRequest())
            {
                return PartialView("_GetDayofWeekRemains", servicetimes);
            }
            else
            {
                return Content("Fail");
            }
        }
        #endregion

        #region fullcalendar 滑鼠右鍵選單事件對應處理(AJAX)

        #region 修改會議事件
        /// <summary>
        /// 修改會議室預約事件內容
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="hostid"></param>
        /// <param name="RoomId"></param>
        /// <param name="uuid"></param>
        /// <param name="meetingid"></param>
        /// <param name="ShiftDate"></param>
        /// <param name="TimeSectionId"></param>
        /// <param name="NewUserId"></param>
        /// <param name="delta"></param>
        /// <param name="ReturnUrl"></param>
        /// <returns></returns>
        [AjaxValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult ModifyMeetingEvent(string UserId, string hostid, int RoomId, string uuid, string meetingid, string ShiftDate, int TimeSectionId, string NewUserId, string delta, string ReturnUrl)
        {
            //修改視訊會議時間(AJAX)

            try
            {
                //FormCollection collection = new FormCollection();
                //collection.Add("date", date);
                //collection.Add("ReturnUrl", ReturnUrl);
                DateTime dtShiftDate = DateTime.Parse(ShiftDate);
                DateTime dtNewShiftDate = dtShiftDate.AddSeconds(double.Parse(delta));

                TimeSpan Start = dtNewShiftDate.TimeOfDay;
                //TimeSpan End = Start.Add(new TimeSpan(0, 60, 0));

                //int New_TimeSectionId = zoomnetmeetingservice.GetAllServiceTime().Where(w => w.StartTime == Start).Select(s => s.TimeSectionId).SingleOrDefault();
                int New_TimeSectionId = zoomnetmeetingservice.GetTimeSectionIdByStartTime(Start);

                zoomnetmeetingservice.ModifyNetMeeting(this, RoomId, uuid, meetingid, TimeSectionId, New_TimeSectionId, dtShiftDate.Date, dtNewShiftDate.Date, UserId, NewUserId);
                //修改日期
                return Json(new { Success = true, Message = "" }, "application/json", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //修改日期
                return Json(new { Success = false, Message = ex.Message }, "application/json", JsonRequestBehavior.AllowGet);
            }

        }

        #endregion

        #region 刪除會議事件
        /// <summary>
        /// 刪除(取消)預約
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="hostid"></param>
        /// <param name="RoomId"></param>
        /// <param name="uuid"></param>
        /// <param name="meetingid"></param>
        /// <param name="ShiftDate"></param>
        /// <param name="TimeSectionId"></param>
        /// <param name="ReturnUrl"></param>
        /// <returns></returns>
        [AjaxValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult DeleteMeetingEvent(string UserId, string hostid, int RoomId, string uuid, string meetingid, string ShiftDate, int TimeSectionId, string ReturnUrl)
        {
            //刪除指定會議事件
            try
            {
                zoomnetmeetingservice.DeleteNetMeeting(this, RoomId, uuid, meetingid, TimeSectionId, DateTime.Parse(ShiftDate), UserId);

                return Json(new { Success = true }, "application/json", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, "application/json", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region 代班
        //指定代理人
        public ActionResult AddAgentEvent(string ReturnUrl)
        {
            return PartialView();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddAgentEvent(FormCollection collection)
        {
            // zoomnetmeetingservice.ModifyNetMeeting(this, collection);
            return PartialView();
        }
        #endregion
        #endregion

        #endregion

        #region Page:管理會議室
        public ActionResult ManageMeetingRoom(string ReturnUrl)
        {
            if (string.IsNullOrEmpty(ReturnUrl))
                ViewBag.returnUrl = Url.Action("Index");
            else
            {
                if (ReturnUrl.Replace(Request.Path, "").Trim() == "")
                {
                    ViewBag.returnUrl = Url.Action("Index");
                }
                else
                {
                    ViewBag.returnUrl = ReturnUrl;
                }
            }

            return View(zoomnetmeetingservice.GetAllMeetingRooms());
        }

        #region 新增會議室
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageMeetingRoom(FormCollection collection)
        {
            string url = collection["returnurl"];

            if (string.IsNullOrEmpty(url))
            {
                url = Request.Path;
            }

            string newname = collection["roomname"];

            zoomnetmeetingservice.CreateNewMeetingRoom(newname);

            return RedirectToAction("ManageMeetingRoom", new { ReturnUrl = url });
        }
        #endregion

        #region 編輯會議室
        public ActionResult EditMeetingRoom(int RoomId)
        {
            var model = zoomnetmeetingservice.GetMeetingRoom(RoomId);
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditMeetingRoom(FormCollection collection)
        {
            string url = collection["returnurl"];

            if (string.IsNullOrEmpty(url))
            {
                url = Request.Path;
            }
            int roomid = int.Parse(collection["roomid"]);
            string newname = collection["roomname"];

            zoomnetmeetingservice.UpdateMeetingRoom(roomid, newname);

            return RedirectToAction("ManageMeetingRoom", new { ReturnUrl = url });
        }
        #endregion

        #region 刪除會議室
        [AjaxValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult DeleteMeetingRoom(int RoomId)
        {
            try
            {
                zoomnetmeetingservice.DeleteMeetingRoom(RoomId);
                return Json(new { Success = true }, "application/json", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, "application/json", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #endregion

        #region Page:管理服務時段
        public ActionResult ManageServiceTimes(string ReturnUrl)
        {
            if (string.IsNullOrEmpty(ReturnUrl))
                ViewBag.returnUrl = Url.Action("Index");
            else
            {
                if (ReturnUrl.Replace(Request.Path, "").Trim() == "")
                {
                    ViewBag.returnUrl = Url.Action("Index");
                }
                else
                {
                    ViewBag.returnUrl = ReturnUrl;
                }
            }

            var model = zoomnetmeetingservice.GetAllServiceTime();
            return View(model);
        }

        #region 加入服務時段
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddServiceTime(FormCollection collection)
        {
            zoomnetmeetingservice.CreateServiceTime(collection["starttime"], collection["endtim"]);

            return RedirectToAction("ManageServiceTimes", new { ReturnUrl = collection["returnurl"] });
        }
        #endregion

        #region 刪除服務時段
        [AjaxValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult DeleteServiceTime(int TimeSectionId)
        {
            try
            {
                zoomnetmeetingservice.DeleteServiceTime(TimeSectionId);
                return Json(new { Success = true }, "application/json", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, "application/json", JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #endregion

        #region Page:管理會議室指派的服務時間功能

        public ActionResult ManageMeetingRoomTimeAssign(int roomid, string ReturnUrl)
        {
            if (string.IsNullOrEmpty(ReturnUrl))
                ViewBag.returnUrl = Url.Action("Index");
            else
            {
                if (ReturnUrl.Replace(Request.Path, "").Trim() == "")
                {
                    ViewBag.returnUrl = Url.Action("Index");
                }
                else
                {
                    ViewBag.returnUrl = ReturnUrl;
                }
            }

            ViewBag.AllServiceTime = zoomnetmeetingservice.GetAllServiceTime();

            ManageMeetingRoomTimeAssignViewModel model = new ManageMeetingRoomTimeAssignViewModel();

            model = zoomnetmeetingservice.GetAssignedTimeByRoom(roomid);

            return View(model);
        }

        #region 新增會議室服務時段指定
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageMeetingRoomTimeAssign(FormCollection collection)
        {
            ManageMeetingRoomTimeAssignViewModel model = new ManageMeetingRoomTimeAssignViewModel();

            string dayofweek = collection["DayofWeek"];
            string[] selecteddayofweeks = null;

            if (dayofweek.Contains(','))
            {
                selecteddayofweeks = dayofweek.Split(',');
            }
            else
            {
                selecteddayofweeks = new string[] { };

                if (!string.IsNullOrEmpty(dayofweek))
                {
                    selecteddayofweeks = new string[] { dayofweek };
                }
            }

            if (selecteddayofweeks.Length > 0)
            {
                model.AssignedTimes.AddRange(
                    selecteddayofweeks.Select(s => new AssignedTimeViewModel()
                    {
                        DayofWeek = int.Parse(s),
                        TimeSectionId = int.Parse(collection["TimeSectionId"])
                    }));
            }

            model.Room.Id = int.Parse(collection["roomid"]);
            zoomnetmeetingservice.AssignTimeToRoom(model);

            return RedirectToAction("ManageMeetingRoomTimeAssign", new
            {
                roomid = model.Room.Id,
                ReturnUrl = collection["returnurl"]
            });
        }
        #endregion

        #region 刪除會議室服務時段指定
        [AjaxValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult DeleteServiceTimeAssigned(int RoomId, int TimeSectionId, int DayofWeek)
        {
            try
            {
                var param = new ManageMeetingRoomTimeAssignViewModel()
                {
                    Room = new MeetingRoomViewModel() { Id = RoomId },
                    AssignedTimes = new List<AssignedTimeViewModel>()
                };

                param.AssignedTimes.Add(new AssignedTimeViewModel() { TimeSectionId = TimeSectionId, DayofWeek = DayofWeek });

                zoomnetmeetingservice.UnAssignTimeFromRoom(param);
                return Json(new { Success = true }, "application/json", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, "application/json", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
        #endregion

        #region Helper Functions
        private static bool CheckIsMeetingStart(DateTime isstartuptime, DateTime isendtime, meeting_list_data item)
        {
            bool isSuccess_L = false;
            bool isSuccess_R = false;

            DateTime co_createtime = item.created_at.AddHours(-8);

            isSuccess_L = (co_createtime >= isstartuptime && co_createtime <= isendtime);

            isSuccess_R = item.start_time.HasValue;

            DateTime copydt;

            if (isSuccess_R)
            {
                copydt = item.start_time.Value.AddHours(-8);

                isSuccess_R = isSuccess_R && (copydt >= isstartuptime);
                isSuccess_R = isSuccess_R && (copydt <= isendtime);
            }




            return isSuccess_L || isSuccess_R;
        }
        #endregion
    }
}