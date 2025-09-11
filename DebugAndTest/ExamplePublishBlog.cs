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
    /// <summary>
    /// 示例: 采用了依赖注入与策略工程模式的发布博客例子
    /// </summary>
    internal class ExamplePublishBlog
    {
        private PublisherStrategyFactory _publishStrategyFactory = ServiceManager.GetService<PublisherStrategyFactory>();
        public async Task Test(BlogInfo blogInfo, List<IPublishConfig> publishConfigs)
        {
            var Tasks = publishConfigs.Select(config =>
            {
                var strategy = _publishStrategyFactory.GetPublishStrategy(config);
                return strategy.PublishBlogAsync(blogInfo, config);
            });
            await Task.WhenAll(Tasks);
        }
    }
}
