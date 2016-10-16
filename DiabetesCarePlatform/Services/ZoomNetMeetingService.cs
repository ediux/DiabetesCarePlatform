using DiabetesCarePlatform.Helpers.JSON.Zoom;
using DiabetesCarePlatform.Helpers.ZoomSupports;
using DiabetesCarePlatform.Models.Datas;
using DiabetesCarePlatform.Models.DataTable;
using DiabetesCarePlatform.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using DiabetesCarePlatform.Models.ZoomNetMeeting;
using System.Text;
using DiabetesCarePlatform.Models.Common;

namespace DiabetesCarePlatform.Services
{
    public class ZoomNetMeetingService : Interfaces.IZoomNetMeetingService
    {

        private Common com;
        private UserInfo user;
        private DBRepository dbrepo;
        private ZoomNetMeetingRepository zoomroomrepo;
        private WorkShiftRepository workshiftrepo;
        private ZoomSetting setting;

        public ZoomNetMeetingService(ZoomNetMeetingRepository ZoomNetMeetingDAL, WorkShiftRepository WorkShiftDAl)
        {
            com = new Common();
            dbrepo = new DBRepository();
            user = new UserInfo();

            int UserId = 0;

            if (HttpContext.Current != null)
                UserId = HttpContext.Current.User.Identity.GetUserId<int>();

            string userkey = dbrepo.GetUserKeyById(UserId);

            if (!string.IsNullOrEmpty(userkey) || userkey != "null")
            {
                try
                {
                    user = com.QueryUserInfo(userkey);
                }
                catch
                {
                    user = new UserInfo();
                }
            }

            zoomroomrepo = ZoomNetMeetingDAL;
            workshiftrepo = WorkShiftDAl;

            setting = ZoomNetMeetingRepository.LoadZoomSettings();
        }

        private int GetUserId()
        {
            if (user !=null && user.ID.HasValue)
                return user.ID.Value;

            return 0;
        }
        public Helpers.JSON.Zoom.zoom_meeting_list GetMeetingListData(Controller ctr = null)
        {
            var result = zoomroomrepo.meeting_list(setting.HostId, page_size: setting.PageSize, page_number: 1);
            result.data.page_size = result.data.meetings.Count();
            result.data.page_number = 1;
            return result;
        }

        private bool CheckResponseForMeetingListIsSuccess(zoom_meeting_list response)
        {
            if (response == null)
                return false;

            if (response.code != "0")
                return false;

            return true;
        }

        public Models.Interfaces.IDataTableResultModel<Helpers.JSON.Zoom.meeting_list_data> ConvertedToPageList(DataTableParam Param)
        {
            DataTableResultModel<Helpers.JSON.Zoom.meeting_list_data> OutputData = new DataTableResultModel<Helpers.JSON.Zoom.meeting_list_data>();

            var result = zoomroomrepo.meeting_list(setting.HostId, 300, 1);
            OutputData.aaData = result.data.meetings.AsEnumerable();
            OutputData.iTotalRecords = result.data.page_count;
            OutputData.iTotalDisplayRecords = result.data.page_size * result.data.page_count;
            OutputData.sEcho = Param.sEcho;

            return OutputData;
        }

