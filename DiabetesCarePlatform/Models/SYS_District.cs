using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class SYS_District
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int CityID { get; set; } 
        public int StateID { get; set; }
        public int CountryID { get; set; }
    }
}