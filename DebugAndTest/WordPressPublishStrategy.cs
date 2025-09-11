using BlogPublisher.Core.Application;
using BlogPublisher.Model;
using BlogPublisher.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.DebugAndTest
{
    internal class WordPressPublishStrategy : IPublishStrategy
    {
        // 发布策略接口的实现类使用 WordPressPublisher 来实现发布策略
        private WordPressPublisher publisher = ServiceManager.GetService<WordPressPublisher>();
        public async Task PublishBlogAsync(BlogInfo blogInfo, IPublishConfig publishConfig)
        {
            publisher.LoadBlogInfo(blogInfo);
            await publisher.PublishBlogAsync((WordPressPublishConfig)publishConfig);
        }
    }
}
