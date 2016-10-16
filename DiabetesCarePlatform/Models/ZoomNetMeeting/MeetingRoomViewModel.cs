using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class MeetingRoomViewModel
    {
        public MeetingRoomViewModel()
        { 
            
        }

        
        [DisplayName("識別碼")]
        public int Id { get; set; }
        public string Name { get; set; }

      
    }
}