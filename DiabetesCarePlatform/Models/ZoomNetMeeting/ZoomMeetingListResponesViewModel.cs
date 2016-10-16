using DiabetesCarePlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class ZoomMeetingListResponesViewModel : IZoomMeetingListResponesViewModel
    {
        public ZoomMeetingListResponesViewModel()
        {
            code = string.Empty;
            message = string.Empty;
            data = new ZoomMeetingPageListViewModel();
        }

        private string code;

        public string Code
        {
            get
            {
                return code;
                            }
            set
            {
                code = value;
            }
        }

        private string message;

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        private IZoomMeetingPageListViewModel data;

        public IZoomMeetingPageListViewModel Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
    }
}