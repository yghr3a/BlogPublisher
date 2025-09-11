using BlogPublisher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.DebugAndTest
{
    internal interface IPublisher
    {
        BlogInfo BlogInfo { get;}
        void LoadBlogInfo(BlogInfo blogInfo);
        Task PublishAsync(IPublishConfig publishConfig);
    }
}
