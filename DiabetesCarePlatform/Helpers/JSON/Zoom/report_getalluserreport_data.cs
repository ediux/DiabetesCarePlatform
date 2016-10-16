using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class report_getalluserreport_data
    {
        public string host_id { get; set; }
        public string number { get; set; }
        public string topic { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public int duration { get; set; }
        public report_getalluserreport_participant_data[] participants { get; set; }
    }
}