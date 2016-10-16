using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class meeting_list_data
    {
        public meeting_list_data()
        {
            _start_time = default(DateTime?);
        }

        public string uuid { get; set; }

        public string id { get; set; }

        public string start_url { get; set; }

        public string join_url { get; set; }

        public DateTime created_at { get; set; }

        public string host_id { get; set; }

        public string topic { get; set; }

        public int type { get; set; }

        private DateTime? _start_time;
        public DateTime? start_time { get { return _start_time; } set { if (value.HasValue) { _start_time = new Nullable<DateTime>(value.Value); } } }

        public int duration { get; set; }

        public string timezone { get; set; }

        public string password { get; set; }

        public bool option_jbh { get; set; }

        public string option_start_type { get; set; }

        public bool option_host_video { get; set; }

        public bool option_participants_video { get; set; }

        public string option_audio { get; set; }

        public int status { get; set; }
      
    }
}