using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class MemberPage
    {
        public List<APP_User_Extend> UserList { get; set; }
        public List<SYS_SexType> SexTypeList { get; set; }
        public List<JsTree> UnitTree { get; set; }
    }
}