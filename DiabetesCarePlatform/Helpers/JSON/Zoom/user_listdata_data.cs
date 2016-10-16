using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class user_listdata_data
    {
        public string id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int verified { get; set; }
        public DateTime join_at { get; set; }
        public string capactity { get; set; }
    }
}