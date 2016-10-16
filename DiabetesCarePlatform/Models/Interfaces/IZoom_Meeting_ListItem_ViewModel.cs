using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesCarePlatform.Models.Interfaces
{
    public interface IZoom_Meeting_ListItem_ViewModel
    {
        string UUID { get; set; }
        string Id { get; set; }
        string Start_Url { get; set; }
        string Join_Url { get; set; }
        DateTime CreatedAt { get; set; }
        string Host_Id { get; set; }
        string Topic { get; set; }
        int Type { get; set; }
        string TypeName { get; set; }
        DateTime StartTime { get; set; }
        int Duration { get; set; }
        string TimeZone { get; set; }
        string Password { get; set; }
        bool Option_jbh { get; set; }
        string Option_Start_Type { get; set; }
        bool Option_Host_Video { get; set; }
        bool Option_Participants_Video { get; set; }
        string Option_Audio { get; set; }
        int Status { get; set; }
        string StatusText { get; }
        int UserId { get; set; }
        string Name { get; set; }
    }
}
