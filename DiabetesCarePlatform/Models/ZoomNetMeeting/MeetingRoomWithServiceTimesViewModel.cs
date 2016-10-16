using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class MeetingRoomWithServiceTimesViewModel : MeetingRoomViewModel
    {
        public MeetingRoomWithServiceTimesViewModel()
        {
            servicetimes = new List<ServiceTimeViewModel>();
        }

        private List<ServiceTimeViewModel> servicetimes;
        [DisplayName("服務時間")]
        public List<ServiceTimeViewModel> ServiceTimes { get { return servicetimes; } set { servicetimes = value; } }
    }
}