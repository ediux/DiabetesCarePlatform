using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExtras
{
    public static class MVCExtrasExtension
    {
        public static HtmlString Geti18nText(this HtmlHelper htmlhelper, string resName)
        {
            HttpCookie MyLang = htmlhelper.ViewContext.RequestContext.HttpContext.Request.Cookies["MyLang"];
            
            System.Globalization.CultureInfo _SysCulture =System.Globalization.CultureInfo.CurrentCulture; //預設使用伺服器端的語系設定

            if (MyLang != null)
            {
                _SysCulture =  new System.Globalization.CultureInfo(MyLang.Value);
                //System.Threading.Thread.CurrentThread.CurrentCulture =
                // new System.Globalization.CultureInfo(MyLang.Value);
                //System.Threading.Thread.CurrentThread.CurrentUICulture =
                // new System.Globalization.CultureInfo(MyLang.Value);
            }

            return new HtmlString(Reslang.Resource.ResourceManager.GetString(resName, _SysCulture));
        }
        public static HtmlString GetConfigValue<TModel>(this HtmlHelper<TModel> htmlhelper, string Name) where TModel : class
        {
            try
            {
                return new HtmlString(System.Web.Configuration.WebConfigurationManager.AppSettings[Name]);
            }
            catch
            {
                return new HtmlString(string.Empty);
            }
        }

        public static HtmlString GetConfigValue(this HtmlHelper htmlhelper, string Name)
        {
            try
            {
                return new HtmlString(System.Web.Configuration.WebConfigurationManager.AppSettings[Name]);
            }
            catch
            {
                return new HtmlString(string.Empty);
            }
        }
    }
}