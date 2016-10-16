using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using DiabetesCarePlatform.Models;
using DiabetesCarePlatform.Models.DataTable;

namespace DiabetesCarePlatform
{
    public class NotificationRepository 
    {
        DB_Dapper Dap = new DB_Dapper();
        public string Message;

        public CG_NotificationResultModel SP_GetCG_NotificationList(int mDisplayRecords)
        {
            CG_NotificationResultModel rm = new CG_NotificationResultModel();
            Dictionary<String, Object> field = new Dictionary<string, object>();
            rm.aaData = Dap.ModelListSP<CG_Notification>("SP_GetCG_NotificationList", field);
            rm.iTotalRecords = rm.aaData.Count();
            rm.iTotalDisplayRecords = mDisplayRecords;
            return rm;
        }


    }
}