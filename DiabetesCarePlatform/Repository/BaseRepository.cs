using DiabetesCarePlatform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DiabetesCarePlatform.Repository
{
    public class BaseRepository
    {
        protected ChronicCareEntities Dap = new ChronicCareEntities();

        public List<T> ModelListSP<T>(string spName, Dictionary<String, Object> field)
        {
            ObjectParameterCollection obj_paramters = new SqlParameterCollection();
          
          //  obj_paramters.Add(new ObjectParameter("UserKey",Common.UserInfoObj.UserKey));
          //obj_paramters.Add(new )
          //  obj_paramters.Add("@IP", Common.UserInfoObj.IP);
          
          //  if (field.Any())
          //  {
          //      foreach (var key in field.Keys)
          //      {
          //          obj_paramters.Add(key, field[key]);
          //      }
          //  }

            //obj_paramters.Add("@NewUserKey",Common.UserInfoObj.UserKey).Direction= ParameterDirection.Output;

            //obj_paramters["@NewUserKey"].DbType = DbType.String;
          
            var result = ((IObjectContextAdapter)Dap).ObjectContext.ExecuteFunction<T>(spName);

            //output.Add("NewUserKey", p.Where(w => w.Name == "NewUserKey").Single())
             ;
           
           // var list = Dap .ModelListSPOutput<T>(spName, field, Outputparam, out output);
            //CheckUserKey(output);
            return result.ToList();
        }

        //public int NonQuerySP(string spName, Dictionary<String, Object> field)
        //{
        //    field.Add("UserKey", Common.UserInfoObj.UserKey);
            
        //    field.Add("IP", Common.UserInfoObj);
        //    Dictionary<String, DbType> Outputparam = new Dictionary<string, DbType>();
        //    Outputparam.Add("NewUserKey", DbType.String);
        //    Dictionary<String, Object> output;
        //    int result = Dap.NonQuerySPOutput(spName, field, Outputparam, out output);
        //    CheckUserKey(output);
        //    return result;
        //}

        //public Dictionary<String, Object> NonQuerySPOutput(string spName, Dictionary<String, Object> field, Dictionary<String, DbType> Outputparam)
        //{
        //    field.Add("UserKey", Common.UserInfoObj.UserKey);
        //    field.Add("IP", Common.UserInfoObj.IP);
        //    Outputparam.Add("NewUserKey", DbType.String);
        //    Dictionary<String, Object> output;
        //    Dap.NonQuerySPOutput(spName, field, Outputparam, out output);
        //    CheckUserKey(output);
        //    return output;
        //}

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