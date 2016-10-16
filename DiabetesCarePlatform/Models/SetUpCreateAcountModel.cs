using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class SetUpCreateAcountModel
    {
        public List<SYS_BloodType> BloodTypeList { get; set; }
        public List<SYS_RaceType>  RaceTypeeList { get; set; }
        public List<SYS_LivingStatus> LivingStatusList { get; set; }
        public List<PMRTagNameCBViewModel> PMRTagNameCBList { get; set; }
        public List<SYS_RelationshipType> RelationshipList { get; set; }
        public List<SYS_ChronicSubType> ChronicSubTypeList { get; set; }
        public List<APP_User> APPUserList { get; set; }
        public List<string> Tabs { get; set; }
    }
}