using BlogPublisher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.DebugAndTest
{
    internal interface IPublishStrategy
    {
        // 抽象的发布策略只需要一个方法, 用于发布博客
        Task PublishBlogAsync(BlogInfo blogInfo, IPublishConfig publishConfig);
    }
}
