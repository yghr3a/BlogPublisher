using BlogPublisher.Helper;
using BlogPublisher.Model;
using BlogPublisher.Common;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace BlogPublisher.Service
{
    public class PublishConfigService
    {
        private static Dictionary<Type, string> _type2path = PublishConfigPathHelper.Type2path;

        // 配置文件存储的根目录
        private static string _path = PublishConfigPathHelper.ConfigInfoFolderPath;

        /// <summary>
        /// 添加配置文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        public void Add<T>(T config) where T : class, IPublishConfig, new()
        {
            var configInfo = JsonHelper.Serialize(config);
            var configType = typeof(T);
            var path = _type2path[configType];

            if (FileHelper.IsFolderExist(path) == false)
                FileHelper.CreateFolder(path);

            var filePath = FileHelper.CreateFile(path, config.ConfigName, "txt");

            FileHelper.WriteInto(filePath, configInfo);
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">每个配置的名字</param>
        /// <returns></returns>
        public T Load<T>(string name) where T : class, IPublishConfig, new()
        {
            var content = FileHelper.GetFileContent(_path, name, ".txt");
            var config = JsonHelper.Deserialize<T>(content);
            return config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> LoadName()
        {
            var res = new List<string>();
            foreach (var item in _type2path.Values)
            {
                var names = FileHelper.GetFileNamesInDir(item);
                res.AddRange(names);
            }

            return res;
        }
    }
}
