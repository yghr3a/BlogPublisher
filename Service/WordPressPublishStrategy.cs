using BlogPublisher.Core.Application;
using BlogPublisher.Model;
using BlogPublisher.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Service
{
    internal class WordPressPublishStrategy : IPublishStrategy
    {
        // 发布策略接口的实现类使用 WordPressPublisher 来实现发布策略
        private WordPressPublisher publisher = ServiceManager.GetService<WordPressPublisher>();
        private PublishConfigService publishConfigService = ServiceManager.GetService<PublishConfigService>();

        private async Task<PublishResult> PublishBlogAsync(BlogInfo blogInfo, IPublishConfig publishConfig)
        {
            return await publisher.PublishBlogAsync(blogInfo,(WordPressPublishConfig) publishConfig);
        }

        /// <summary>
        /// 通过发布配置的类型和名称来加载发布配置, 然后发布博客
        /// </summary>
        /// <param name="blogInfo"></param>
        /// <param name="publishConfigTypeAndName"></param>
        /// <returns></returns>
        public async Task<PublishResult> PublishBlogAsync(BlogInfo blogInfo, PublishConfigIdentity publishConfigTypeAndName)
        {
            var config = publishConfigService.Load<WordPressPublishConfig>(publishConfigTypeAndName.PublishConfigName);
            return await PublishBlogAsync(blogInfo, config);
        }
    }
}
