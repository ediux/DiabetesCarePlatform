using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesCarePlatform.Models.Interfaces
{
    public interface IPagedListViewModel<TDataViewModel>
    {
        int PageCount { get; set; }
        int TotalRecords { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        List<TDataViewModel> Rows { get; set; }
    }
}
