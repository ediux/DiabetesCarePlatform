using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class ManageMeetingRoomTimeAssignViewModel
    {
        public ManageMeetingRoomTimeAssignViewModel()
        {
            room = new MeetingRoomViewModel();
            assignedtimes = new List<AssignedTimeViewModel>();
            servicetime = new List<ServiceTimeViewModel>();
        }

        private MeetingRoomViewModel room;
        public MeetingRoomViewModel Room { get { return room; } set { room = value; } }

        private List<AssignedTimeViewModel> assignedtimes;
        public List<AssignedTimeViewModel> AssignedTimes { get { return assignedtimes; } set { assignedtimes = value; } }

        private List<ServiceTimeViewModel> servicetime;
        public List<ServiceTimeViewModel> ServiceTimes { get { return servicetime; } set { servicetime = value; } }
    }
}