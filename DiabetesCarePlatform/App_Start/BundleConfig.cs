using DiabetesCarePlatform.Helpers;
using DiabetesCarePlatform.Helpers.MVCExtras;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Optimization;

namespace DiabetesCarePlatform
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            Repository.FileIORepository fiorepo = new Repository.FileIORepository();

            Dictionary<string, BundleSettingDatawithjson> customcssjsonfile_content =
            fiorepo.LoadSettingDataFromJSONFile<Dictionary<string, BundleSettingDatawithjson>>("bundles.json");

            foreach (string key in customcssjsonfile_content.Keys)
            {
                if (customcssjsonfile_content[key].IsCSS)
                {
                    if (customcssjsonfile_content[key].IsCDN)
                    {
                        var cdncss = new StyleBundle(key);
                        cdncss.CdnPath = customcssjsonfile_content[key].Files[0];
                        bundles.Add(cdncss);
                    }
                    else
                    {
                        bundles.Add(new StyleBundle(key).Include(
               customcssjsonfile_content[key].Files));
                    }

                }
                else
                {
                    bundles.Add(new ScriptBundle(key).Include(
                       customcssjsonfile_content[key].Files
                        ));
                }
            }
        }
    }
}
