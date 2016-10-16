using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class SYS_Unit
    {
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public int ParentUnitID { get; set; }
        public int UnitRankTypeID { get; set; }
        public bool Checked { get; set; }
    }

    public class SYS_Unit_Extend : SYS_Unit
    {
        public int UserID { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public int SexID { get; set; }
        public string JobTitle { get; set; }
    }
}