using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiabetesCarePlatform.Data;

namespace DiabetesCarePlatform.Repository
{
    public class WorkShiftRepository
    {
        private DB_Dapper Dap;

        public WorkShiftRepository()
        {
            Dap = new DB_Dapper();
        }

        #region 會議室預約時段資料表存取
        /// <summary>
        /// 新增會議室可預約時段基本資訊。
        /// </summary>
        /// <param name="starttime">預約起始時間</param>
        /// <param name="endtime">預約結束時間</param>
        /// <returns>傳回已建立的預約時段</returns>
        public IEnumerable<MR_MeetingRoomTimes> SP_AddMR_MeetingRoomTime(TimeSpan starttime, TimeSpan endtime)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@starttime", starttime);
            param.Add("@endtime", endtime);

            return Dap.ModelListSP<MR_MeetingRoomTimes>("SP_AddMR_MeetingRoomTime", param);
        }

        public void SP_DeleteMR_MeetingRoomTime(int TimeSectionId)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@timespanid", TimeSectionId);

            Dap.NonQuerySP("SP_DeleteMR_MeetingRoomTime", param);
        }

        public IEnumerable<FN_GetMeetingRoomsRemainTableResult> FN_GetMeetingRoomsRemainTable(DateTime ShiftDate)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@shiftdate", ShiftDate);

            return Dap.QueryList<FN_GetMeetingRoomsRemainTableResult>("Select * From FN_GetMeetingRoomsRemainTable(@shiftdate)", param);
        }

        public IEnumerable<MR_MeetingRoomTimes> SP_GetAllMR_MeetingRoomTimes()
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            return Dap.ModelListSP<MR_MeetingRoomTimes>("SP_GetAllMR_MeetingRoomTimes", param);
        }

        public MR_MeetingRoomTimeAssigened SP_AddMR_MeetingRoomTimeAssigened(int RoomId, int TimeSectionId, int DayofWeek)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("@roomid", RoomId);
            param.Add("@TimeSectionId", TimeSectionId);
            param.Add("@DayofWeek", DayofWeek);
            return Dap.ModelListSP<MR_MeetingRoomTimeAssigened>("SP_AddMR_MeetingRoomTimeAssigened", param).FirstOrDefault();
        }

        public void SP_DeleteMR_MeetingRoomTimeAssigened(int RoomId, int TimeSectionId, int DayofWeek)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@roomid", RoomId);
            param.Add("@TimeSectionId", TimeSectionId);
            param.Add("@DayofWeek", DayofWeek);

            Dap.NonQuerySP("SP_DeleteMR_MeetingRoomTimeAssigened", param);
        }

        public IEnumerable<SP_GetMR_MeetingRoomTimeAssigenedResult> SP_GetMR_MeetingRoomTimeAssigened(int RoomId)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("@roomid", RoomId);

            return Dap.ModelListSP<SP_GetMR_MeetingRoomTimeAssigenedResult>("SP_GetMR_MeetingRoomTimeAssigened", param);
        }

        public IEnumerable<SP_GetMR_MeetingRoomTimeAssigenedResult> SP_GetAllMR_MeetingRoomTimeAssigened()
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            return Dap.ModelListSP<SP_GetMR_MeetingRoomTimeAssigenedResult>("SP_GetAllMR_MeetingRoomTimeAssigened", param);
        }

        #endregion

        #region 會議室基本資料表存取
        public MR_MeetingRooms SP_GetMR_MeetingRooms(int RoomId)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@roomid", RoomId);

            return Dap.ModelListSP<MR_MeetingRooms>("SP_GetMR_MeetingRooms", param).FirstOrDefault();
        }
        public IEnumerable<MR_MeetingRooms> SP_GetAllMR_MeetingRooms()
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            return Dap.ModelListSP<MR_MeetingRooms>("SP_GetAllMR_MeetingRooms", param);
        }

        public void SP_DeleteMR_MeetingRooms(int RoomId)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@roomid", RoomId);

            Dap.NonQuerySP("SP_DeleteMR_MeetingRooms", param);
        }

        public IEnumerable<MR_MeetingRooms> SP_AddMR_MeetingRooms(string RoomName)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@roomname", RoomName);

            return Dap.ModelListSP<MR_MeetingRooms>("SP_AddMR_MeetingRooms", param);
        }

        public int FN_GetIdByName_MR_MeetingRooms(string name)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@name", name);

            return Dap.ModelListSP<int>("FN_GetIdByName_MR_MeetingRooms", param).FirstOrDefault();
        }
        public int FN_GetIdByTime_MR_MeetingRoomTimes(TimeSpan StartTime, TimeSpan EndTime)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@starttime", StartTime);
            param.Add("@endtime", EndTime);

            return Dap.ModelListSP<int>("FN_GetIdByTime_MR_MeetingRoomTimes", param).FirstOrDefault();
        }

        public MR_MeetingRooms SP_UpdateMR_MeetingRooms(MR_MeetingRooms updaterow)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@roomid", updaterow.Id);
            param.Add("@newname", updaterow.Name);

            return Dap.ModelListSP<MR_MeetingRooms>("SP_UpdateMR_MeetingRooms", param).FirstOrDefault();
        }

        public void SP_DeleteMR_MeetingRoomAssigned(int room_Id, string uuid, string meeting_id, int TimeSectionId, DateTime WorkShitfDate, int UserId)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@room_Id", room_Id);
            param.Add("@uuid", uuid);
            param.Add("@meeting_id", meeting_id);
            param.Add("@TimeSectionId", TimeSectionId);
            param.Add("@WorkShitfDate", WorkShitfDate);
            param.Add("@UserId", UserId);

            Dap.NonQuerySP("SP_DeleteMR_MeetingRoomAssigned", param);
        }
        #endregion

        #region 視訊排程(排班)相關
        public IEnumerable<CG_WorkShift> SP_AddCG_WorkShift(int userid, DateTime shiftdate, TimeSpan starttime, TimeSpan endtime, int dayofweek, int LimitNumber = 10)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("@userid", userid);
            param.Add("@shiftdate", shiftdate);
            param.Add("@dayofweek", dayofweek);
            param.Add("@starttime", starttime);
            param.Add("@endtime", endtime);
            param.Add("@LimitNumber", LimitNumber);
            return Dap.ModelListSP<CG_WorkShift>("SP_AddCG_WorkShift", param);
        }

        public IEnumerable<CG_WorkShiftBase> SP_AddCG_WorkShiftBase(int userid, int dayofweek, TimeSpan starttime, TimeSpan endtime, int limitnumber = 10)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("@userid", userid);
            param.Add("@dayofweek", dayofweek);
            param.Add("@starttime", starttime);
            param.Add("@endtime", endtime);
            param.Add("@limitnumber", limitnumber);
            return Dap.ModelListSP<CG_WorkShiftBase>("SP_AddCG_WorkShiftBase", param);
        }

        public IEnumerable<SYS_Holiday> SP_AddSYS_Holiday(DateTime HolidayDate, string desc, bool IsHoliday)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@HolidayDate", HolidayDate);
            param.Add("@desc", desc);
            param.Add("@IsHoliday", IsHoliday);

            return Dap.ModelListSP<SYS_Holiday>("SP_AddSYS_Holiday", param);
        }

        /// <summary>
        /// 取得目前班表(全部,依時間區間)
        /// </summary>
        /// <param name="start">開始時間</param>
        /// <param name="end">結束時間</param>
        /// <returns></returns>
        public IEnumerable<Web_Get_VideoScheduleResult> Web_Get_VideoSchedule(int UserId)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("@userid", UserId);
            return Dap.ModelListSP<Web_Get_VideoScheduleResult>("Web_Get_VideoSchedule", param);
        }

        public IEnumerable<CG_WorkShift> Web_AddWorkShift(CG_WorkShift newworkshift, int roomlimit = 10)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@userid", newworkshift.UserID);
            param.Add("@dayofweek", newworkshift.DayOfWeek);
            param.Add("@shiftdate", newworkshift.ShiftDate);
            param.Add("@starttime", newworkshift.StartTime);
            param.Add("@endtime", newworkshift.EndTime);
            param.Add("@limitnumber", newworkshift.LimitNumber);
            param.Add("@roomlimit", roomlimit);

            return Dap.ModelListSP<CG_WorkShift>("Web_AddWorkShift", param);
        }

        public IEnumerable<CG_WorkShift> Web_ModifyWorkShift(CG_WorkShift Original, CG_WorkShift uTarget, int logineduserid)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@userid", Original.UserID);
            param.Add("@orishiftdate", Original.ShiftDate);
            param.Add("@oridayofweek", Original.DayOfWeek);
            param.Add("@oristarttime", Original.StartTime);
            param.Add("@oriendtime", Original.EndTime);
            param.Add("@modifyuserid", uTarget.UserID);
            param.Add("@modifyshiftdate", uTarget.ShiftDate);
            param.Add("@modifydayofweek", uTarget.DayOfWeek);
            param.Add("@modifystarttime", uTarget.StartTime);
            param.Add("@modifyendtime", uTarget.EndTime);
            param.Add("@limituser", Original.LimitNumber);
            param.Add("@logineduserid", logineduserid);

            return Dap.ModelListSP<CG_WorkShift>("Web_ModifyWorkShift", param);
        }

        public int FN_GetMeetingRoomAppointmentAmounts(int RoomId, DateTime shiftdate, TimeSpan starttime)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("@room_id", RoomId);
            param.Add("@shiftdate", shiftdate);
            param.Add("@starttime", starttime);

            return Dap.ModelListSP<int>("FN_GetMeetingRoomAppointmentAmounts", param).FirstOrDefault();
        }
        public int FN_GetRemainMeetingRoomAmount(DateTime ShiftDate, int DayOfWeek, TimeSpan start, TimeSpan end)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@shiftdate", ShiftDate);
            //param.Add("@dayofweek", DayOfWeek);
            param.Add("@starttime", start);
            param.Add("@endtime", end);

            int limitroomcount = Dap.NonQuerySP("FN_GetRemainMeetingRoomAmount", param);
            return limitroomcount;
        }

        #endregion

        #region 取得Zoom平台上的視訊會議表格(緩衝用)
        public IEnumerable<MR_ZoomMeetings> SP_AddMR_ZoomMeetings(MR_ZoomMeetings newdata)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            if (newdata.start_time.HasValue == false)
                newdata.start_time = new DateTime(1900, 1, 1);

            param.Add("@id", newdata.Id);
            param.Add("@uuid", newdata.uuid);
            param.Add("@host_id", newdata.host_id);
            param.Add("@topic", newdata.topic);
            param.Add("@type", newdata.type);
            param.Add("@userid", newdata.userid);
            param.Add("@created_at", newdata.created_at);
            param.Add("@start_url", newdata.start_url);
            param.Add("@join_url", newdata.join_url);
            param.Add("@start_time", newdata.start_time);
            param.Add("@timezone", newdata.timezone);
            param.Add("@password", newdata.password);
            param.Add("@duration", newdata.duration);
            param.Add("@option_jbh", newdata.option_jbh);
            param.Add("@option_start_type", newdata.option_start_type);
            param.Add("@option_host_video", newdata.option_host_video);
            param.Add("@option_participants_video", newdata.option_participants_video);
            param.Add("@option_audio", newdata.option_audio);

            return Dap.ModelListSP<MR_ZoomMeetings>("SP_AddMR_ZoomMeetings", param);
        }

        public IEnumerable<MR_ZoomMeetings> SP_GetMR_ZoomMeetings(int userid, DateTime starttime)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();

            param.Add("@userid", userid);
            param.Add("@starttime", starttime);

            return Dap.ModelListSP<MR_ZoomMeetings>("SP_GetMR_ZoomMeetings", param);
        }

        public IEnumerable<MR_ZoomMeetings> SP_GetAllSYS_ZoomMeetings()
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            return Dap.ModelListSP<MR_ZoomMeetings>("SP_GetAllMR_ZoomMeetings", param);
        }

        public void SP_DeleteMR_ZoomMeetings(MR_ZoomMeetings deletedata)
        {
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("@id", deletedata.Id);
            param.Add("@uuid", deletedata.uuid);
            param.Add("@host_id", deletedata.host_id);
            param.Add("@userid", deletedata.userid);
            Dap.NonQuerySP("SP_DeleteMR_ZoomMeetings", param);
        }
        #endregion

    }
}