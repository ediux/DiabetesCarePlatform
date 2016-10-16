using DiabetesCarePlatform.Helpers.JSON.Zoom;
using DiabetesCarePlatform.Models.Common;
using DiabetesCarePlatform.Models.ZoomNetMeeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesCarePlatform.Models.Interfaces
{
    public interface IVideoSchedule_Index_ViewModel : ISinglePageViewModel
    {
        List<FullCalendarEventObjectModel> Schedules { get; set; }
        IZoom_Meeting_ListItem_ViewModel NextSchedule { get; set; }
        List<ServiceLog> ServiceLogTable { get; set; }
        List<ServiceTimeWithRemainRoomAmountViewModel> ServiceTimes { get; set; }
        List<Data.MR_MeetingRooms> MeetingRooms { get; set; }
    }
}
