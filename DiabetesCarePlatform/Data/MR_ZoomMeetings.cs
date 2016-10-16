using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Data
{
    public class MR_ZoomMeetings
    {
        [Key]
        [Column(Order=0)]
        [StringLength(10)]
        public string Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(24)]
        public string uuid { get; set; }

        public string start_url { get; set; }

        public string join_url { get; set; }

        public DateTime created_at { get; set; }

        [Key]
        [Column(Order=2)]
        [StringLength(30)]
        public string host_id { get; set; }

        public string topic { get; set; }

        public int type { get; set; }

        public DateTime? start_time { get; set; }

        public int? duration { get; set; }

        public string timezone { get; set; }

        public string password { get; set; }

        public bool? option_jbh { get; set; }

        public string option_start_type { get; set; }

        public bool? option_host_video { get; set; }

        public bool? option_participants_video { get; set; }

        public string option_audio { get; set; }

        public int userid { get; set; }
    }
}