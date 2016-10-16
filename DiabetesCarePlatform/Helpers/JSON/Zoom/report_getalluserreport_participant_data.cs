using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class report_getalluserreport_participant_data
    {
        public string name { get; set; }
        public DateTime join_time { get; set; }
        public DateTime leave_time { get; set; }
    }
}