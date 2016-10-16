using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class DCGroupIndexViewModel
    {
        public List<DCGroupReportViewModel> ManagerLevelReport { get; set; }
        public List<DCGroupReportViewModel> GroupLevelReport { get; set; }
        public List<string> Tabs { get; set; }
    }
}