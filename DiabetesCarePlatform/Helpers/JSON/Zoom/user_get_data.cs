using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class user_get_data
    {
        public string id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int verified { get; set; }
        public string pmi { get; set; }
        public string meeting_capacity { get; set; }
        public bool disable_chat { get; set; }
        public bool enable_e2e_encryption { get; set; }
        public bool enable_silent_mode { get; set; }
        public bool disable_group_hd { get; set; }
        public bool disable_recording { get; set; }
        public int auto_recording { get; set; }
        public bool disable_feedback { get; set; }
        public bool disable_jbh_reminder { get; set; }
        public DateTime created_at { get; set; }

    }
}