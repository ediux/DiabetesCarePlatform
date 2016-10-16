using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.DataTable
{
    public class CG_HealthEducationResultModel : DiabetesCarePlatform.Models.Interfaces.IDataTableResultModel<CG_HealthEducation> 
    {
        //相關參數 
        public String sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        //回傳資料
        public IEnumerable<CG_HealthEducation> aaData { get; set; }
    }
}