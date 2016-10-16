using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON
{
    public class fullcalendarEventObjectJSON
    {
        public string id { get; set; }
        public string title { get; set; }
        public bool allDay { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string url { get; set; }
        public string className { get; set; }
        public bool editable { get; set; }
        public bool startEditable { get; set; }
        public bool durationEditable { get; set; }
        public string rendering { get; set; }
        public bool overlap { get; set; }
        public string constraint { get; set; }
        public object source { get; set; }
        public string color { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public string textColor { get; set; }
    }
}