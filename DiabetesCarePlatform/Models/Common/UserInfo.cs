using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.Common
{
    public class UserInfo : Web_GetUserInfo_Result
    {
        public UserInfo()
        {
            
            id = 0;
            userkey = string.Empty;
            
        }
        
        
        private int id;
        public new int ID { get { return id; } set { id = value; } }
        //public string Account { get; set; }
        public string Password { get; set; }
        //public string Name { get; set; }

        //public int ParentUnitID { get; set; }
        private string userkey;
        public new string UserKey { get { return userkey; } set { userkey = value; } }
        public string IP { get; set; }
    }
}