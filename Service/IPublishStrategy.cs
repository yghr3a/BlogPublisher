using BlogPublisher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Service
{
    internal interface IPublishStrategy
    {
        // 抽象的发布策略只需要一个方法, 用于发布博客
        // Task<string> PublishBlogAsync(BlogInfo blogInfo, IPublishConfig publishConfig);

        /// [2025/9/15]通过发布配置的类型和名称来加载发布配置, 然后发布博客,Load的类型参数必须与策略类型对应的发布配置类型匹配
        /// 原本打算使用上面的方法，直接通过 IPublishConfig 参数来传递发布配置的, 但是在实际使用中, 没有地方用写死Load的类型参数来加载发布配置,所以改为在该方法写死,反正一个发布策略也是对应一个平台的
        Task<PublishResult> PublishBlogAsync(BlogInfo blogInfo, PublishConfigTypeAndName publishConfigTypeAndName);
    }
}
