using BlogPublisher.Model;
using BlogPublisher.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.DebugAndTest
{
    internal class PublisherStrategyFactory
    {
        internal IPublishStrategy GetPublishStrategy(IPublishConfig config)
        {
            // 根据不同的发布配置类型，返回相应的发布策略实例
            if (config is WordPressPublishConfig)
            {
                return ServiceManager.GetService<WordPressPublishStrategy>();
            }
            else if(config is CNBlogPublishConfig)
            {
                return ServiceManager.GetService<CNBlogPublishStrategy>();
            }
            else
            {
                throw new Exception("Not supported publish config type.");
            }
        }
    }
}
