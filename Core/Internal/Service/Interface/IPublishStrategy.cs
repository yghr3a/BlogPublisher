using BlogPublisher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Service
{
    // 抽象的发布策略只需要一个方法, 用于发布博客
    internal interface IPublishStrategy
    {
        /// [2025/9/15]通过发布配置的类型和名称来加载发布配置, 然后发布博客,Load的类型参数必须与策略类型对应的发布配置类型匹配
        /// 原本打算使用上面的方法，直接通过 IPublishConfig 参数来传递发布配置的, 但是在实际使用中, 没有地方用写死Load的类型参数来加载发布配置,所以改为在该方法写死,反正一个发布策略也是对应一个平台的 <summary>
        /// [2025/9/20]重构，返回结果类型改为 PublishResult
        /// [2025/9/22]重构，接受博客信息类型改为 BlogInformation
        /// <summary>
        /// 异步发布博客操作, 对外抽象了发布博客的具体操作,只需要按参数要求传递参数即可
        /// </summary>
        /// <param name="blogInformation"></param>
        /// <param name="publishConfigTypeAndName"></param>
        /// <returns></returns>
        Task<PublishResult> PublishBlogAsync(BlogInformation blogInformation, PublishConfigIdentity publishConfigTypeAndName);
    }
}
