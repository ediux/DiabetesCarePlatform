using DiabetesCarePlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.SystemCore
{
    public class MenuItemViewModel : IMenuItemViewModel
    {
        public MenuItemViewModel()
        {
            title = string.Empty;

            area = string.Empty;
            actionname = string.Empty;
            controllername = string.Empty;
            routedvalues = null;

            iconcssclass = string.Empty;
            itemcssclass = string.Empty;
            submenus = new List<IMenuItemViewModel>();
        }

        #region 內部變數
        private string title;

        private string area;
        private string actionname;
        private string controllername;
        private object routedvalues;

        private string iconcssclass;
        private string itemcssclass;
        private List<IMenuItemViewModel> submenus;
        #endregion
        
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

        public virtual List<IMenuItemViewModel> SubMenus
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