using DiabetesCarePlatform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DiabetesCarePlatform.Repository
{
    public class BaseRepository
    {
        ChronicCareEntities Dap = new ChronicCareEntities();

        public ChronicCareEntities Database { get { return Dap; } }
        public List<T> ModelListSP<T>(string spName, Dictionary<String, Object> field)
        {
            Dictionary<string,ObjectParameter> obj_paramters = new  Dictionary<string,ObjectParameter>();
         
            ObjectParameter UserKey = new ObjectParameter("UserKey", Common.UserInfoObj.UserKey);
            obj_paramters.Add(UserKey.Name, UserKey);
            ObjectParameter IP = new ObjectParameter("IP", Common.UserInfoObj.IP);
            obj_paramters.Add(IP.Name,IP);

            if (field.Any())
            {
                foreach (var key in field.Keys)
                {
                    obj_paramters.Add(key, new ObjectParameter(key, field[key]));
                }
            }
            obj_paramters.Add("NewUserKey",new ObjectParameter("NewUserKey", UserKey));

            Dictionary<String, DbType> Outputparam = new Dictionary<string, DbType>();
            Outputparam.Add("NewUserKey", DbType.String);

            Dictionary<String, Object> output = new Dictionary<string,object>();

            ObjectParameter[] p =  obj_paramters.Select(s=>s.Value).ToArray();
            var result = ((IObjectContextAdapter)Dap).ObjectContext.ExecuteFunction<T>(spName,p);

            output.Add("NewUserKey", p.Where(w => w.Name == "NewUserKey").Single())
             ;
           
           // var list = Dap .ModelListSPOutput<T>(spName, field, Outputparam, out output);
            CheckUserKey(output);
            return result.ToList();
        }

        public int NonQuerySP(string spName, Dictionary<String, Object> field)
        {
            field.Add("UserKey", Common.UserInfoObj.UserKey);
            field.Add("IP", Common.UserInfoObj.IP);
            Dictionary<String, DbType> Outputparam = new Dictionary<string, DbType>();
            Outputparam.Add("NewUserKey", DbType.String);
            Dictionary<String, Object> output;
            int result = Dap.NonQuerySPOutput(spName, field, Outputparam, out output);
            CheckUserKey(output);
            return result;
        }

        public Dictionary<String, Object> NonQuerySPOutput(string spName, Dictionary<String, Object> field, Dictionary<String, DbType> Outputparam)
        {
            field.Add("UserKey", Common.UserInfoObj.UserKey);
            field.Add("IP", Common.UserInfoObj.IP);
            Outputparam.Add("NewUserKey", DbType.String);
            Dictionary<String, Object> output;
            Dap.NonQuerySPOutput(spName, field, Outputparam, out output);
            CheckUserKey(output);
            return output;
        }

        private void CheckUserKey(Dictionary<String, Object> output)
        {
            string NewUserKey = output["NewUserKey"].ToString();
            if (NewUserKey != Common.UserInfoObj.UserKey)
            {
                UpdateTicketUserKey(NewUserKey);
                Common.UserInfoObj.UserKey = NewUserKey;
            }
        }

        private void UpdateTicketUserKey(string NewUserKey)
        {
            FormsIdentity Id = (FormsIdentity)HttpContext.Current.User.Identity;
            FormsAuthenticationTicket ticket = Id.Ticket; //取得身份验证票
            var userdata = ticket.UserData.Split(',');
            string userkey = userdata[0];
            string ip = userdata[1];
            string newuserdata = NewUserKey + "," + ip;
            var newticket = new FormsAuthenticationTicket(ticket.Version,
                                                          ticket.Name,
                                                          ticket.IssueDate,
                                                          ticket.Expiration,
                                                          true, // always persistent
                                                          newuserdata,
                                                          ticket.CookiePath);
            string encTicket = FormsAuthentication.Encrypt(newticket);

            // Create the cookie.
            //Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            
            //cookie.Expires = newticket.Expiration.AddHours(24);
            HttpContext.Current.Response.Cookies.Set(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }
    }
}