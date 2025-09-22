using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPublisher.Model;
using BlogPublisher.Service;
using BlogPublisher.Core.Application;

namespace BlogPublisher.Service
{
    /// <summary>
    /// C#博客园发布策略,未实现
    /// </summary>
    internal class CNBlogPublishStrategy : IPublishStrategy
    {
        private CNBlogPublisher publisher = ServiceManager.GetService<CNBlogPublisher>();
        public async Task PublishBlogAsync(BlogInfo blogInfo, IPublishConfig publishConfig)
        {
            publisher.testPublishBlog();
        }

        public async Task<PublishResult> PublishBlogAsync(BlogInfo blogInfo, PublishConfigIdentity publishConfigTypeAndName)
        {
            throw new NotImplementedException();
        }
    }
}
