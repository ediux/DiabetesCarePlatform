using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class CG_HealthEducation
    {

        public int NewsID { get; set; }

        public int NewsType { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Title { get; set; }

        public string SmallPictureUrl { get; set; }

        public string SubTitle { get; set; }

        public string HtmlBody { get; set; }

        public bool Enable { get; set; }

        public int CreateUserID { get; set; }

        public DateTime CreateDate { get; set; }

        public int LastUserID { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}