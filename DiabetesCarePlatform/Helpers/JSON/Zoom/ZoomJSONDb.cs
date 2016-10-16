using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class ZoomJSONDb
    {
        public ZoomJSONDb()
        {
            _meetings = new Dictionary<string, meeting_list_data>();
            _zoom_users = new SortedList<string, user_listdata_data>();
            _reports = new SortedList<string, report_getalluserreport_data[]>();
            scheduletimes = new Dictionary<string, DateTime>();
        }

        private Dictionary<string, meeting_list_data> _meetings;
        public Dictionary<string, meeting_list_data> meetings { get { return _meetings; } set { _meetings = value; } }

        private SortedList<string, user_listdata_data> _zoom_users;
        public SortedList<string, user_listdata_data> zoom_users { get { return _zoom_users; } set { _zoom_users = value; } }

        private SortedList<string, report_getalluserreport_data[]> _reports;
        public SortedList<string, report_getalluserreport_data[]> reports { get { return _reports; } set { _reports = value; } }

        private Dictionary<string, DateTime> scheduletimes;
        public Dictionary<string, DateTime> ScheduleTimes { get { return scheduletimes; } set { scheduletimes = value; } }

        public DateTime lastaccesstime { get; set; }
        public int lastupdatepagenumber { get; set; }
        public int maxpagenumber { get; set; }

    }
}