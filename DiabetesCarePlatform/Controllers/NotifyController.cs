using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR.Client;
using System.IO;
using PushSharp.Apple;
using PushSharp;
using Newtonsoft.Json.Linq;

namespace DiabetesCarePlatform.Controllers
{
    public class NotifyController : Controller
    {
        private String UserName { get; set; }
        private IHubProxy HubProxy { get; set; }
        private HubConnection Connection { get; set; }

        // GET: Notify
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Messages(int ID, int Type)
        {
            return View();
        }
        [HttpPost]
        public async void SendNotify(string Action, string UserId, string Msg, string DateTime)
        {
            string ServerURI = HttpContext.Request.Url.Scheme + "://" + HttpContext.Request.Url.Authority + "/signalr";
            Connection = new HubConnection(ServerURI); 
            HubProxy = Connection.CreateHubProxy("GroupChatHub");
            try
            {
                await Connection.Start();
                await HubProxy.Invoke("broadCastUser", Action, Msg, UserId, DateTime);
                if (Connection != null)
                {
                    Connection.Stop();
                    Connection.Dispose();
                }
            }
            catch (HttpRequestException)
            {
            }
            
        }

        [HttpPost]
        public JsonResult iOSPush(string token, string Msg)
        {
            try
            {
                string strP12Path = System.Web.Configuration.WebConfigurationManager.AppSettings["IOS_PUSH_PATH"];
                string strP12Pwd = System.Web.Configuration.WebConfigurationManager.AppSettings["IOS_PUSH_PWD"];

                var config = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production,
                strP12Path, strP12Pwd);
                ApnsServiceBroker apnsBroker = new ApnsServiceBroker(config);

                apnsBroker.Start();

                JObject aps = new JObject();
                aps["aps"] = new JObject();
                aps["aps"]["badge"] = new JValue(1); ;
                aps["aps"]["alert"] = new JValue(Msg);

                apnsBroker.QueueNotification(new ApnsNotification
                {
                    DeviceToken = token,
                    Payload = aps//JObject.Parse(string.Format("{\"aps\":{\"badge\":1,\"alert\":\"{0}\"}}", Msg))
                });

                apnsBroker.Stop();

                return Json(new { Success = true }, "application/json", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, "application/json", JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public JsonResult AndroidPush(string channelId, string Msg)
        {
            try
            {
                return Json(new { Success = true }, "application/json", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, "application/json", JsonRequestBehavior.AllowGet);
            }
        }
    }
}