using DiabetesCarePlatform.Data;
using DiabetesCarePlatform.Helpers.JSON.Zoom;
using Microsoft.Owin;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.Data.Entity.Validation;
using DiabetesCarePlatform.Repository;

namespace DiabetesCarePlatform.Helpers.ZoomSupports
{
    /// <summary>
    /// Zoom視訊會議相關支援之靜態類別(擴充方法)
    /// </summary>
    public class ZoomNetMeetingRepository
    {
        private static int ReCacheSeconds = 60; //更新快取秒數
        private static int lastupdatepagenumber;    //紀錄最後一次更新頁次 -1則是清除重新載入
        private static int limitroomcount = 10;
        public const string CacheName = "MemoryJSONDb";

        private ZoomSetting settings;

        public ZoomNetMeetingRepository()
        {

            settings = HttpRuntime.Cache.Get(CacheName) as ZoomSetting;

            if (settings == null)
            {
                settings = LoadZoomSettings();
            }
        }

        #region 使用者類

        public zoom_user_list User_List(int page_size, int page_number)
        {

            if (settings == null)
            {
                settings = LoadZoomSettings();
            }

            SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();

            paramters.Add("API_Key", settings.ApiKey);
            paramters.Add("API_Secret", settings.ApiSecet);
            paramters.Add("api", "user_list");
            paramters.Add("page_size", page_size.ToString());
            paramters.Add("page_number", page_number.ToString());

            zoom_user_list ZOOM_data = CallRemoteRESTService<zoom_user_list>(settings.URL, Method.POST, ProcessingZOOMRPCParamters(paramters));

            return ZOOM_data;
        }

        public zoom_user_get User_Get(string id)
        {
            ZoomSetting settings = HttpRuntime.Cache.Get(CacheName) as ZoomSetting;

            if (settings == null)
            {
                settings = LoadZoomSettings();
            }

            SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();

            paramters.Add("API_Key", settings.ApiKey);
            paramters.Add("API_Secret", settings.ApiSecet);
            paramters.Add("api", "user_get");
            paramters.Add("id", id);

            zoom_user_get ZOOM_data = CallRemoteRESTService<zoom_user_get>(settings.URL, Method.POST, ProcessingZOOMRPCParamters(paramters));

            return ZOOM_data;
        }

        public zoom_user_update User_Update(string id, string first_name, string last_name, bool disable_chat, bool enable_e2e_encryption,
            bool enable_silent_mode, bool disable_group_hd, bool disable_recording, string pmi,
            int auto_recording, bool disable_feedback, bool disable_jbh_reminder)
        {
            ZoomSetting settings = HttpRuntime.Cache.Get(CacheName) as ZoomSetting;

            if (settings == null)
            {
                settings = LoadZoomSettings();
            }

            SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();

            paramters.Add("API_Key", settings.ApiKey);
            paramters.Add("API_Secret", settings.ApiSecet);
            paramters.Add("api", "user_update");
            paramters.Add("id", id);

            zoom_user_update ZOOM_data = CallRemoteRESTService<zoom_user_update>(settings.URL, Method.POST, ProcessingZOOMRPCParamters(paramters));

            return ZOOM_data;
        }

        #endregion

        #region 會議類API


        public zoom_meeting_list meeting_list(string hostid, int page_size = 30, int page_number = 1)
        {
            ZoomSetting settings = HttpRuntime.Cache.Get(CacheName) as ZoomSetting;

            if (settings == null)
            {
                settings = LoadZoomSettings();
            }

            SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();

            paramters.Add("API_Key", settings.ApiKey);
            paramters.Add("API_Secret", settings.ApiSecet);
            paramters.Add("api", "meeting_list");
            paramters.Add("host_id", hostid);
            paramters.Add("page_size", page_size.ToString());
            paramters.Add("page_number", page_number.ToString());

            zoom_meeting_list ZOOM_data = CallRemoteRESTService<zoom_meeting_list>(settings.URL, Method.POST, ProcessingZOOMRPCParamters(paramters));

            if (CheckResponseForMeetingListIsSuccess(ZOOM_data))
            {

                foreach (var item in ZOOM_data.data.meetings)
                {
                    item.created_at = item.created_at.AddHours(8);
                }
            }

            return ZOOM_data;
        }