        public Models.Interfaces.IVideoSchedule_Index_ViewModel GetVideoMeetingScheduleDashboard(Controller ctr)
        {
            Models.Interfaces.IVideoSchedule_Index_ViewModel _model = new Models.ZoomNetMeeting.VideoSchedule_Index_ViewModel();

            DateTime _currDate = DateTime.Now;
            DateTime _start = new DateTime(_currDate.Year, _currDate.Month, 1);
            DateTime _end = _start.AddMonths(1).AddDays(-1);

            int userid = GetUserId();

            Models.Common.UserInfo currentUser = new Models.Common.UserInfo();

            ctr.ViewBag.IsHasNextSchedule = false;

            var result = workshiftrepo.Web_Get_VideoSchedule(userid);

            if (result.Any())
            {
                string UserKey = dbrepo.GetUserKeyById(userid);

                if (!string.IsNullOrEmpty(UserKey))
                {
                    UserKey = string.Empty;
                }

                _model.Schedules.AddRange(result.ToList().ConvertAll<Models.Common.FullCalendarEventObjectModel>(c =>
                    new Models.Common.FullCalendarEventObjectModel()
                {
                    id = "event_" + c.ShiftDate.AddTicks(c.StartTime.Ticks).ToString("yyyyMMddTHHmmss"),
                    backgroundColor = (c.CaseAmount > 0) ? "#FFAA33" : "#444444",
                    borderColor = (c.CaseAmount > 0) ? "#000000" : " #FF3333 ",
                    color = "#FFFFFF",
                    textColor = "#FFFFFF",
                    allDay = false,
                    title = workshiftrepo.SP_GetMR_MeetingRooms(c.room_id).Name,
                    start = c.ShiftDate.AddTicks(c.StartTime.Ticks).ToString("yyyy-MM-ddTHH:mm:ss.sssZ"),
                    editable = true,
                    startEditable = true,
                    durationEditable = false,
                    resourceEditable = false,
                    end = c.ShiftDate.AddTicks(c.EndTime.Ticks).ToString("yyyy-MM-ddTHH:mm:ss.sssZ"),
                    url = string.Format("javascript:confirm('開啟視訊軟體?') && window.open('{0}','_blank');", c.start_url),
                    extraData = new Models.Common.MeetingExtraEventData()
                    {
                        UserID = UserKey,
                        ShiftDate = _currDate.ToShortDateString(),
                        host_id = c.host_id,
                        room_id = 1,
                        uuid = c.uuid,
                        meeting_id = c.meet_id,
                        TimeSectionId = 1
                    }
                }));

                var lastdata = result.Where(w =>
                    w.UserID == userid
                    && w.ShiftDate >= _currDate
                    && w.StartTime >= _currDate.TimeOfDay)
                    .OrderBy(o => o.StartTime).FirstOrDefault();

                _model.NextSchedule = new Models.ZoomNetMeeting.Zoom_Meeting_ListItem_ViewModel();

                if (lastdata != null)
                {
                    _model.NextSchedule.Host_Id = lastdata.host_id;
                    _model.NextSchedule.Join_Url = lastdata.join_url;
                    _model.NextSchedule.Name = lastdata.topic;
                    _model.NextSchedule.Start_Url = lastdata.start_url;
                    _model.NextSchedule.StartTime = new DateTime(lastdata.ShiftDate.Year, lastdata.ShiftDate.Month, lastdata.ShiftDate.Day, lastdata.StartTime.Hours, lastdata.StartTime.Minutes, lastdata.StartTime.Seconds);
                    _model.NextSchedule.Duration = (lastdata.EndTime - lastdata.StartTime).Minutes;
                }

                ctr.ViewBag.IsHasNextSchedule = true;
            }

            var servicetimes = workshiftrepo.FN_GetMeetingRoomsRemainTable(DateTime.Now.Date);

            if (servicetimes.Any())
            {
                foreach (var item in servicetimes)
                {
                    _model.ServiceTimes.Add(Models.ZoomNetMeeting.ServiceTimeWithRemainRoomAmountViewModel.ConvertFrom(item));
                }
            }

            var rooms = workshiftrepo.SP_GetAllMR_MeetingRooms();

            if (rooms.Any())
            {
                _model.MeetingRooms.AddRange(rooms);
            }

            return _model;
        }

        public zoom_meeting_get GetSingleNetMeeting(Controller ctr, string hostid, string meeting_id)
        {
            return zoomroomrepo.meeting_get(meeting_id, hostid);
        }

