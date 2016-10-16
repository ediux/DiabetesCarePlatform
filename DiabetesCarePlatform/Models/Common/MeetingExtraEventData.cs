using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.Common
{
    public class MeetingExtraEventData
    {
        public string UserID {get;set;}
        public string ShiftDate { get; set; }
        public string host_id {get;set;}
        public int room_id {get;set;}
        public string uuid{get;set;}
        public string meeting_id {get;set;}
        public int  TimeSectionId {get;set;}
    }
}