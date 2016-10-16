using DiabetesCarePlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class Zoom_Meeting_ListItem_ViewModel : IZoom_Meeting_ListItem_ViewModel
    {
        public Zoom_Meeting_ListItem_ViewModel()
        {
            uuid = string.Empty;
            id = string.Empty;
            start_url = string.Empty;
            join_url = string.Empty;
            createat = DateTime.Now;
            host_id = string.Empty;
            topic = string.Empty;
            _type = 0;
            starttime = DateTime.Now;
            duration = 0;
            timezone = string.Empty;
            password = string.Empty;
            option_jbh = false;
            option_start_type = string.Empty;
            option_host_video = false;
            option_participants_video = false;
            option_audio = "";
            status = 0;
            userid = -1;
            name = string.Empty;
            typename = string.Empty;
        }

        private string uuid;

        public string UUID
        {
            get
            {
                return uuid;
            }
            set
            {
                uuid = value;
            }
        }
        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                    
            }
        }
        private string start_url;
        public string Start_Url
        {
            get
            {
                return start_url;
            }
            set
            {
                start_url = value;
            }
        }
        private string join_url;

        public string Join_Url
        {
            get
            {
                return join_url;
            }
            set
            {
                join_url = value;
            }
        }

        private DateTime createat;
        public DateTime CreatedAt
        {
            get
            {
                return createat;
            }
            set
            {
                createat = value;
            }
        }
        private string host_id;
        public string Host_Id
        {
            get
            {
                return host_id;
            }
            set
            {
                host_id = value;
            }
        }
        private string topic;
        public string Topic
        {
            get
            {
                return topic;
            }
            set
            {
                topic = value;
            }
        }

        private int _type;
        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        private DateTime starttime;
        public DateTime StartTime
        {
            get
            {
                return starttime;
            }
            set
            {
                starttime = value;
            }
        }

        private int duration;

        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }

        private string timezone;
        public string TimeZone
        {
            get
            {
                return timezone;
            }
            set
            {
                timezone = value;
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        private bool option_jbh;
        public bool Option_jbh
        {
            get
            {
                return option_jbh;
            }
            set
            {
                option_jbh = value;
            }
        }

        private string option_start_type;
        public string Option_Start_Type
        {
            get
            {
                return option_start_type;
            }
            set
            {
                option_start_type = value;
            }
        }
        
        private bool option_host_video;

        public bool Option_Host_Video
        {
            get
            {
                return option_host_video;
            }
            set
            {
                option_host_video = value;
            }
        }

        private bool option_participants_video;

        public bool Option_Participants_Video
        {
            get
            {
              return  option_participants_video;
            }
            set
            {
                option_participants_video = value;
            }
        }

        private string option_audio;

        public string Option_Audio
        {
            get
            {
                return option_audio;
            }
            set
            {
                option_audio = value;
            }
        }

        private int status;
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public string StatusText
        {
            get {
                string statustext = string.Empty;
                switch (status)
                {
                    case 0:
                        statustext = "會議尚未開始";
                        break;
                    case 1:
                        statustext = "會議進行中";
                        break;
                    case 2:
                        statustext = "會議已結束";
                        break;
                }
                return statustext;
            }
        }

        private int userid;

        public int UserId
        {
            get
            {
                return userid;
            }
            set
            {
                userid = value;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string typename;

        public string TypeName
        {
            get
            {
                return typename;
            }
            set
            {
                typename = value;
            }
        }
    }
}