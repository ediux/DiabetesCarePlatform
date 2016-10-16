using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class SYS_UserAssignUnit
    {
        public int UnitID { get; set; }
        public int UserID { get; set; }
        public int LastUserID { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}