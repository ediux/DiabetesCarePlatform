using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

namespace DiabetesCarePlatform
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Make long polling connections wait a maximum of 110 seconds for a
            // response. When that time expires, trigger a timeout command and
            // make the client reconnect.
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(110);

            // Wait a maximum of 30 seconds after a transport connection is lost
            // before raising the Disconnected event to terminate the SignalR connection.
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(30);

            // For transports other than long polling, send a keepalive packet every
            // 10 seconds. 
            // This value must be no more than 1/3 of the DisconnectTimeout value.
            GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(10);

            //GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => new MyIdProvider());
             
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           // Helpers.ZoomSupports.ZoomNetMeetingRepository.AddFirstCache();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            //將 Cookies 的 MyLang 取出，主要是要指定語系
            HttpCookie MyLang = Request.Cookies["MyLang"];
            if (MyLang != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture =
                 new System.Globalization.CultureInfo(MyLang.Value);
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                 new System.Globalization.CultureInfo(MyLang.Value);
            }
        }

        protected void Application_Error()
        {

            var exception = Server.GetLastError();
            var httpException = exception as HttpException;
            Response.Clear();
            Server.ClearError();
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = "Index";
            routeData.Values["exception"] = exception;
            routeData.Values["status"] = 500;  
            Response.ContentType = "text/html";
            Response.StatusCode = 500;
            if (httpException != null)
            {
                Response.StatusCode = httpException.GetHttpCode();
                switch (Response.StatusCode)
                {
                    case 404:
                        routeData.Values["action"] = "PageNotFound";
                        routeData.Values["status"] = 404;
                        break;
                }
            }

            try
            {
                IController errorsController = new DiabetesCarePlatform.Controllers.ErrorController();
                var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
                errorsController.Execute(rc);
            }
            catch
            {
                Response.Write("Internal Error!");
            }
         
        }
    }
}
