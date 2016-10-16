using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class DCGroupReportViewModel
    {
         public int UnitID { get; set; }
         public string UnitName { get; set; }
         public int SYSUserCount { get; set; }
         public int DMCount { get; set; }
         public int UnitRankTypeID { get; set; }
         public int ORDER { get; set; }
         public string ParentUnitName { get; set; }
    }
}