using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class zoom_user_update
    {
        public string code { get; set; }
        public string message { get; set; }
        public user_update_data data { get; set; }
    }
}