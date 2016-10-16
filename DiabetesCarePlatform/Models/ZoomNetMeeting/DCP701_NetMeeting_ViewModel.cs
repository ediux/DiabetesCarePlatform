using DiabetesCarePlatform.Helpers.JSON.Zoom;
using DiabetesCarePlatform.Helpers.ZoomSupports;
using DiabetesCarePlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class DCP701_NetMeeting_ViewModel : IDCP701_NetMeeting_ViewModel
    {
        private zoom_meeting_create _response;

        public zoom_meeting_create Response
        {
            get
            {
                return _response;
            }
            set
            {
                _response = value;
            }
        }
    }
}