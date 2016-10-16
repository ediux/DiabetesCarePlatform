using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using DiabetesCarePlatform.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using DiabetesCarePlatform.Models.Common;
using System.Web.Security;
using DiabetesCarePlatform.Repository;

namespace DiabetesCarePlatform.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        DBRepository SP = new DBRepository();
        public AccountController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string Account = model.Account;
            string Password = model.Password;
            string IP = Server.HtmlEncode(Request.UserHostAddress);
            string LoginResult = LoginAndGetUserKey(0, Account, Password, IP);
            if (!LoginResult.StartsWith("Er_"))
            {
                Common com = new Common();
                UserInfo mem = com.QueryUserInfo(LoginResult);

                Common.UserInfoObj = new UserInfo() { ID = mem.ID, Account = mem.Account, Name = mem.Name, ParentUnitID = mem.ParentUnitID, UserKey = mem.UserKey, IP = IP };

                //未過期
                //Session.RemoveAll();
              
               // FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(Common.UserInfoObj.Account, true, 30);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                                              Common.UserInfoObj.Account,
                                              DateTime.Now,
                                              DateTime.Now.AddMinutes(30),
                                              true, // always persistent
                                              Common.UserInfoObj.UserKey+","+Common.UserInfoObj.IP,
                                              "/");
                global::System.Web.Security.FormsIdentity newUser = new global::System.Web.Security.FormsIdentity(authTicket);
                global::System.Web.HttpContext.Current.User = new global::System.Security.Principal.GenericPrincipal(newUser, new string[] { });

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(authTicket);

                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
             
                if (!string.IsNullOrEmpty(returnUrl) && returnUrl.Length > 1 && !returnUrl.Contains("LogOff")) return Redirect(returnUrl);
                return RedirectToAction("Index", "DCP");
            }
            else
            {
                ModelState.AddModelError("", LoginResult.Substring(3));
            }

            // 如果執行到這裡，發生某項失敗，則重新顯示表單
            return View(model);

        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {

            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Login", "Account");
        }

        private string LoginAndGetUserKey(int UnitID, string Account, string Password, string IP) {
            string result = "Er_無資料";
            try
            {
                var output = SP.SP_UserLogin(UnitID, Account, Password, IP);
                if (output != null && output.ContainsKey("UserKey")) {
                    result = output["UserKey"].ToString();
                }
            }
            catch (Exception ex)
            {
                result = "Er_" + ex.Message;
            }
            return result;
        }
        #region Helper
        // 新增外部登入時用來當做 XSRF 保護
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}