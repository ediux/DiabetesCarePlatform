using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiabetesCarePlatform.Controllers
{
    /// <summary>
    /// 用來處理顯示系統引發的未處理之錯誤例外狀況的頁面。
    /// </summary>
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(Exception exception, int status)
        {
            if (exception is HttpException)
            {
                var ex = exception as HttpException;

                ViewBag.StatusCode = ex.ErrorCode;
                ViewBag.Message = ex.Message;
                ViewBag.StackTrace = ex.StackTrace;
                ViewBag.InnerException = ex.InnerException;
            }
            else
            {

                ViewBag.StatusCode = status;
                ViewBag.Message = exception.Message;
                ViewBag.StackTrace = exception.StackTrace;
                ViewBag.InnerException = exception.InnerException;
            }
            

            return View();
        }

        public ActionResult PageNotFound(Exception exception,int status)
        {
            //var ex = Request.RequestContext.RouteData.Values["exception"] as HttpException;
            var ex = exception as HttpException;
            ViewBag.StatusCode = ex.GetHttpCode();
            ViewBag.Message = ex.Message;
            ViewBag.StackTrace = ex.StackTrace;
            ViewBag.InnerException = ex.InnerException;

            return View("Index");
        }
    }
}