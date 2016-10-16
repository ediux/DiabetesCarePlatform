using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.Datas
{
    public class DataTableParam
    {
        /// 
        /// 請求的次數序號
        ///        
        public string sEcho { get; set; }

        /// 
        /// 查詢用的資料
        /// 
        public string sSearch { get; set; }

        /// 
        /// 一頁要顯示幾筆資料
        /// 
        public int iDisplayLength { get; set; }

        /// 
        /// 第一筆資料的位置
        /// 
        public int iDisplayStart { get; set; }

        /// 
        /// 在表中的列數
        /// 
        public int iColumns { get; set; }

        /// 
        /// 用哪一個欄位進行排序
        /// 
        public int iSortingCols { get; set; }

        /// 
        /// 欄位的名稱
        /// 
        public string sColumns { get; set; }

    }
}