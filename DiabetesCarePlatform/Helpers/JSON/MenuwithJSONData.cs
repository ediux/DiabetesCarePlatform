using DiabetesCarePlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.MVCExtras
{
    public class MenuwithJSONData
    {
        public MenuwithJSONData()
        {
            title = string.Empty;

            area = string.Empty;
            actionname = string.Empty;
            controllername = string.Empty;
            routedvalues = null;

            iconcssclass = string.Empty;
            iconname = string.Empty;
            itemcssclass = string.Empty;
            submenus = new List<MenuwithJSONData>();
            index = 0;
        }

        #region 內部變數
        private string title;

        private string area;
        private string actionname;
        private string controllername;
        private object routedvalues;

        private string iconcssclass;
        private string iconname;
        private string itemcssclass;
        private List<MenuwithJSONData> submenus;
        private int index;
        #endregion
        public int Index { get { return index; } set { index = value; } }
        public string Title { get { return title; } set { title = value; } }


        public string Area { get { return area; } set { area = value; } }
        public string ActionName { get { return actionname; } set { actionname = value; } }
        public string ControllerName { get { return controllername; } set { controllername = value; } }
        public object RoutedValues { get { return routedvalues; } set { routedvalues = value; } }


        public string IconCSSClass
        {
            get
            {
                return iconcssclass;
            }
            set
            {
                iconcssclass = value;
            }
        }

        public string IconName
        {
            get { return iconname; }
            set { iconname = value; }
        }
        public string ItemCSSClass
        {
            get
            {
                return itemcssclass;
            }
            set
            {
                itemcssclass = value;
            }
        }

        public virtual List<MenuwithJSONData> SubMenus
        {
            get
            {
                return submenus;
            }
            set
            {
                submenus = value;
            }
        }
    }
}