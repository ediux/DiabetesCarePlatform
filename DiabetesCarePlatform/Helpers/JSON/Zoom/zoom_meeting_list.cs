using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class zoom_meeting_list
    {
        public string code { get; set; }
        public string message { get; set; }
        public meeting_list_paged_data data { get; set; }
    }
}