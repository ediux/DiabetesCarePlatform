using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.DataTable
{
    public class DataTableResultModel<T> : DiabetesCarePlatform.Models.Interfaces.IDataTableResultModel<T> where T : class
    {
        //相關參數
        public String sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        //回傳資料
        public IEnumerable<T> aaData { get; set; }
    }
}