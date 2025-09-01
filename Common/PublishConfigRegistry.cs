using BlogPublisher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Common
{
    public enum ConfigType
    {
        WordPress,
        CNBlog,
        GithubPage
    }

    public static class PublishConfigRegistry
    {

        private static Dictionary<ConfigType, string> _configType2String = new Dictionary<ConfigType, string>()
        {
            { ConfigType.WordPress,"WordPress"},
            { ConfigType.CNBlog, "CNBlog"},
            { ConfigType.GithubPage, "GithubPage"}
        };

        // 暂时用WordPressPublishConfig作为全部的返回值
        private static  Dictionary<string, Type> _string2Type = new Dictionary<string, Type>()
        {
            { "WordPress", typeof(WordPressPublishConfig)},
            { "CNBlog",typeof(WordPressPublishConfig)},
            { "GithubPage",typeof(WordPressPublishConfig)}
        };
    }
}
