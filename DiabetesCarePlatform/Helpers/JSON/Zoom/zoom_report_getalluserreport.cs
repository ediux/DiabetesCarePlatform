using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class zoom_report_getalluserreport
    {
        public string code { get; set; }
        public string message { get; set; }
        public report_getalluserreport_paged_data data { get; set; }
    }
}