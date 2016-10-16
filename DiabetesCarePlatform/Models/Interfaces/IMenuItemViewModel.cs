using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesCarePlatform.Models.Interfaces
{
    /// <summary>
    /// 定義選單項目檢視模型介面
    /// </summary>
    public interface IMenuItemViewModel
    {
        /// <summary>
        /// 選單項目標題文字
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// 選單項目之圖示CSS類別名稱列表
        /// </summary>
        string IconCSSClass { get; set; }
        /// <summary>
        /// MVC子區域空間名稱。
        /// </summary>
        string Area { get; set; }
        /// <summary>
        /// 控制器的動作方法名稱。
        /// </summary>
        string ActionName { get; set; }
        /// <summary>
        /// 控制器名稱
        /// </summary>
        string ControllerName { get; set; }
        /// <summary>
        /// MVC路由資料的JSON反序列化物件。有需要指定才需要輸入，否則請留空白!
        /// </summary>
        object RoutedValues { get; set; }
        /// <summary>
        /// 項目本身對應的CSS類別
        /// </summary>
        string ItemCSSClass { get; set; }
        /// <summary>
        /// 子選單項目
        /// </summary>
        List<IMenuItemViewModel> SubMenus { get; set; }
    }
}
