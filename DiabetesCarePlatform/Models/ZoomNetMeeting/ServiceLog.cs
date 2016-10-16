using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class ServiceLog
    {
        public ServiceLog()
        {
            servicetime = new ServiceTimeWithShitfDateAndDurationViewModel();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        private ServiceTimeWithShitfDateAndDurationViewModel servicetime;
        public ServiceTimeWithShitfDateAndDurationViewModel ServiceTime { get { return servicetime; } set { servicetime = value; } }
        public string Descriotion { get; set; }
    }

    public class ServiceTimeWithShitfDateAndDurationViewModel : ServiceTimeViewModel {
        public DateTime Date { get; set; }
        public int Duration { get; set; }
    }
}