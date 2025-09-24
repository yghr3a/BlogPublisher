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
    public class PublishResult
    {
        // 发布配置名称
        public string PublishConfigName { get; set; }
        // 发布配置类型
        // [2025/9/20] 暂时不考虑添加这个属性
        // public string ConfigType { get; set; }
        // 是否成功
        public bool IsSuccessed { get; set; }
        // 失败原因, 因为有些失败并不是异常, 例如返回的状态码不是200等
        // [2025/9/20] 默认为空, 因为成功时不需要填写; 后续开发为了可以让UI层显示更友好的失败信息, 方便UI层选择如何处理, 后面可以考虑增加一些业务层面的自定义异常
        public string FailedReason { get; set; } = null;
        // 如果有异常, 则记录异常信息
        // [2025/9/20] 默认为空, 因为成功时不需要填写
        public Exception Exception { get; set; } = null;
    }
}