        public Models.Interfaces.IVideoSchedule_Index_ViewModel CreateNetMeeting(Controller ctr, FormCollection collection)
        {
            //string Topic, DateTime? StartTime = null, int? Duration = null, int MeetingType = 1,
            //string TimeZone = "", string Password = "", bool OptionJBH = false,
            //string OptionStartType = "video", bool OptionHostVideo = true,
            //bool OptionParticipantsVideo = true, string OptionAudio = "both"

            //"Room " + timeseq, StartTime: selectdt, Duration: 60, MeetingType: 2
            string selecteddate = collection["selecteddate"];
            string dayofweek = collection["dayofweek"];
            string timeseq = collection["timeseq"];
            string[] MultiSelectTimeId;

            if (timeseq.Contains(','))
            {
                MultiSelectTimeId = timeseq.Split(',');
            }
            else
            {
                MultiSelectTimeId = new string[] { timeseq };
            }

            StringBuilder msgBuilder = new StringBuilder();
            var alltimes = workshiftrepo.SP_GetAllMR_MeetingRoomTimes();

            foreach (string timeid in MultiSelectTimeId)
            {
                try
                {
                    int seqnum = int.Parse(timeid);

                    DateTime selectdt = DateTime.Parse(selecteddate);
                    selectdt = new DateTime(selectdt.Year, selectdt.Month, selectdt.Day);

                    var timesection = alltimes.Where(w => w.TimeSectionId == seqnum).Single();

                    //TimeSpan starttime = TimeSpan.Parse(collection["starttime"]);
                    //TimeSpan endtime = TimeSpan.Parse(collection["endtime"]);

                    int duration = (timesection.EndTime - timesection.StartTime).Minutes;
                    string Topic = ctr.User.Identity.GetUserName();

                    if (string.IsNullOrEmpty(Topic))
                        Topic = "Anonymous";

                    var result = zoomroomrepo.meeting_create(setting.HostId, Topic, StartTime: selectdt, Duration: duration, MeetingType: 2);

                    if (result != null && result.code == "0")
                    {
                        var dbresult = workshiftrepo.Web_AddWorkShift(new Data.CG_WorkShift()
                        {
                            UserID = ctr.User.Identity.GetUserId<int>(),
                            DayOfWeek = int.Parse(dayofweek),
                            EndTime = timesection.EndTime,
                            LastUpdate = new DateTime(1900, 1, 1),
                            LastUserID = -1,
                            LimitNumber = 10,
                            ShiftDate = selectdt,
                            StartTime = timesection.StartTime
                        });

                        if (ctr.TempData.ContainsKey("state"))
                            ctr.TempData["state"] = "success";
                        else
                            ctr.TempData.Add("state", "success");

                        workshiftrepo.SP_AddMR_ZoomMeetings(new Data.MR_ZoomMeetings()
                        {
                            created_at = result.data.created_at,
                            duration = result.data.duration,
                            host_id = setting.HostId,
                            Id = result.data.id,
                            join_url = result.data.join_url,
                            option_audio = result.data.option_audio,
                            option_host_video = result.data.option_host_video,
                            option_jbh = result.data.option_jbh,
                            option_participants_video = result.data.option_particioants_video,
                            option_start_type = result.data.option_start_type,
                            password = result.data.password,
                            start_time = selectdt.AddTicks(timesection.StartTime.Ticks),
                            start_url = result.data.start_url,
                            timezone = result.data.timezone,
                            topic = result.data.topic,
                            type = result.data.type,
                            userid = ctr.User.Identity.GetUserId<int>(),
                            uuid = result.data.uuid
                        });
                    }
                    else
                    {
                        msgBuilder.Append("時段ID:" + timeid + " 會議建立失敗!");
                    }
                }
                catch (Exception ex)
                {
                    msgBuilder.Append(ex.Message);
                    continue;
                }

            }

            if (msgBuilder.Length > 0)
            {
                ctr.TempData["TmpErrMsg"] = msgBuilder.ToString();
            }


            return GetVideoMeetingScheduleDashboard(ctr);

        }

        public Models.Interfaces.IVideoSchedule_Index_ViewModel ModifyNetMeeting(Controller ctr, int room_Id, string uuid, string meeting_id, int TimeSectionId, int NewTimeSectionId, DateTime WorkShitfDate, DateTime NewWorkShiftDate, string UserId, string NewUserId)
        {
            int OriUserId = 0;
            int ModifyUserid = 0;

            if (!string.IsNullOrEmpty(UserId))
            {
                var userinfo = dbrepo.Web_GetUserInfo(UserId);
                OriUserId = userinfo.ID.Value;
            }

            if (!string.IsNullOrEmpty(NewUserId))
            {
                var userinfo = dbrepo.Web_GetUserInfo(NewUserId);
                ModifyUserid = userinfo.ID.Value;
            }

            Data.CG_WorkShift oriWorkshift = new Data.CG_WorkShift()
            {
                DayOfWeek = (int)WorkShitfDate.DayOfWeek,
                ShiftDate = WorkShitfDate,
                StartTime = WorkShitfDate.TimeOfDay,
                EndTime = WorkShitfDate.AddMinutes(60).TimeOfDay,
                UserID = OriUserId
            };

            Data.CG_WorkShift newWorkshift = new Data.CG_WorkShift()
            {
                DayOfWeek = (int)NewWorkShiftDate.DayOfWeek,
                ShiftDate = NewWorkShiftDate,
                StartTime = NewWorkShiftDate.TimeOfDay,
                EndTime = NewWorkShiftDate.AddMinutes(60).TimeOfDay,
                UserID = ModifyUserid
            };

            workshiftrepo.Web_ModifyWorkShift(oriWorkshift, newWorkshift, 0);
            return GetVideoMeetingScheduleDashboard(ctr);
        }


