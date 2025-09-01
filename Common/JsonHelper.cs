using BlogPublisher.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BlogPublisher.Helper
{
    public static class JsonHelper
    {
        public static string Serialize<T>(T obj) where T : class
        {
            if (obj == null)
                throw new JsonHelperException("序列化失败", new ArgumentNullException("反序列化Json字符串不能为空"));

            try
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented) ?? "";
            }
            catch (Exception ex)
            {
                throw new JsonHelperException("序列化失败", ex);
            }
        }

        public static T Deserialize<T>(string json) where T : class, new()
        {
            if(string.IsNullOrWhiteSpace(json))
                throw new JsonHelperException("反序列化失败", new ArgumentNullException("反序列化Json字符串不能为空"));

            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new JsonHelperException("反序列化失败", ex);
            }
            
        }
    }
}
