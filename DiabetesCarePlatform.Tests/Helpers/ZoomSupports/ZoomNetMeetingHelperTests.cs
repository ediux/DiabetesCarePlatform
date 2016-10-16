using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesCarePlatform.Helpers.ZoomSupports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiabetesCarePlatform.Helpers.JSON.Zoom;
namespace DiabetesCarePlatform.Helpers.ZoomSupports.Tests
{
    [TestClass()]
    public class ZoomNetMeetingHelperTests
    {
        private string postUrl = System.Configuration.ConfigurationManager.AppSettings["ZOOM_API_URL"];
        private const string test_USERID = "j0smGf5Adb7EBqy2XhVfK3PN5YD0q3";

        [TestMethod()]
        public void User_ListTest()
        {
            
        }

        [TestMethod()]
        public void meeting_listTest()
        {
            
            
        }

        [TestMethod()]
        public void meeting_createTest()
        {
            //string API_USERID = test_USERID;

            //zoom_meeting_create ZOOM_data = ZoomNetMeetingRepository.meeting_create(new Controllers.DCPController(), postUrl, API_USERID, "test API 05­29 NOW");

            //Assert.AreEqual("0", ZOOM_data.code);           
        }

        [TestMethod()]
        public void meeting_deleteTest()
        {
          
        }

        [TestMethod()]
        public void meeting_updateTest()
        {
            
        }

        [TestMethod()]
        public void meeting_getTest()
        {
            
        }

        [TestMethod()]
        public void Test_Zoom_APITest()
        {
            
        }
    }
}
