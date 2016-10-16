using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Repository
{
    public class FileIORepository
    {
        #region 讀取JSON檔案並且反序列化
        public  TLoadedData LoadSettingDataFromJSONFile<TLoadedData>(string alt_filepath) where TLoadedData : class
        {
            string wwwroot = HttpRuntime.AppDomainAppPath;
            string menupatternjsonfile = Path.Combine(wwwroot, "Content", "JSON", alt_filepath);

            FileStream customcssjsonfilestream = new FileStream(menupatternjsonfile, FileMode.Open);
            StreamReader customcssjsonreader = new StreamReader(customcssjsonfilestream);

            var customcssjsonfile_content = Newtonsoft.Json.JsonConvert.DeserializeObject<TLoadedData>(customcssjsonreader.ReadToEnd());

            customcssjsonreader.Close();

            return customcssjsonfile_content;
        }
        public  void SaveSettingDataToJSONFile<TSavedData>(string alt_filepath, TSavedData source) where TSavedData : class
        {
            string wwwroot = HttpRuntime.AppDomainAppPath;
            string menupatternjsonfile = Path.Combine(wwwroot, "Content", "JSON", alt_filepath);

            FileStream customcssjsonfilestream = new FileStream(menupatternjsonfile, FileMode.Create);
            StreamWriter customcssjsonwriter = new StreamWriter(customcssjsonfilestream);

            string customcssjsonfile_content = Newtonsoft.Json.JsonConvert.SerializeObject(source);

            customcssjsonwriter.Write(customcssjsonfile_content);

            customcssjsonwriter.Close();
        }
        #endregion
    }
}