using BlogPublisher.Interface;
using BlogPublisher.Model;
using CookComputing.XmlRpc;

namespace BlogPublisher.Helper
{
    public static class MetaWeblogHelper
    {
        // 创建IMetaWeblog, 可自定义目标url
        public static IMetaWeblog Create(string url)
        {
            var proxy = XmlRpcProxyGen.Create<IMetaWeblog>();
            proxy.Url = url; // 动态修改代理的URL
            return proxy;
        }
    }
}
