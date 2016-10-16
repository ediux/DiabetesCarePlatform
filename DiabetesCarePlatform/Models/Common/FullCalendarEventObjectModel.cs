using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.Common
{
    public class FullCalendarEventObjectModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public bool allDay { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string url { get; set; }
        public string[] className { get;set; }
        public bool editable { get; set; }
        public bool startEditable { get; set; }
        public bool durationEditable { get; set; }
        public bool resourceEditable { get; set; }
        public string rendering { get; set; }
        public bool overlap { get; set; }
        public string constraint { get; set; }
        public string source { get; set; }
        public string color { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public string textColor { get; set; }
        public MeetingExtraEventData extraData { get; set; }
    }
}