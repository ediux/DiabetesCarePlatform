using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class ServiceTimeWithRemainRoomAmountViewModel : ServiceTimeViewModel
    {
        public int RemainAmount { get; set; }

        public static ServiceTimeWithRemainRoomAmountViewModel ConvertFrom(Data.FN_GetMeetingRoomsRemainTableResult SingleMeetingRoom)
        {
            return new ServiceTimeWithRemainRoomAmountViewModel()
            {
                TimeSectionId = SingleMeetingRoom.TimeSectionId,
                EndTime = SingleMeetingRoom.EndTime,
                StartTime = SingleMeetingRoom.StartTime,
                RemainAmount = SingleMeetingRoom.RemainAmount
            };
        }
    }
}