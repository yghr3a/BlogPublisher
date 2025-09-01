using BlogPublisher.Helper;
using BlogPublisher.Model;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Service
{
    public class PublishConfigService
    {
        private string _path = "C:\\Users\\yghr3a\\Desktop\\测试保存配置文件";

        private Dictionary<Type, string> _type2path = new Dictionary<Type, string>()
        {
            { typeof(WordPressPublishConfig) ,"C:\\Users\\yghr3a\\Desktop\\测试保存配置文件\\wordpress"},
        };

        public void Add<T>(T config) where T : class, IPublishConfig, new()
        {
            var configInfo = JsonHelper.Serialize(config);
            var configType = typeof(T);
            var path = _type2path[configType];
            var filePath = FileHelper.CreateFile(path, config.ConfigName, "txt");

            FileHelper.WriteInto(filePath, configInfo);
        }

        public T Load<T>(string name) where T : class, IPublishConfig, new()
        {
            var ex = ".txt";

            var content = FileHelper.GetFileContent(_path, name, ex);

            var config = JsonHelper.Deserialize<T>(content);

            return config;
        }

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
