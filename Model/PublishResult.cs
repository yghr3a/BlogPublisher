using BlogPublisher.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Model
{
    /// <summary>
    /// 发布结果, 用于记录单独博客发布操作时的结果信息
    /// [2025/9/16] 后续可以考虑增加更多的结果信息属性, 例如发布的文章ID, URL等.还可以根据不同的发布平台增加定义不同的发布结果类
    /// </summary>
    internal class PublishResult
    {
        // 发布配置名称
        public string PublishConfigName { get; set; }
        // 发布配置类型
        public ConfigType ConfigType { get; set; }
        // 是否成功
        public bool IsSuccess { get; set; }
        // 如果有异常, 则记录异常信息
        public Exception Exception { get; set; }
    }
}
