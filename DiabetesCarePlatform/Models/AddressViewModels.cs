using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class AddressViewModels
    {

        public int StateID { get; set; }
        public string StateName { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
         
    }
}