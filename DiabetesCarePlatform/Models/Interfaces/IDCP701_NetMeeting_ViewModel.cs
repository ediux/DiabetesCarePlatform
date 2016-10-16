using DiabetesCarePlatform.Helpers.JSON.Zoom;
using DiabetesCarePlatform.Helpers.ZoomSupports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesCarePlatform.Models.Interfaces
{
    public interface IDCP701_NetMeeting_ViewModel : ISinglePageViewModel
    {
        zoom_meeting_create Response { get; set; }
    }
}
