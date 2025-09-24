using BlogPublisher.Helper;
using BlogPublisher.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlogPublisher.Common.PublishConfigTypeHelper;

namespace BlogPublisher.Common
{
    /// <summary>
    /// 提供发布配置文件路径访问
    /// </summary>
    internal static class PublishConfigPathHelper
    {
        private static string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        // 或 LocalApplicationData, 通常 LocalApplicationData 更适合存储本地配置

        // 配置文件夹目录, 配置文件夹下面还有各个发布类型的子文件夹
        private static string _configInfoFolderPath = "";

        private static Dictionary<Type, string> _type2path = new Dictionary<Type, string>();

        static PublishConfigPathHelper()
        {
            // 顺序很重要, 必须先初始化文件夹路径, 然后才能初始化类型到路径的映射
            InitConfigInfoFolderPath();
            InitType2path();
        }

        public static Dictionary<Type, string> Type2path
        {
            get
            {
                if (_type2path.Count == 0 || _type2path == null)
                    InitType2path();
                return _type2path;
            }
        }

        public static string ConfigInfoFolderPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_configInfoFolderPath))
                    InitConfigInfoFolderPath();
                return _configInfoFolderPath;
            }
        }

        private static string InitConfigInfoFolderPath()
        {
            _configInfoFolderPath = Path.Combine(_appData, "BlogPublisher");
            if (FileHelper.IsFolderExist(_configInfoFolderPath) == false)
                FileHelper.CreateFolder(_configInfoFolderPath);

            return _configInfoFolderPath;
        }

        private static void InitType2path()
        {
            _type2path = new Dictionary<Type, string>();

            foreach(var typeAndString in Type2String)
            {
                var path = Path.Combine(_configInfoFolderPath, typeAndString.Value.ToLower());

                if (FileHelper.IsFolderExist(path) == false)
                    FileHelper.CreateFolder(path);

                _type2path.Add(typeAndString.Key, path);
            }

        }
    }
}
