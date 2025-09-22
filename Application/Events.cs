using BlogPublisher.Common;
using BlogPublisher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Core.Application
{
    /// <summary>
    /// [2025/9/18] 并非所有事件都有成功的说法，比如说某个事件只是一个请求事件, 因此这里的IsSuccessed属性可以考虑去掉
    /// </summary>
    public interface IEvent { }

    /// <summary>
    /// 请求事件接口,用于标记某个事件只是一个请求事件,没有成功与否的说法,也不会携带异常信息
    /// </summary>
    public interface IRequestEvent : IEvent { }

    /// <summary>
    /// 响应事件接口,用于标记某个事件是一个响应事件,有成功与否的说法,也会携带异常信息
    /// </summary>
    public interface IResponseEvent : IEvent
    {
        // 事件是否成功
        bool IsSuccessed { get; set; }
        // 如果事件失败需要UI层读取异常信息决定处理方式
        Exception Exception { get; set; }
    }

    /// <summary>
    /// 添加发布配置请求事件
    /// [2025/9/18] 使用泛型事件来传递具体的发布配置对象,便于传递类型参数
    /// </summary>
    public class AddPublishConfigRequestEvent<T> : IEvent where T : class, IPublishConfig, new()
    {
        public T PublishConfig { get; set; }
    }

    /// <summary>
    /// 添加发布配置完成响应事件
    /// </summary>
    public class AddPublishConfigResponseEvent : IResponseEvent
    {
        public string ConfigName { get; set; }
        public string ConfigType { get; set; }
        public bool IsSuccessed { get; set; }
        public Exception Exception { get; set; }
    }

    /// <summary>
    /// 发布博客请求事件
    /// [2025/9/22] 重构，使用BlogInformation类来传递博客信息，使用List<PublishConfigIdentity>来传递发布配置的名字与类型
    /// </summary>
    public class PublishBlogRequestEvent : IRequestEvent
    {
        // 需要发布的配置文件信息(配置名与配置类型)
        public List<PublishConfigIdentity> ConfigNameAndType { get; set; }
        // 需要发布的博客信息
        public BlogInformation BlogInformation { get; set; }
    }

    /// <summary>
    /// 发布博客响应事件
    /// </summary>
    public class PublishBlogResponseEvent : IResponseEvent
    {
        // 一个配置文件信息(配置名与配置类型)对应一个布尔值，表示发布是否成功
        // [2025/9/20] 改为使用PublishResult类来传递更丰富的发布结果信息
        public List<PublishResult> publishResults { get; set; }
        // 目前使用的消息传递属性
        // [2025/9/20] 职责改为失败原因信息
        public List<string> FailReasons { get; set; }
        public bool IsSuccessed { get; set; }
        public Exception Exception { get; set; }
    }

    /// <summary>
    /// 加载发布配置请求事件
    /// [2025/9/18] 目前该事件不需要携带任何参数, 只是一个简单的请求事件。后面可以考虑增加一些过滤参数
    /// </summary>
    public class LoadPublishConfigRequestEvent : IRequestEvent { }

    /// <summary>
    /// 加载发布配置响应事件
    /// </summary>
    public class LoadPublishConfigResponseEvent : IResponseEvent
    {
        // 加载到的发布配置信息(配置名与配置类型)
        public List<KeyValuePair<string, ConfigType>> ConfigNameAndType { get; set; }
        public bool IsSuccessed { get; set; }
        public Exception Exception { get; set; }
    }


}
