using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.MVCExtras
{
    public class MenuItemPatternJSONData
    {
        public string type { get; set; }
        public string name { get; set; }
        public int index { get; set; }
        public string bindingname { get; set; }
        public List<MenuItemPatternJSONData> attrs { get; set; }
        public List<MenuItemPatternJSONData> innerHtml { get; set; }
    }
}