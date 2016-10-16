using System;
namespace DiabetesCarePlatform.Models.Interfaces
{
    public interface IDataTableResultModel<T>
     where T : class
    {
        System.Collections.Generic.IEnumerable<T> aaData { get; set; }
        int iTotalDisplayRecords { get; set; }
        int iTotalRecords { get; set; }
        string sEcho { get; set; }
    }
}
