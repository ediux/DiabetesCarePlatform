using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.MVCExtras
{
    public class BundleSettingDatawithjson
    {
        public BundleSettingDatawithjson()
        {
            iscss = false;
            iscdn = false;
            files = new string[] { };
        }
        private bool iscdn;
        public bool IsCDN { get { return iscdn; } set { iscdn = value; } }
        private bool iscss;
        public bool IsCSS { get { return iscss; } set { iscss = value; } }

        private string[] files;
        public string[] Files { get { return files; } set { files = value; } }
    }
}