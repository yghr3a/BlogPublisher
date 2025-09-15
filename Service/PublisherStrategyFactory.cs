using BlogPublisher.Model;
using BlogPublisher.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPublisher.Common;

namespace BlogPublisher.Service
{
    internal class PublisherStrategyFactory
    {
        public IPublishStrategy GetPublishStrategy(IPublishConfig config)
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

        public IPublishStrategy GetPublishStrategy(Type configType)
        {
            // 根据不同的发布配置类型，返回相应的发布策略实例
            if (configType == typeof(WordPressPublishConfig))
            {
                return ServiceManager.GetService<WordPressPublishStrategy>();
            }
            else if (configType == typeof(WordPressPublishConfig))
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
