using BlogPublisher.Common;
using BlogPublisher.Helper;
using BlogPublisher.Model;
using BlogPublisher.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Service
{
    /// <summary>
    /// 对于BlogInfo的初始话与清理还需要多多考虑一下, 现在靠的是LoadConfigAndBlog方法来直接覆盖
    /// [2025/9/15] 关于该类的状态设计，目前该类需要整理博客信息以及发布配置信息，所以选择保留相关的字段
    /// </summary>
    public class BlogPublishService
    {
        /// <summary>
        /// [2025/9/15] 这些服务后续改成构造函数依赖注入的方式
        /// </summary>
        private PublishConfigService _publishConfigService = ServiceManager.GetService<PublishConfigService>();
        private PublisherStrategyFactory _publisherStrategyFactory = ServiceManager.GetService<PublisherStrategyFactory>();

        private List<PublishConfigTypeAndName> _selectedconfigs = new List<PublishConfigTypeAndName>();
        private BlogInfo _blogInfo = new BlogInfo();

        /// <summary>
        /// 加载发布配置与博客内容, 会将散乱的博客信息整理成BlogInfo类型
        /// 存储发布配置的名字与类型作为成员变量
        /// </summary>
        /// <param name="configsTypeAndNames"></param>
        /// <param name="blogFilePath"></param>
        /// <param name="blogTitle"></param>
        public void LoadConfigAndBlog(List<PublishConfigTypeAndName> configsTypeAndNames, string blogFilePath, string blogTitle, string[] categories = null, bool isDraft = false)
        {
            _selectedconfigs = configsTypeAndNames;

            var blogContent = FileHelper.GetFileContent(blogFilePath);
            
            if(string.IsNullOrWhiteSpace(blogTitle))
                blogTitle = FileHelper.GetFileNameWithoutExtension(blogFilePath);

            _blogInfo.title = blogTitle;
            _blogInfo.blogContent = blogContent;
            _blogInfo.isDraft = isDraft;
            _blogInfo.categories = categories;

        }

        /// <summary>
        /// 发布博客, 会根据发布配置的类型选择对应的发布器类
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task PublishBlog()
        {
            var res = new List<string>();

            if(_selectedconfigs == null || _selectedconfigs.Count == 0)
                res.Add("没有选择发布配置");
                

            if (string.IsNullOrWhiteSpace(_blogInfo.blogContent))
                res.Add("博客内容为空");

            // 如果res以及有元素了, 说明出问题了, 发个"PublishBlogError"事件就return了
            if (res.Count > 0)
            {
                EventBus.PublishEvent(new PublishBlogResponseEvent()
                {
                    configInfoAndIsSuccessed = null,
                    IsSuccessed = false,
                    Exception = new Exception(string.Join("\n", res))
                });
                return;
            }

            // 发布博客异步方法列表， 用于后面的并发操作
            var tasks = _selectedconfigs.Select(configs =>
            {
                // 利用发布策略工厂根据发布配置的获取对应的发布策略
                var publishStrategy = _publisherStrategyFactory.GetPublishStrategy(configs.PublishConfigType);
                return publishStrategy.PublishBlogAsync(_blogInfo, configs);
            });

            // 并发操作执行博客任务, 并将结果信息加入res
            res.AddRange(await Task.WhenAll(tasks));

            // 能到这一步说明发布博客很顺利, 发个"PublishBlog"事件报告一下
            EventBus.PublishEvent(new PublishBlogResponseEvent
            {
                configInfoAndIsSuccessed = null,
                Messages = res,
                IsSuccessed = true,
                Exception = null
            });
        }

    }
}