        /// <summary>
        /// 刪除會議室事件
        /// </summary>
        /// <param name="ctr"></param>
        /// <param name="room_Id"></param>
        /// <param name="uuid"></param>
        /// <param name="meeting_id"></param>
        /// <param name="TimeSectionId"></param>
        /// <param name="WorkShitfDate"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Models.Interfaces.IVideoSchedule_Index_ViewModel DeleteNetMeeting(Controller ctr, int room_Id,
    string uuid,
    string meeting_id,
    int TimeSectionId,
    DateTime WorkShitfDate,
    string UserId)
        {
            int iUserId = 0;

            if (!string.IsNullOrEmpty(UserId))
            {
                var userinfo = dbrepo.Web_GetUserInfo(UserId);
                iUserId = userinfo.ID.Value;
            }

            workshiftrepo.SP_DeleteMR_MeetingRoomAssigned(room_Id, uuid, meeting_id, TimeSectionId, WorkShitfDate, iUserId);
            var rtn = zoomroomrepo.meeting_delete(meeting_id, setting.HostId);
            if (rtn.code != "0")
            {
                throw new Exception(rtn.message);
            }
            return GetVideoMeetingScheduleDashboard(ctr);
        }

        public IEnumerable<MeetingRoomViewModel> GetAllMeetingRooms()
        {
            return workshiftrepo.SP_GetAllMR_MeetingRooms().Select(s => new MeetingRoomViewModel() { Id = s.Id, Name = s.Name });
        }

        public IEnumerable<MeetingRoomViewModel> CreateNewMeetingRoom(string NewRoomName)
        {
            return workshiftrepo.SP_AddMR_MeetingRooms(NewRoomName).Select(s => new MeetingRoomViewModel() { Id = s.Id, Name = s.Name });
        }

        public MeetingRoomWithServiceTimesViewModel GetMeetingRoom(int RoomId)
        {
            MeetingRoomWithServiceTimesViewModel model = new MeetingRoomWithServiceTimesViewModel();
            var result = workshiftrepo.SP_GetMR_MeetingRooms(RoomId);
            if (result != null)
            {
                model.Id = result.Id;
                model.Name = result.Name;
            }
            var servicetimesresult = workshiftrepo.SP_GetAllMR_MeetingRoomTimes();

            if (servicetimesresult.Any())
            {
                model.ServiceTimes.AddRange(workshiftrepo.SP_GetMR_MeetingRoomTimeAssigened(model.Id).Select(s => new ServiceTimeViewModel()
                {
                    TimeSectionId = s.TimeSectionId,
                    EndTime = s.EndTime,
                    StartTime = s.StartTime
                }));
            }

            //model.ServiceTimes.AddRange(workshiftrepo.)
            return model;
        }


        public IEnumerable<ServiceTimeViewModel> GetAllServiceTime()
        {
            return workshiftrepo.SP_GetAllMR_MeetingRoomTimes().Select(s => new ServiceTimeViewModel() { EndTime = s.EndTime, StartTime = s.StartTime, TimeSectionId = s.TimeSectionId });
        }


        public void CreateServiceTime(string StartTime, string EndTime)
        {
            workshiftrepo.SP_AddMR_MeetingRoomTime(TimeSpan.Parse(StartTime), TimeSpan.Parse(EndTime));
        }


        public void DeleteServiceTime(int TimeSectionId)
        {
            workshiftrepo.SP_DeleteMR_MeetingRoomTime(TimeSectionId);
        }


