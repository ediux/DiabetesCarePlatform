using System.ComponentModel;
namespace MVCExtra
{
    public enum LanguageEnum
    {
        [Description("en-US")]
        English = 1,
        [Description("ja-JP")]
        Japanese = 2,
        [Description("zh-CN")]
        SChinese = 3,
        [Description("zh-TW")]
        TChinese = 4
    }
}