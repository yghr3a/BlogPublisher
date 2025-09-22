using BlogPublisher.Helper;
using BlogPublisher.Model;
using BlogPublisher.Core.Application;
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
using BlogPublisher.CustomException;

namespace BlogPublisher.Service
{
    public class PublishConfigService
    {
        // 类型到路径的映射
        private static Dictionary<Type, string> _type2path = PublishConfigPathHelper.Type2path;

        // 配置文件存储的根目录
        private static string _path = PublishConfigPathHelper.ConfigInfoFolderPath;

        /// <summary>
        /// 添加配置文件
        /// [2025/9/18] 重构, 发布事件与异常处理上移到应用层, 这里不再处理事件发布
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
            var type = typeof(T);
            var content = FileHelper.GetFileContent(_type2path[type], name, ".txt");
            var config = JsonHelper.Deserialize<T>(content);
            return config;
        }

        /// <summary>
        /// 加载所有配置文件的类型和名字, 用于界面显示
        /// </summary>
        /// <returns></returns>
        public List<PublishConfigIdentity> LoadPublishConfigTypeAndName()
        {
            var res = new List<PublishConfigIdentity>();

            foreach(var typeAndPath in _type2path)
            {
                var type = typeAndPath.Key;
                var path = typeAndPath.Value;

                var files = FileHelper.GetFileNamesWithoutExtensions(path);

                foreach (var file in files)
                {
                    var item = new PublishConfigIdentity()
                    {
                        PublishConfigType = type,
                        PublishConfigName = file
                    };
                    res.Add(item);
                }
            }

            return res;
        }
    }
}