        public MeetingRoomViewModel UpdateMeetingRoom(int RoomId, string Name)
        {
            var result = workshiftrepo.SP_UpdateMR_MeetingRooms(new Data.MR_MeetingRooms() { Id = RoomId, Name = Name });

            if (result != null)
            {
                var rtn = new MeetingRoomViewModel() { Id = RoomId, Name = Name };
                return rtn;
            }

            return null;
        }

        public void DeleteMeetingRoom(int RoomId)
        {
            workshiftrepo.SP_DeleteMR_MeetingRooms(RoomId);
        }

        public ManageMeetingRoomTimeAssignViewModel GetAssignedTimeByRoom(int room)
        {

            var model = new ManageMeetingRoomTimeAssignViewModel();

            var roominfo = workshiftrepo.SP_GetMR_MeetingRooms(room);

            if (roominfo == null)
                throw new ArgumentException("指定房間不存在!", "room");

            model.Room = new MeetingRoomViewModel() { Id = roominfo.Id, Name = roominfo.Name };

            var result = workshiftrepo.SP_GetMR_MeetingRoomTimeAssigened(room);

            model.AssignedTimes = new List<AssignedTimeViewModel>(result.Select(s => new AssignedTimeViewModel()
            {
                TimeSectionId = s.TimeSectionId,
                DayofWeek = s.DayOfWeek,
                EndTime = s.EndTime,
                StartTime = s.StartTime
            }));

            model.ServiceTimes = workshiftrepo.SP_GetAllMR_MeetingRoomTimes().Select(s => new ServiceTimeViewModel()
            {
                TimeSectionId = s.TimeSectionId,
                StartTime = s.StartTime,
                EndTime = s.EndTime
            }).ToList();

            return model;
        }


        public void AssignTimeToRoom(ManageMeetingRoomTimeAssignViewModel assign)
        {
            foreach (var assignvalue in assign.AssignedTimes)
            {
                workshiftrepo.SP_AddMR_MeetingRoomTimeAssigened(assign.Room.Id, assignvalue.TimeSectionId, assignvalue.DayofWeek);
            }
        }

        public void UnAssignTimeFromRoom(ManageMeetingRoomTimeAssignViewModel unassign)
        {
            foreach (var unassignvalue in unassign.AssignedTimes)
            {
                workshiftrepo.SP_AddMR_MeetingRoomTimeAssigened(unassign.Room.Id, unassignvalue.TimeSectionId, unassignvalue.DayofWeek);
            }
        }


        public List<AssignedTimeViewModel> GetAllAssignedTime()
        {
            return workshiftrepo.SP_GetAllMR_MeetingRoomTimeAssigened().Select(s => new AssignedTimeViewModel()
              {
                  TimeSectionId = s.TimeSectionId,
                  DayofWeek = s.DayOfWeek,
                  EndTime = s.EndTime,
                  StartTime = s.StartTime
              }).ToList();
        }


        public IEnumerable<ServiceTimeWithRemainRoomAmountViewModel> GetMeetingRoomsRemainTable(DateTime shiftdate)
        {
            var servicetimes = workshiftrepo.FN_GetMeetingRoomsRemainTable(shiftdate);

            return servicetimes.Select(s => new ServiceTimeWithRemainRoomAmountViewModel()
            {
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                RemainAmount = s.RemainAmount,
                TimeSectionId = s.TimeSectionId
            });
        }


        public int GetTimeSectionIdByStartTime(TimeSpan Start, int Duration = 60)
        {
            int New_TimeSectionId = -1;

            var query_result = GetAllServiceTime().Where(w => w.StartTime == Start);

            if (query_result.Any())
            {
                try
                {
                    New_TimeSectionId = query_result.Single().TimeSectionId;
                }
                catch
                {
                    var filiterbyendtime = query_result.Where(w => w.EndTime == Start.Add(new TimeSpan(0, Duration, 0)));

                    try
                    {
                        New_TimeSectionId = filiterbyendtime.Single().TimeSectionId;
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return New_TimeSectionId;
        }


        public int GetUserIdByKey(string UserKey)
        {
            if (string.IsNullOrEmpty(UserKey))
                return 0;

            var rtn = dbrepo.Web_GetUserInfo(UserKey);
            return rtn.ID.HasValue ? rtn.ID.Value : 0;
        }
    }
}