using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class report_getalluserreport_paged_data : zoom_pagedlist
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public report_getalluserreport_data[] meetings { get; set; }
    }
}