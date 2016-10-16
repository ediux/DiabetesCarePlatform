using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class VideoSchedule_Index_ViewModel : SinglePageViewModel,Interfaces.IVideoSchedule_Index_ViewModel
    {
        public VideoSchedule_Index_ViewModel()
        {
            schedules = new List<Common.FullCalendarEventObjectModel>();
            nextschedule = new Zoom_Meeting_ListItem_ViewModel();
            servicelogtable = new List<ServiceLog>();
            servicetimes = new List<ServiceTimeWithRemainRoomAmountViewModel>();
            meetingrooms = new List<Data.MR_MeetingRooms>();
        }
        private List<Common.FullCalendarEventObjectModel> schedules;

        public List<Common.FullCalendarEventObjectModel> Schedules
        {
            get
            {
                return schedules;
            }
            set
            {
                schedules = value;
            }
        }

        private Interfaces.IZoom_Meeting_ListItem_ViewModel nextschedule;
        public Interfaces.IZoom_Meeting_ListItem_ViewModel NextSchedule
        {
            get
            {
                return nextschedule;
            }
            set
            {
                nextschedule = value;
            }
        }

        private List<ServiceLog> servicelogtable;
        public List<ServiceLog> ServiceLogTable
        {
            get
            {
                return servicelogtable;
            }
            set
            {
                servicelogtable = value;
            }
        }

        private List<ServiceTimeWithRemainRoomAmountViewModel> servicetimes;

        public List<ServiceTimeWithRemainRoomAmountViewModel> ServiceTimes
        {
            get { return servicetimes; }
            set { servicetimes = value; }
        }

        private List<Data.MR_MeetingRooms> meetingrooms;
        public List<Data.MR_MeetingRooms> MeetingRooms
        {
            get
            {
                return meetingrooms;
            }
            set
            {
                meetingrooms = value;
            }
        }
    }
}