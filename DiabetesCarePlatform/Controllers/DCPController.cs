using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiabetesCarePlatform.Helpers.ZoomSupports;
using DiabetesCarePlatform.Helpers.JSON.Zoom;
using DiabetesCarePlatform.Models.ZoomNetMeeting;
using DiabetesCarePlatform.Models.DataTable;
using DiabetesCarePlatform.Models.Common;

namespace DiabetesCarePlatform.Controllers
{
    public class DCPController : Controller
    {
        private string test_USERID = "j0smGf5Adb7EBqy2XhVfK3PN5YD0q3";

        // GET: DCP
        // [Authorize]
        public ActionResult Index()
        {
            if (Common.SYSParamaterObj == null)
            {
                Common com = new Common();
                SYSParamaterModel mem = com.QueryParamater();
                Common.SYSParamaterObj = mem;
            }
            return View();
        }


        public ActionResult IndexDr()
        {
            return View();
        }

        public ActionResult DCP201()
        {
            return View();
        }

        public ActionResult DCP301()
        {
            return View();
        }

        public ActionResult DCP401()
        {
            return View();
        }

        public ActionResult DCP501()
        {
            return View();
        }

        public ActionResult DCP601()
        {
            return View();
        }

        public ActionResult DCP701()
        {
            return View(new Models.ZoomNetMeeting.DCP701_NetMeeting_ViewModel());
        }

        [HttpPost]
        public ActionResult DCP701(FormCollection collection)
        {
            Models.Interfaces.IDCP701_NetMeeting_ViewModel model = new DCP701_NetMeeting_ViewModel();
            TryUpdateModel(model);
            string postUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["ZOOM_API_URL"];
            //zoom_meeting_create meetingcreate = this.meeting_create(test_USERID, "Test");
            return View(model);
        }


        public ActionResult DCP801()
        {
            return View();
        }

        public ActionResult DCP901()
        {
            return View();
        }

    }
}