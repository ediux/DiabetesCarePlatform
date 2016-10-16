using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesCarePlatform.Models.Interfaces
{
    public interface IZoom_Respones_ViewModel<TDataModel>
    {
        string Code { get; set; }
        string Message { get; set; }
        TDataModel Data { get; set; }
    }
}
