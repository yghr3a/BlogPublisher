using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Model
{
    /// <summary>
    /// 发布聚合结果, 用于记录一次发布操作中所有发布配置的结果信息
    /// </summary>
    internal class PublishAggregateResult
    {
        // 所有单独博客发布操作结果列表
        public List<PublishResult> PublishResults { get; set; } = new List<PublishResult>();
        // 失败的发布配置名称列表, 后续会改为抛出业务异常
        public List<string> FailedReasons { get; set; }
        // 整体操作是否成功, 即使是全都失败, 也算是成功的操作. 
        public bool IsSuccessed { get; set; }
    }
}
