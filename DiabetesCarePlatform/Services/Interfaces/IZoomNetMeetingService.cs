using DiabetesCarePlatform.Helpers.JSON.Zoom;
using DiabetesCarePlatform.Models.Datas;
using DiabetesCarePlatform.Models.Interfaces;
using DiabetesCarePlatform.Models.ZoomNetMeeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DiabetesCarePlatform.Services.Interfaces
{
    public interface IZoomNetMeetingService
    {
        #region Zoom會議平台相關
        Models.Interfaces.IVideoSchedule_Index_ViewModel GetVideoMeetingScheduleDashboard(Controller ctr);

        Models.Interfaces.IVideoSchedule_Index_ViewModel CreateNetMeeting(Controller ctr, FormCollection collection);

        Models.Interfaces.IVideoSchedule_Index_ViewModel DeleteNetMeeting(Controller ctr, int room_Id,string uuid, string meeting_id, int TimeSectionId, DateTime WorkShitfDate, string UserId);

        Models.Interfaces.IVideoSchedule_Index_ViewModel ModifyNetMeeting( Controller ctr, int room_Id, string uuid, string meeting_id, int TimeSectionId,int NewTimeSectionId, DateTime WorkShitfDate,DateTime NewWorkShiftDate, string UserId,string NewUserId);

        zoom_meeting_get GetSingleNetMeeting(Controller ctr, string hostid, string meeting_id);

        zoom_meeting_list GetMeetingListData(Controller ctr = null);

        IDataTableResultModel<meeting_list_data> ConvertedToPageList(DataTableParam Param);
        #endregion

        #region 操作會議室定義類
        IEnumerable<MeetingRoomViewModel> GetAllMeetingRooms();

        IEnumerable<MeetingRoomViewModel> CreateNewMeetingRoom(string NewRoomName);

        MeetingRoomWithServiceTimesViewModel GetMeetingRoom(int RoomId);

        MeetingRoomViewModel UpdateMeetingRoom(int RoomId, string Name);

        void DeleteMeetingRoom(int RoomId);
        #endregion

        #region 會議室服務時間定義
        IEnumerable<DiabetesCarePlatform.Models.ZoomNetMeeting.ServiceTimeViewModel> GetAllServiceTime();

        void CreateServiceTime(string StartTime, string EndTime);

        void DeleteServiceTime(int TimeSectionId);

        int GetTimeSectionIdByStartTime(TimeSpan Start, int Duration=60);
        #endregion

        #region 會議室服務時間指派
        List<AssignedTimeViewModel> GetAllAssignedTime();

        ManageMeetingRoomTimeAssignViewModel GetAssignedTimeByRoom(int room);

        void AssignTimeToRoom(ManageMeetingRoomTimeAssignViewModel assign);

        void UnAssignTimeFromRoom(ManageMeetingRoomTimeAssignViewModel unassign);

        IEnumerable<ServiceTimeWithRemainRoomAmountViewModel> GetMeetingRoomsRemainTable(DateTime shiftdate); 
        #endregion

        #region 登入相關
        int GetUserIdByKey(string UserKey);
        #endregion
    }
}
