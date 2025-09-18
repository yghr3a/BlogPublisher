using BlogPublisher.Common;
using BlogPublisher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Core.Application
{
    public interface IEvent
    {
        // 事件是否成功
        bool IsSuccessed { get; set; }
        // 如果事件失败需要UI层读取异常信息决定处理方式
        Exception Exception { get; set; }
    }

    /// <summary>
    /// 添加发布配置事件
    /// [2025/9/18] 使用泛型事件来传递具体的发布配置对象,便于传递类型参数
    /// </summary>
    public class AddPublishConfigEvent<T> : IEvent where T : class, IPublishConfig, new()
    {
        public T PublishConfig { get; set; }
        public bool IsSuccessed { get; set; }
        public Exception Exception { get; set; }
    }

    /// <summary>
    /// 添加发布配置完成事件
    /// </summary>
    public class AddPublishConfigFinishedEvent : IEvent
    {
        public string ConfigName { get; set; }
        public string ConfigType { get; set; }
        public bool IsSuccessed { get; set; }
        public Exception Exception { get; set; }
    }

    /// <summary>
    /// 发布博客事件
    /// </summary>
    public class PublishBlogEvent : IEvent
    {
        // 一个配置文件信息(配置名与配置类型)对应一个布尔值，表示发布是否成功
        public List<KeyValuePair<KeyValuePair<string, string>, bool>> configInfoAndIsSuccessed { get; set; }
        // 目前使用的消息传递属性
        public List<string> Messages { get; set; }

        public bool IsSuccessed { get; set; }
        public Exception Exception { get; set; }
    }

    /// <summary>
    /// 加载发布配置事件
    /// </summary>
    public class LoadPublishConfigEvent : IEvent
    {
        public List<KeyValuePair<string, ConfigType>> ConfigNameAndType { get; set; }

        public bool IsSuccessed { get; set; }
        public Exception Exception { get; set; }

    }

}
