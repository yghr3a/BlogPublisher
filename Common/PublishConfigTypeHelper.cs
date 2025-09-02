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


    public static class PublishConfigTypeHelper
    {

        public static Type wordPressPublishConfigType = typeof(WordPressPublishConfig);
        public static Type cnBlogPublishConfigType = typeof(CNBlogPublishConfig);
        public static Type githubPublishConfigType = typeof(GitHUbPublishConfig);

        static PublishConfigTypeHelper()
        {
            InitConfigType2String();
            InitType2String();
            InitString2Type();
        }

        public static Dictionary<ConfigType, string> _configType2String = new Dictionary<ConfigType, string>();
        public static Dictionary<Type, string> _type2String = new Dictionary<Type, string>();
        public static Dictionary<string, Type> _string2Type = new Dictionary<string, Type>();

        public static Dictionary<ConfigType, string> ConfigType2String
        {
            get 
            {
                if (_configType2String.Count == 0 || _configType2String == null)
                    InitConfigType2String();
                return _configType2String;
            }
        }

        public static Dictionary<Type, string> Type2String
        {
            get
            {
                if (_type2String.Count == 0 || _type2String == null)
                    InitType2String();
                return _type2String;
            }
        }

        public static Dictionary<string, Type> String2Type
        {
            get
            {
                if (_string2Type.Count == 0 || _string2Type == null)
                    InitString2Type();
                return _string2Type;
            }
        }

        private static void InitConfigType2String()
        {
            _configType2String = new Dictionary<ConfigType, string>();

            foreach(var configType in Enum.GetValues(typeof(ConfigType)))
                _configType2String.Add((ConfigType)configType, configType.ToString());
        }

        private static void InitType2String()
        {
            _type2String = new Dictionary<Type, string>()
            {
                {wordPressPublishConfigType, "WordPress" },
                {cnBlogPublishConfigType, "CNBlog"},
                {githubPublishConfigType, "GithubPage" }
            };
        }

        private static void InitString2Type()
        {
            _string2Type = new Dictionary<string, Type>()
            {
                { "WordPress", wordPressPublishConfigType},
                { "CNBlog", cnBlogPublishConfigType},
                { "GithubPage",githubPublishConfigType}
            };
        }

    }
}
