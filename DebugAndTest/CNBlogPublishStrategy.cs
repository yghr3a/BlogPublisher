using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPublisher.Model;
using BlogPublisher.Service;
using BlogPublisher.Core.Application;

namespace BlogPublisher.DebugAndTest
{
    internal class CNBlogPublishStrategy : IPublishStrategy
    {
        private CNBlogPublisher publisher = ServiceManager.GetService<CNBlogPublisher>();
        public async Task PublishBlogAsync(BlogInfo blogInfo, IPublishConfig publishConfig)
        {
            publisher.testPublishBlog();
        }
    }
}
