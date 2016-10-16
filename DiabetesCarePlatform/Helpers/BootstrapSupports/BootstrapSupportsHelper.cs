using DiabetesCarePlatform.Helpers;
using DiabetesCarePlatform.Helpers.MVCExtras;
using DiabetesCarePlatform.Models;
using DiabetesCarePlatform.Models.Interfaces;
using DiabetesCarePlatform.Models.SystemCore;
using DiabetesCarePlatform.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace BootstrapSupports
{
    /// <summary>
    /// 提供Bootstrap v3.x 產生對應於ViewPage中的HTML擴充方法與框架流程擴充方法的Helper類別
    /// </summary>
    public static class BootstrapSupportsHelper
    {
        #region 內部靜態共用變數區
        private static Hashtable _StyleCache;
        private static Hashtable _MenuItemsCache;
        private static Hashtable _TopMenuItemCache;
        private static Hashtable _MenuItemPatternCache;
        #endregion

        #region CSS類
        public static HtmlString GetCustomCSSClass(this HtmlHelper htmlhelper, string Name)
        {
            if (_StyleCache == null)
            {

                _StyleCache = new Hashtable();
            }

            if (_StyleCache.ContainsKey(Name))
            {
                return new HtmlString(_StyleCache[Name] as string);
            }
            else
            {
                FileIORepository fiorepo = new FileIORepository();

                var customcssjsonfile_content =
                    fiorepo.LoadSettingDataFromJSONFile<Dictionary<string, dynamic>>("customstyles.json");

                _StyleCache.Add(Name, customcssjsonfile_content[Name] as string);

                return new HtmlString(_StyleCache[Name] as string);
            }
        }
        #endregion

        #region 選單類

        public static IHtmlString TopNavigation(this HtmlHelper helper)
        {
            // 建立選單流程:
            // 1.依據參數設定載入對應的CSS
            // 2.先取得主選單第一層選單項目清單
            // 3.使用迴圈掃瞄清單中的每個項目
            // 4.比對目前選單停留在哪個項目上

            // 5.產生HTML內容
            // 6.若項目有子項目則進入子選單建立流程
            // 7.回傳產生的內容

            var tagBuilders = new List<TagBuilder>();

            var mainmenus = GetMainMenu(helper, new SinglePageViewModel());

            LoadMenuItemPattern();

            if (mainmenus == null)
                return new HtmlString(string.Empty);

            TagBuilder ul = new TagBuilder("ul");

            string rootstyle = GetCustomCSSClass(helper, "topmenurootul").ToHtmlString();


            if (!string.IsNullOrEmpty(rootstyle))
            {
                ul.AddCssClass(rootstyle);
            }

            var ordered_menus = _TopMenuItemCache.Values.Cast<MenuwithJSONData>().OrderBy(o => o.Index);

            foreach (MenuwithJSONData data in ordered_menus)
            {

                if (data == null)
                    continue;

                if (CurrentRouteMatchesName(helper, data))
                {
                    if (data.SubMenus != null && data.SubMenus.Any())
                    {
                        ul = GenTagHtmlNode(helper, _MenuItemPatternCache["topsubmenuwithicon.active"] as MenuItemPatternJSONData, ul, data);
                    }
                    else
                    {
                        ul = GenTagHtmlNode(helper, _MenuItemPatternCache["notopsubmenuwithicon.active"] as MenuItemPatternJSONData, ul, data);
                    }
                }
                else
                {
                    if (data.SubMenus != null && data.SubMenus.Any())
                    {
                        ul = GenTagHtmlNode(helper, _MenuItemPatternCache["topsubmenuwithicon"] as MenuItemPatternJSONData, ul, data);
                    }
                    else
                    {
                        ul = GenTagHtmlNode(helper, _MenuItemPatternCache["notopsubmenuwithicon"] as MenuItemPatternJSONData, ul, data);
                    }
                }

            }

            return MvcHtmlString.Create(ul.ToString(TagRenderMode.Normal));
        }

        public static IHtmlString Navigation(this HtmlHelper helper)
        {
            var tagBuilders = new List<TagBuilder>();

            var mainmenus = GetLeftSideBarMainMenu(helper, new SinglePageViewModel());

            LoadMenuItemPattern();

            if (mainmenus == null)
                return new HtmlString(string.Empty);

            TagBuilder ul = new TagBuilder("ul");

            string rootstyle = GetCustomCSSClass(helper, "mainmenurootul").ToHtmlString();

            if (!string.IsNullOrEmpty(rootstyle))
            {
                ul.AddCssClass(rootstyle);
            }

            var ordered_menus = _MenuItemsCache.Values.Cast<MenuwithJSONData>().OrderBy(o => o.Index);

            foreach (MenuwithJSONData data in ordered_menus)
            {

                if (data == null)
                    continue;

                if (CurrentRouteMatchesName(helper, data))
                {
                    if (data.SubMenus != null && data.SubMenus.Any())
                    {
                        ul = GenTagHtmlNode(helper, _MenuItemPatternCache["submenuwithicon.active"] as MenuItemPatternJSONData, ul, data);

                    }
                    else
                    {
                        ul = GenTagHtmlNode(helper, _MenuItemPatternCache["nosubmenuwithicon.active"] as MenuItemPatternJSONData, ul, data);
                    }
                }
                else
                {
                    if (data.SubMenus != null && data.SubMenus.Any())
                    {
                        ul = GenTagHtmlNode(helper, _MenuItemPatternCache["submenuwithicon"] as MenuItemPatternJSONData, ul, data);
                    }
                    else
                    {
                        ul = GenTagHtmlNode(helper, _MenuItemPatternCache["nosubmenuwithicon"] as MenuItemPatternJSONData, ul, data);
                    }
                }
            }
            if (_MenuItemPatternCache.ContainsKey("sidebar-minify-btn"))
            {
                MenuItemPatternJSONData sidebarminify = _MenuItemPatternCache["sidebar-minify-btn"] as MenuItemPatternJSONData;

                TagBuilder tag = GenTagHtmlNode(helper, sidebarminify, ul, null);
 
            }

            return MvcHtmlString.Create(ul.ToString(TagRenderMode.Normal));
        }

        #region 內部方法
        private static HtmlString GetMenuItemBlockContent(this HtmlHelper htmlhelper, string patternname, MenuwithJSONData menuitembinding)
        {
            StringBuilder htmlbuilder = new StringBuilder();
            MenuItemPatternJSONData pattern = _MenuItemPatternCache[patternname] as MenuItemPatternJSONData;
            htmlbuilder.AppendLine(GenTagHtmlNode(htmlhelper, pattern, null, menuitembinding).ToString(TagRenderMode.Normal));
            return new HtmlString(htmlbuilder.ToString());
        }

        #region 產生HTML標籤屬性模板內容
        private static TagBuilder GenAttrubiteNode(HtmlHelper htmlhelper, MenuItemPatternJSONData patterndata, TagBuilder tag, MenuwithJSONData menuitembinding)
        {
            if (patterndata.type.ToLowerInvariant() != "attribute")
            {
                return tag;
            }

            switch (patterndata.name.ToLowerInvariant())
            {
                case "href":
                    System.Web.Routing.RouteValueDictionary routingdata = new System.Web.Routing.RouteValueDictionary();

                    string url = "#";

                    if (menuitembinding != null)
                    {
                        routingdata.Add("area", menuitembinding.Area);
                        routingdata.Add("action", menuitembinding.ActionName);
                        routingdata.Add("controller", menuitembinding.ControllerName);

                        Dictionary<string, object> jsonroutedata = menuitembinding.RoutedValues as Dictionary<string, object>;

                        if (jsonroutedata != null)
                        {

                            foreach (var propertykey in jsonroutedata.Keys)
                            {
                                var propertyvalue = jsonroutedata[propertykey];

                                routingdata.Add(propertykey, propertyvalue);
                            }

                        }

                        url = UrlHelper.GenerateUrl("Default", routingdata["action"] as string, routingdata["controller"] as string,
                        routingdata, htmlhelper.RouteCollection, htmlhelper.ViewContext.RequestContext, true);

                    }

                    tag.Attributes.Add(patterndata.name, url);
                    break;
                case "class":
                    if (!string.IsNullOrEmpty(patterndata.bindingname))
                    {
                        switch (patterndata.bindingname)
                        {
                            case "IconCSSClass":
                                tag.Attributes.Add(patterndata.name, menuitembinding.IconCSSClass);
                                break;
                            case "ItemCSSClass":
                                tag.Attributes.Add(patterndata.name, menuitembinding.ItemCSSClass);
                                break;
                            default:
                                if (string.IsNullOrEmpty(patterndata.name) == false)
                                    tag.Attributes.Add(patterndata.name, patterndata.bindingname);

                                break;
                        }

                    }
                    // tag.Attributes.Add(patterndata.name, GetCustomCSSClass(htmlhelper, patterndata.bindingname).ToHtmlString());
                    break;

                default:
                    tag.Attributes.Add(patterndata.name, patterndata.bindingname);
                    break;
            }

            return tag;
        }
        #endregion

        #region Generate Tag Content Codes
        private static TagBuilder GenTagHtmlNode(HtmlHelper htmlhelper, MenuItemPatternJSONData patterndata, TagBuilder parenttag, MenuwithJSONData menuitembinding)
        {
            //Step 1: 確認輸入的模板類型如果為空則直接返回
            if (string.IsNullOrEmpty(patterndata.type))
            {
                return parenttag;
            }

            //Step 2: 如果模板類型不為空值，則依據類型執行對應名稱的模板內容設定產生HTML內容
            switch (patterndata.type.ToLowerInvariant())
            {
                case "tag":
                    parenttag = GenerateTagHtmlContent(htmlhelper, patterndata, parenttag, menuitembinding);
                    break;

                case "innerhtml":
                    GenerateTagInnerHtmlContentwithPattern(patterndata, parenttag, menuitembinding);
                    break;
            }

            return parenttag;
        }

        private static void GenerateTagInnerHtmlContentwithPattern(MenuItemPatternJSONData patterndata, TagBuilder parenttag, MenuwithJSONData menuitembinding)
        {
            if (patterndata.name == null)
                patterndata.name = string.Empty;

            switch (patterndata.name.ToLowerInvariant())
            {
                case "iconname":
                    ProcessingIconNameBingingFromMenuWithJSONData(patterndata, parenttag, menuitembinding);
                    break;
                default:
                    ProcessingNormalDataBindingFromMenuWithJSONData(patterndata, parenttag, menuitembinding);
                    break;
            }
        }

        private static void ProcessingNormalDataBindingFromMenuWithJSONData(MenuItemPatternJSONData patterndata, TagBuilder parenttag, MenuwithJSONData menuitembinding)
        {
            switch (patterndata.bindingname.ToLowerInvariant())
            {
                case "menuname":
                    parenttag.InnerHtml += menuitembinding.Title;
                    break;

                default:
                    parenttag.InnerHtml += patterndata.bindingname;
                    break;
            }
        }

        private static void ProcessingIconNameBingingFromMenuWithJSONData(MenuItemPatternJSONData patterndata, TagBuilder parenttag, MenuwithJSONData menuitembinding)
        {
            if (!string.IsNullOrEmpty(patterndata.bindingname))
                parenttag.InnerHtml += patterndata.bindingname;
            else
                parenttag.InnerHtml += menuitembinding.IconName;
        }

        /// <summary>
        /// 產生HTML標籤模板內容
        /// </summary>
        /// <param name="htmlhelper"></param>
        /// <param name="patterndata">模板JSON資料</param>
        /// <param name="parenttag">上一層的TagBuilder</param>
        /// <param name="menuitembinding">要綁定的選單項目</param>
        /// <returns></returns>
        private static TagBuilder GenerateTagHtmlContent(HtmlHelper htmlhelper, MenuItemPatternJSONData patterndata, TagBuilder parenttag, MenuwithJSONData menuitembinding)
        {
            TagBuilder tag = new TagBuilder(patterndata.name);

            tag = GenerateAttributeswithHTMLTagPatternData(htmlhelper, patterndata, menuitembinding, tag);

            tag = GenerateInnerHTMLContentWithTagPatternData(htmlhelper, patterndata, menuitembinding, tag);

            ProcessingCheckMenuitemIsHasSubMenuAndGenerateIt(htmlhelper, menuitembinding);

            parenttag = ProcessingCheckParentLevelElementIsNullAndAssignObjects(parenttag, tag);

            return parenttag;
        }

        private static TagBuilder ProcessingCheckParentLevelElementIsNullAndAssignObjects(TagBuilder parenttag, TagBuilder tag)
        {
            if (parenttag != null)
                parenttag.InnerHtml += tag.ToString(TagRenderMode.Normal);
            else
                parenttag = tag;
            return parenttag;
        }

        private static void ProcessingCheckMenuitemIsHasSubMenuAndGenerateIt(HtmlHelper htmlhelper, MenuwithJSONData menuitembinding)
        {
            if (menuitembinding == null)
                return;

            if (menuitembinding.SubMenus != null && menuitembinding.SubMenus.Any())
            {
                foreach (MenuwithJSONData subitem in menuitembinding.SubMenus)
                {
                    MenuItemPatternJSONData submenu_patterndata = _MenuItemPatternCache["submenuitem"] as MenuItemPatternJSONData;

                    if (CurrentRouteMatchesName(htmlhelper, subitem))
                    {
                        if (subitem.SubMenus != null && subitem.SubMenus.Any())
                        {

                            submenu_patterndata = _MenuItemPatternCache["second_submenuitem.active"] as MenuItemPatternJSONData;
                        }
                        else
                        {
                            submenu_patterndata = _MenuItemPatternCache["submenuitem.active"] as MenuItemPatternJSONData;
                        }
                    }
                    else
                    {
                        if (subitem.SubMenus != null && subitem.SubMenus.Any())
                        {

                            submenu_patterndata = _MenuItemPatternCache["second_submenuitem"] as MenuItemPatternJSONData;
                        }
                        else
                        {
                            submenu_patterndata = _MenuItemPatternCache["submenuitem"] as MenuItemPatternJSONData;
                        }
                    }


                }
            }
        }

        private static TagBuilder GenerateInnerHTMLContentWithTagPatternData(HtmlHelper htmlhelper, MenuItemPatternJSONData patterndata, MenuwithJSONData menuitembinding, TagBuilder tag)
        {
            if (patterndata.innerHtml.Any())
            {
                foreach (MenuItemPatternJSONData inneritem in patterndata.innerHtml)
                {
                    tag = GenTagHtmlNode(htmlhelper, inneritem, tag, menuitembinding);
                }
            }
            return tag;
        }

        private static TagBuilder GenerateAttributeswithHTMLTagPatternData(HtmlHelper htmlhelper, MenuItemPatternJSONData patterndata, MenuwithJSONData menuitembinding, TagBuilder tag)
        {
            if (patterndata.attrs != null && patterndata.attrs.Any())
            {
                foreach (MenuItemPatternJSONData attr in patterndata.attrs.OrderBy(o => o.index))
                {
                    tag = GenAttrubiteNode(htmlhelper, attr, tag, menuitembinding);
                }
            }
            return tag;
        }
        #endregion

        static bool CurrentRouteMatchesName(HtmlHelper helper, MenuwithJSONData MenuNodeJson)
        {

            string _Controller = Convert.ToString(helper.ViewContext.RouteData.Values["controller"]); // , prog.ControllerName);
            string _Action = Convert.ToString(helper.ViewContext.RouteData.Values["action"]);
            string _Area = Convert.ToString(helper.ViewContext.RouteData.Values["area"]);

            if (_Area != MenuNodeJson.Area)
                return false;

            if (_Controller != MenuNodeJson.ControllerName)
                return false;

            if (_Action != MenuNodeJson.ActionName)
                return false;

            return true;
        }

        #region 從JSON檔案取得選單相關內容設定
        /// <summary>
        /// 載入選單模板
        /// </summary>
        private static void LoadMenuItemPattern()
        {
            if (_MenuItemPatternCache == null)
            {
                _MenuItemPatternCache = new Hashtable();
            }
            FileIORepository fiorepo = new FileIORepository();
            Dictionary<string, MenuItemPatternJSONData> customcssjsonfile_content =
               fiorepo.LoadSettingDataFromJSONFile<Dictionary<string, MenuItemPatternJSONData>>("menuitempattern.json");

            if (customcssjsonfile_content.Any())
            {
                foreach (string key in customcssjsonfile_content.Keys)
                {
                    if (_MenuItemPatternCache.ContainsKey(key) == false)
                        _MenuItemPatternCache.Add(key, customcssjsonfile_content[key]);
                }
            }
        }
        private static ISinglePageViewModel GetLeftSideBarMainMenu(this HtmlHelper htmlhelper, ISinglePageViewModel viewmodel)
        {
            if (_MenuItemsCache == null)
            {
                _MenuItemsCache = new Hashtable();
            }
            FileIORepository fiorepo = new FileIORepository();
            DBRepository SP = new DBRepository();
            var customcssjsonfile_content =
           SP.Web_Role_GetMainMenu();
            // fiorepo.LoadSettingDataFromJSONFile<List<MenuwithJSONData>>("sitemap.json");

            ISinglePageViewModel viewpagebase = viewmodel;

            foreach (MenuwithJSONData item in customcssjsonfile_content)
            {
                string _key = string.Join(".", item.Index.ToString(), item.Area, item.ControllerName, item.ActionName);

                if (!_MenuItemsCache.ContainsKey(_key))
                {
                    _MenuItemsCache.Add(_key, item);
                }
            }

            return viewpagebase;
        }

        private static ISinglePageViewModel GetMainMenu(this HtmlHelper htmlhelper, ISinglePageViewModel viewmodel)
        {
            FileIORepository fiorepo = new FileIORepository();

            if (_TopMenuItemCache == null)
            {
                _TopMenuItemCache = new Hashtable();
            }
            var customcssjsonfile_content =
                 fiorepo.LoadSettingDataFromJSONFile<List<MenuwithJSONData>>("sitemap.top.json");

            ISinglePageViewModel viewpagebase = viewmodel;

            foreach (MenuwithJSONData item in customcssjsonfile_content)
            {
                string _key = string.Join(".", item.Area, item.ControllerName, item.ActionName);

                if (!_TopMenuItemCache.ContainsKey(_key))
                {
                    _TopMenuItemCache.Add(_key, item);
                }
            }

            return viewpagebase;
        }

        private static IMenuItemViewModel ConvertSignleRowDataTo(MenuwithJSONData item)
        {
            IMenuItemViewModel convertedmodel = new MenuItemViewModel();

            convertedmodel.ActionName = item.ActionName;
            convertedmodel.Area = item.Area;
            convertedmodel.ControllerName = item.ControllerName;
            convertedmodel.IconCSSClass = item.IconCSSClass;
            convertedmodel.ItemCSSClass = item.ItemCSSClass;
            convertedmodel.RoutedValues = item.RoutedValues;
            convertedmodel.Title = item.Title;
            convertedmodel.SubMenus = ConvertToMenuJSONData(item.SubMenus);
            return convertedmodel;
        }

        private static List<IMenuItemViewModel> ConvertToMenuJSONData(List<MenuwithJSONData> source)
        {
            if (source == null)
            {
                return new List<IMenuItemViewModel>();
            }
            List<IMenuItemViewModel> converted = source.ConvertAll<IMenuItemViewModel>(c => ConvertSignleRowDataTo(c));
            return converted;
        }
        #endregion

        #endregion
        #endregion

        #region 通知訊息類
        public static HtmlString GetNotiftionCountDisplay(this HtmlHelper htmlhelper)
        {
            string displaytext = string.Format("{0}", GetNotiftionCount(htmlhelper));
            return new HtmlString(displaytext);
        }

        public static int GetNotiftionCount(this HtmlHelper htmlhelper)
        {
            return 0;
        }
        #endregion
    }
}