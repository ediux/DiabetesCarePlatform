using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class zoom_user_list
    {
        public string code { get; set; }
        public string message { get; set; }
        public user_getlist_paged_data data { get; set; }
    }
}