        private static bool CheckResponseForMeetingListIsSuccess(zoom_meeting_list response)
        {
            if (response == null)
                return false;

            if (response.code != "0")
                return false;

            return true;
        }

        /// <summary>
        /// 建立會議
        /// </summary>
        /// <param name="ctr"></param>
        /// <param name="postUrl"></param>
        /// <param name="API_USERID"></param>
        /// <param name="Topic"></param>
        /// <param name="StartTime"></param>
        /// <param name="Duration"></param>
        /// <param name="MeetingType"></param>
        /// <param name="TimeZone"></param>
        /// <param name="Password"></param>
        /// <param name="OptionJBH"></param>
        /// <param name="OptionStartType"></param>
        /// <param name="OptionHostVideo"></param>
        /// <param name="OptionParticipantsVideo"></param>
        /// <param name="OptionAudio"></param>
        /// <returns></returns>
        public zoom_meeting_create meeting_create(
            string API_USERID,
            string Topic, DateTime? StartTime = null, int? Duration = null, int MeetingType = 1,
            string TimeZone = "", string Password = "", bool OptionJBH = false,
            string OptionStartType = "video", bool OptionHostVideo = true,
            bool OptionParticipantsVideo = true, string OptionAudio = "both")
        {
            ZoomSetting settings = HttpRuntime.Cache.Get(CacheName) as ZoomSetting;

            if (settings == null)
                settings = LoadZoomSettings();
            #region ZOOM原廠範例說明
            ///* 參數組成 start */
            ///* 此區塊的參數 key 值必須依字母做排序 */
            //paramData = "&api=meeting_create";
            //paramData += "&host_id=" + API_USERID;
            //paramData += "&topic=test API 05­29 NOW";
            //paramData += "&type=3";
            //paramData += "&";
            ///* 參數組成 end */
            //
            //md5str = "API_Key=" + API_Key + paramData + "API_Secret=" + API_Secret;
            //md5str = md5str.ToLower();

            //md5str = System.Text.Encoding.Unicode.GetString(CryMD5.ComputeHash(System.Text.Encoding.Unicode.GetBytes(md5str)));
            //md5str = md5str.ToUpper();
            //paramData = "API_Key=" + API_Key + paramData + "check_value=" + md5str; 
            #endregion

            SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();

            paramters.Add("API_Key", settings.ApiKey);
            paramters.Add("API_Secret", settings.ApiSecet);
            paramters.Add("api", "meeting_create");
            paramters.Add("host_id", API_USERID);
            if (Topic.Length > 300 || Topic.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            paramters.Add("topic", Topic);
            paramters.Add("type", MeetingType.ToString());
            if (StartTime.HasValue)
            {
                StartTime = new DateTime?(StartTime.Value);

                paramters.Add("start_time", StartTime.Value.ToString());
            }
            if (Duration.HasValue)
            {
                paramters.Add("duration", Duration.Value.ToString());
            }
            if (!string.IsNullOrEmpty(TimeZone))
            {

                paramters.Add("timezone", TimeZone);
            }
            //else
            //{
            //    if (MeetingType == 2)
            //    {

            //        paramters.Add("timezone", "Taiwan/Taipei");
            //    }
            //}

            if (!string.IsNullOrEmpty(Password))
            {
                paramters.Add("password", Password);
            }
            paramters.Add("option_jbh", OptionJBH.ToString());
            paramters.Add("option_start_type", OptionStartType.ToString());
            paramters.Add("option_host_video", OptionHostVideo.ToString());
            paramters.Add("option_participants_video", OptionParticipantsVideo.ToString());
            paramters.Add("option_audio", OptionAudio);

            string strParam = ProcessingZOOMRPCParamters(paramters);

            zoom_meeting_create ZOOM_data = CallRemoteRESTService<zoom_meeting_create>(settings.URL, Method.POST, strParam);

            if (ZOOM_data.code == "0")
            {
                meeting_create_data item = ZOOM_data.data;
                meeting_list_data new_data = new meeting_list_data();
                new_data.uuid = item.uuid;
                new_data.type = item.type;
                new_data.topic = item.topic;
                new_data.timezone = item.timezone;
                new_data.status = 0;
                new_data.start_url = item.start_url;

                if (StartTime.HasValue && item.type == 2)
                {
                    new_data.start_time = new Nullable<DateTime>(StartTime.Value).Value;
                }
                else
                {
                    if (item.type == 2)
                    {
                        new_data.start_time = new Nullable<DateTime>(StartTime.Value).Value;
                    }
                }
                new_data.password = item.password;
                new_data.option_start_type = item.option_start_type;
                new_data.option_participants_video = item.option_particioants_video;
                new_data.option_jbh = item.option_jbh;
                new_data.option_host_video = item.option_host_video;
                new_data.option_audio = item.option_audio;
                new_data.join_url = item.join_url;
                new_data.id = item.id;
                new_data.host_id = item.host_id;
                new_data.duration = item.duration;
                new_data.created_at = item.created_at;

            }

            return ZOOM_data;
        }

        public zoom_meeting_delete meeting_delete(
            string id,
            string hostid)
        {
            ZoomSetting settings = HttpRuntime.Cache.Get(CacheName) as ZoomSetting;

            SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();

            paramters.Add("API_Key", settings.ApiKey);
            paramters.Add("API_Secret", settings.ApiSecet);
            paramters.Add("api", "meeting_delete");
            paramters.Add("id", id);
            paramters.Add("host_id", hostid);

            zoom_meeting_delete zoom_response = CallRemoteRESTService<zoom_meeting_delete>(settings.URL, Method.POST, ProcessingZOOMRPCParamters(paramters));

            return zoom_response;
        }

        public zoom_meeting_update meeting_update(
            string Id,
            string HostId,
            string Topic,
            int MeetingType = 1,
            DateTime? StartTime = null,
            int? Duration = null,
            string TimeZone = null,
            string Password = null,
            bool OptionJBH = false,
            string OptionStartType = "video",
            bool OptionHostVideo = false,
            bool OptionParticipantsVideo = false,
            string OptionAudio = "both")
        {
            ZoomSetting settings = HttpRuntime.Cache.Get(CacheName) as ZoomSetting;

            #region ZOOM原廠範例說明
            ///* 參數組成 start */
            ///* 此區塊的參數 key 值必須依字母做排序 */
            //paramData = "&api=meeting_create";
            //paramData += "&host_id=" + API_USERID;
            //paramData += "&topic=test API 05­29 NOW";
            //paramData += "&type=3";
            //paramData += "&";
            ///* 參數組成 end */
            //
            //md5str = "API_Key=" + API_Key + paramData + "API_Secret=" + API_Secret;
            //md5str = md5str.ToLower();

            //md5str = System.Text.Encoding.Unicode.GetString(CryMD5.ComputeHash(System.Text.Encoding.Unicode.GetBytes(md5str)));
            //md5str = md5str.ToUpper();
            //paramData = "API_Key=" + API_Key + paramData + "check_value=" + md5str; 
            #endregion

            SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();

            paramters.Add("API_Key", settings.ApiKey);
            paramters.Add("API_Secret", settings.ApiSecet);
            paramters.Add("api", "meeting_update");
            paramters.Add("host_id", HostId);
            if (Topic.Length > 300 || Topic.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            paramters.Add("topic", Topic);
            paramters.Add("type", MeetingType.ToString());
            if (StartTime.HasValue)
            {
                paramters.Add("start_time", StartTime.Value.ToUniversalTime().ToString());
            }
            if (Duration.HasValue)
            {
                paramters.Add("duration", Duration.Value.ToString());
            }
            if (!string.IsNullOrEmpty(TimeZone))
            {
                paramters.Add("timezone", TimeZone);
            }
            if (!string.IsNullOrEmpty(Password))
            {
                paramters.Add("password", Password);
            }
            paramters.Add("option_jbh", OptionJBH.ToString());
            paramters.Add("option_start_type", OptionStartType.ToString());
            paramters.Add("option_host_video", OptionHostVideo.ToString());
            paramters.Add("option_participants_video", OptionParticipantsVideo.ToString());
            paramters.Add("option_audio", OptionAudio);

            string strParam = ProcessingZOOMRPCParamters(paramters);

            zoom_meeting_update ZOOM_data = CallRemoteRESTService<zoom_meeting_update>(settings.URL, Method.POST, strParam);

            return ZOOM_data;
        }

        public zoom_meeting_get meeting_get(
            string id,
            string hostid)
        {
            ZoomSetting settings = HttpRuntime.Cache.Get(CacheName) as ZoomSetting;

            SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();

            paramters.Add("API_Key", settings.ApiKey);
            paramters.Add("API_Secret", settings.ApiSecet);
            paramters.Add("api", "meeting_get");
            paramters.Add("id", id);
            paramters.Add("host_id", hostid);

            zoom_meeting_get zoom_response = CallRemoteRESTService<zoom_meeting_get>(settings.URL, Method.POST, ProcessingZOOMRPCParamters(paramters));

            //if (MemoryDb.ScheduleTimes.ContainsKey(zoom_response.data.uuid))
            //    zoom_response.data.start_time = MemoryDb.ScheduleTimes[zoom_response.data.uuid].AddHours(-8);

            return zoom_response;
        }
        #endregion

        #region 報表類

        public zoom_report_getalluserreport report_getalluserreport(DateTime from, DateTime to, int page_size = 30, int page_number = 1)
        {

            ZoomSetting settings = HttpRuntime.Cache.Get(CacheName) as ZoomSetting;

            SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();

            paramters.Add("API_Key", settings.ApiKey);
            paramters.Add("API_Secret", settings.ApiSecet);
            paramters.Add("api", "report_getalluserreport");
            paramters.Add("from", from.ToString());
            paramters.Add("to", to.ToString());
            paramters.Add("page_size", page_size.ToString());
            paramters.Add("page_number", page_number.ToString());

            zoom_report_getalluserreport response = CallRemoteRESTService<zoom_report_getalluserreport>(settings.URL, Method.POST, ProcessingZOOMRPCParamters(paramters));

            return response;

        }

        private bool CheckResponseForReportgetalluserreportIsSuccess(zoom_report_getalluserreport reportrepository)
        {
            if (reportrepository == null)
                return false;

            if (reportrepository.code != "0")
                return false;

            return true;
        }
        #endregion

        #region Helper functions

        public string MD5Encryption(string inputstr)
        {
            byte[] convertedbytes =
            Encoding.UTF8.GetBytes(inputstr);

            MD5 CryMD5 = MD5.Create();
            byte[] hashedbytes = CryMD5.ComputeHash(convertedbytes);

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < hashedbytes.Length; i++)
            {
                sBuilder.Append(hashedbytes[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();

        }

        /// <summary>
        /// 呼叫Zoom視訊會議廠商的REST API 服務
        /// </summary>
        /// <typeparam name="TMessage">傳回訊息的序列化類別</typeparam>
        /// <param name="postUrl">服務URL</param>
        /// <param name="rpcparamters">傳遞的參數</param>
        /// <returns>遠端傳回執行結果之JSON訊息</returns>
        public string ProcessingZOOMRPCParamters(SortedDictionary<string, string> rpcparamters)
        {
            string apikey = rpcparamters["API_Key"];
            apikey = string.Format("API_Key={0}", apikey);
            rpcparamters.Remove("API_Key");

            string apisecret = rpcparamters["API_Secret"];
            apisecret = string.Format("API_Secret={0}", apisecret);
            rpcparamters.Remove("API_Secret");

            string paramData = "";
            string md5str = "";

            paramData = string.Join("&",
                rpcparamters.Select(s => string.Format("{0}={1}", s.Key, s.Value)).ToArray());

            md5str = string.Format("{0}&{1}&{2}", apikey, paramData, apisecret);
            md5str = md5str.ToLower();

            //for test use
            //string oldway = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(md5str, "MD5");

            md5str = MD5Encryption(md5str);
            md5str = md5str.ToUpper();

            paramData = string.Format("{0}&{1}&check_value={2}", apikey, paramData, md5str);

            return paramData;
        }

        /// <summary>
        /// 建立REST API用戶端並傳送要求到遠端伺服器。
        /// </summary>
        /// <typeparam name="TMessage">傳回的JSON訊息序列化類型</typeparam>
        /// <param name="postUrl">遠端服務位置。</param>
        /// <param name="method">傳送要求網頁方法</param>
        /// <param name="paramData">參數內容</param>
        /// <returns>遠端傳回執行結果之JSON訊息</returns>
        private TMessage CallRemoteRESTService<TMessage>(string postUrl, Method method, string paramData)
        {
            var client = new RestClient(postUrl);
            var request = new RestRequest(method);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/x-www-form-urlencoded", paramData, ParameterType.RequestBody);

            //MemoryDb.lastaccesstime = DateTime.Now;

            IRestResponse response = client.Execute(request);

            string result = response.Content;

            TMessage data = Newtonsoft.Json.JsonConvert.DeserializeObject<TMessage>(result);
            return data;
        }

        #endregion

        #region 處理設定值快取
        public static ZoomSetting LoadZoomSettings()
        {
            ZoomSetting settings = HttpRuntime.Cache.Get(CacheName) as ZoomSetting;

            if (settings == null)
            {
                settings = new ZoomSetting();

                settings.URL = System.Web.Configuration.WebConfigurationManager.AppSettings["ZOOM_API_URL"];
                settings.ApiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["ZOOM_API_Key"];
                settings.ApiSecet = System.Web.Configuration.WebConfigurationManager.AppSettings["ZOOM_API_Secret"];
                settings.HostId = System.Web.Configuration.WebConfigurationManager.AppSettings["ZOOM_User_ID"];
                settings.RoomAmountMaxiLimit = 10;
                settings.CurrentPage = 1;
                settings.NextPage = 1;
                settings.TotalPage = 1;
                settings.PageSize = 300;
            }

            return settings;
        }

        #endregion

        #region 處理對會議室資訊資料表的定時更新背景程序
        public static CacheItemUpdateCallback itemUpdateCallback = null;
        public static CacheItemRemovedCallback OnCacheRemove = null;

        public static void AddFirstCache()
        {
            ZoomNetMeetingRepository staticZoomNetMeetingRepo = new ZoomNetMeetingRepository();

            ZoomSetting settings = LoadZoomSettings();

            OnCacheRemove = new CacheItemRemovedCallback(onRemove);

            HttpRuntime.Cache.Add(CacheName, settings, null,
                  DateTime.Now.AddSeconds(ReCacheSeconds), Cache.NoSlidingExpiration,
                  CacheItemPriority.NotRemovable, OnCacheRemove);
        }

        public static void onRemove(string key, object value, CacheItemRemovedReason reason)
        {
            switch (reason)
            {
                case CacheItemRemovedReason.DependencyChanged:
                    break;
                case CacheItemRemovedReason.Expired:
                    {

                        ZoomSetting settings = value as ZoomSetting;

                        WorkShiftRepository workshiftrepository = new WorkShiftRepository();
                        ZoomNetMeetingRepository zoomnetmeetingrepository = new ZoomNetMeetingRepository();


                        try
                        {
                            if (settings.CurrentPage != settings.NextPage)
                            {
                                var list = zoomnetmeetingrepository.meeting_list(settings.HostId, page_number: settings.NextPage, page_size: settings.PageSize);

                                if (CheckResponseForMeetingListIsSuccess(list))
                                {
                                    settings.TotalPage = list.data.page_count;
                                    settings.PageSize = list.data.page_size;

                                    if (settings.NextPage <= settings.TotalPage)
                                    {
                                        settings.NextPage += 1;
                                    }
                                    else
                                    {
                                        settings.NextPage = settings.CurrentPage = 1;
                                    }

                                    var totalcurrentrows = new List<meeting_list_data>(list.data.meetings);

                                    var existskeys = workshiftrepository.SP_GetAllSYS_ZoomMeetings().Select(s => s.uuid).ToArray();
                                    var currentkeys = totalcurrentrows.Select(s => s.uuid).ToArray();

                                    var addnew = currentkeys.Except(existskeys).ToArray();
                                    var deleterow = existskeys.Except(currentkeys).ToArray();

                                    #region 處理刪除的部分
                                    foreach (var c in totalcurrentrows.Where(k => deleterow.Contains(k.uuid)))
                                    {
                                        var rmrow = new MR_ZoomMeetings()
                                        {
                                            created_at = c.created_at,
                                            duration = c.duration,
                                            host_id = c.host_id,
                                            Id = c.id,
                                            join_url = c.join_url,
                                            option_audio = c.option_audio,
                                            option_host_video = c.option_host_video,
                                            option_jbh = c.option_jbh,
                                            option_participants_video = c.option_participants_video,
                                            option_start_type = c.option_start_type,
                                            password = c.password,
                                            start_time = c.start_time,
                                            start_url = c.start_url,
                                            timezone = c.timezone,
                                            topic = c.topic,
                                            type = c.type,
                                            uuid = c.uuid
                                        };
                                        workshiftrepository.SP_DeleteMR_ZoomMeetings(rmrow);
                                    }
                                    #endregion

                                    #region 處理新增的部分
                                    foreach (var c in totalcurrentrows.Where(k => addnew.Contains(k.uuid)))
                                    {
                                        var rmrow = new MR_ZoomMeetings()
                                        {
                                            created_at = c.created_at,
                                            duration = c.duration,
                                            host_id = c.host_id,
                                            Id = c.id,
                                            join_url = c.join_url,
                                            option_audio = c.option_audio,
                                            option_host_video = c.option_host_video,
                                            option_jbh = c.option_jbh,
                                            option_participants_video = c.option_participants_video,
                                            option_start_type = c.option_start_type,
                                            password = c.password,
                                            start_time = c.start_time,
                                            start_url = c.start_url,
                                            timezone = c.timezone,
                                            topic = c.topic,
                                            type = c.type,
                                            uuid = c.uuid
                                        };

                                        workshiftrepository.SP_AddMR_ZoomMeetings(rmrow);
                                    }
                                    #endregion

                                }


                                HttpRuntime.Cache.Insert(CacheName, settings, null,
                                           DateTime.Now.AddSeconds(15), Cache.NoSlidingExpiration,
                                           CacheItemPriority.NotRemovable, OnCacheRemove);
                            }
                            else
                            {
                                var list = zoomnetmeetingrepository.meeting_list(settings.HostId, page_number: settings.CurrentPage, page_size: settings.PageSize);

                                if (list == null)
                                {
                                    throw new Exception("Nothing return from remote system.");
                                }

                                settings.TotalPage = list.data.page_count;
                                settings.PageSize = list.data.page_size;

                                if (settings.NextPage <= settings.TotalPage)
                                {
                                    settings.NextPage = settings.CurrentPage + 1;
                                }

                                var totalcurrentrows = new List<meeting_list_data>(list.data.meetings);

                                var existskeys = workshiftrepository.SP_GetAllSYS_ZoomMeetings().Select(s => s.uuid).ToArray();
                                var currentkeys = totalcurrentrows.Select(s => s.uuid).ToArray();

                                var addnew = currentkeys.Except(existskeys).ToArray();
                                var deleterow = existskeys.Except(currentkeys).ToArray();

                                #region 處理刪除的部分
                                foreach (var c in totalcurrentrows.Where(k => deleterow.Contains(k.uuid)))
                                {
                                    var rmrow = new MR_ZoomMeetings()
                                    {
                                        created_at = c.created_at,
                                        duration = c.duration,
                                        host_id = c.host_id,
                                        Id = c.id,
                                        join_url = c.join_url,
                                        option_audio = c.option_audio,
                                        option_host_video = c.option_host_video,
                                        option_jbh = c.option_jbh,
                                        option_participants_video = c.option_participants_video,
                                        option_start_type = c.option_start_type,
                                        password = c.password,
                                        start_time = c.start_time,
                                        start_url = c.start_url,
                                        timezone = c.timezone,
                                        topic = c.topic,
                                        type = c.type,
                                        uuid = c.uuid
                                    };
                                    workshiftrepository.SP_DeleteMR_ZoomMeetings(rmrow);
                                }
                                #endregion

                                #region 處理新增的部分
                                foreach (var c in totalcurrentrows.Where(k => addnew.Contains(k.uuid)))
                                {
                                    var rmrow = new MR_ZoomMeetings()
                                    {
                                        created_at = c.created_at,
                                        duration = c.duration,
                                        host_id = c.host_id,
                                        Id = c.id,
                                        join_url = c.join_url,
                                        option_audio = c.option_audio,
                                        option_host_video = c.option_host_video,
                                        option_jbh = c.option_jbh,
                                        option_participants_video = c.option_participants_video,
                                        option_start_type = c.option_start_type,
                                        password = c.password,
                                        start_time = c.start_time,
                                        start_url = c.start_url,
                                        timezone = c.timezone,
                                        topic = c.topic,
                                        type = c.type,
                                        uuid = c.uuid
                                    };

                                    workshiftrepository.SP_AddMR_ZoomMeetings(rmrow);
                                }
                                #endregion


                            }

                            if (settings.CurrentPage == settings.NextPage)
                            {
                                HttpRuntime.Cache.Insert(CacheName, settings, null,
                                           DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration,
                                           CacheItemPriority.NotRemovable, OnCacheRemove);
                            }
                            else
                            {
                                HttpRuntime.Cache.Insert(CacheName, settings, null,
                                           DateTime.Now.AddSeconds(10), Cache.NoSlidingExpiration,
                                           CacheItemPriority.NotRemovable, OnCacheRemove);
                            }

                            OnCacheRemove = new CacheItemRemovedCallback(onRemove);
                        }
                        catch (DbEntityValidationException ex)
                        {
                            if (ex.EntityValidationErrors.Any())
                            {
                                StringBuilder msg = new StringBuilder();
                                foreach (var err in ex.EntityValidationErrors)
                                {
                                    foreach (var msgstr in err.ValidationErrors)
                                    {
                                        msg.Append(msgstr.ErrorMessage);
                                    }
                                }

                                System.Diagnostics.Debug.Write(msg.ToString());
                            }

                            HttpRuntime.Cache.Insert(CacheName, settings, null,
                                          DateTime.Now.AddSeconds(10), Cache.NoSlidingExpiration,
                                          CacheItemPriority.NotRemovable, OnCacheRemove);
                        }

                        //因過期所以重新設定快取
                        //AddTask(key, ReCacheSeconds);

                        break;
                    }
                case CacheItemRemovedReason.Removed:
                    {
                        //meetingroomlistcache = value as Hashtable;
                        //meetingroomlistcache = null;

                        break;
                    }
                case CacheItemRemovedReason.Underused:
                    {
                        break;
                    }

                default: break;
            }

        }

        public static void OnUpdate(string key, CacheItemUpdateReason reason, out object value, out CacheDependency dependency, out DateTime exipriation, out TimeSpan slidingExpiration)
        {


            //var filepath = HttpContext.Current.Server.MapPath("/somefile.xml");
            //var doc = XElement.Load(filepath);
            //dependency = new CacheDependency(filepath);
            ZoomNetMeetingRepository znmr = new ZoomNetMeetingRepository();

            dependency = null;
            var response = znmr.report_getalluserreport(DateTime.Now.ToUniversalTime().AddMonths(-1), DateTime.Now.ToUniversalTime().AddMonths(+1));
            exipriation = DateTime.Now.AddSeconds(ReCacheSeconds);
            slidingExpiration = TimeSpan.FromMinutes(5);
            ZoomSetting settings = new ZoomSetting();
            settings.URL = System.Web.Configuration.WebConfigurationManager.AppSettings["ZOOM_API_URL"];
            settings.ApiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["ZOOM_API_Key"];
            settings.ApiSecet = System.Web.Configuration.WebConfigurationManager.AppSettings["ZOOM_API_Secret"];
            settings.HostId = System.Web.Configuration.WebConfigurationManager.AppSettings["ZOOM_User_ID"];
            settings.RoomAmountMaxiLimit = 10;
            value = settings;
        }
        #endregion
    }
}