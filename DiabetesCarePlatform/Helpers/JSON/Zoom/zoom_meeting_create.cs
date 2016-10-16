using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class zoom_meeting_create 
    {
        public zoom_meeting_create()
        {
            _data = null;
        }

        public string code { get; set; }
        public string message { get; set; }

        private meeting_create_data _data;
        public meeting_create_data data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}