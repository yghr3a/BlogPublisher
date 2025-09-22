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
    /// [2025/9/22] 弃用了 LoadConfigAndBlog 方法，改为直接在 PublishBlog 方法中传入博客信息
    /// </summary>
    public class BlogPublishService
    {
        /// <summary>
        /// [2025/9/15] 这些服务后续改成构造函数依赖注入的方式
        /// </summary>
        private PublishConfigService _publishConfigService = ServiceManager.GetService<PublishConfigService>();
        private PublisherStrategyFactory _publisherStrategyFactory = ServiceManager.GetService<PublisherStrategyFactory>();

        private List<PublishConfigIdentity> _selectedConfigs = new List<PublishConfigIdentity>();
        private BlogInformation _blogInformation = new BlogInformation();

        /// <summary>
        /// 加载发布配置与博客内容, 会将散乱的博客信息整理成BlogInfo类型
        /// 存储发布配置的名字与类型作为成员变量
        /// [2025/9/22] 该方法弃用，改为直接在PublishBlog方法中传入博客信息
        /// </summary>
        /// <param name="configsTypeAndNames"></param>
        /// <param name="blogFilePath"></param>
        /// <param name="blogTitle"></param>
        //public void LoadConfigAndBlog(List<PublishConfigIdentity> configsTypeAndNames, string blogFilePath, string blogTitle, string[] categories = null, bool isDraft = false)
        //{
        //    _selectedConfigs = configsTypeAndNames;

        //    var blogContent = FileHelper.GetFileContent(blogFilePath);

        //    if(string.IsNullOrWhiteSpace(blogTitle))
        //        blogTitle = FileHelper.GetFileNameWithoutExtension(blogFilePath);

        //    _blogInformation.title = blogTitle;
        //    _blogInformation.blogContent = blogContent;
        //    _blogInformation.isDraft = isDraft;
        //    _blogInformation.categories = categories;
        //}

        /// <summary>
        /// 发布博客, 会根据发布配置的类型选择对应的发布器类
        /// [2025/9/20] 重构, 开始使用PublishResult来记录单独发布操作的发布结果
        /// [2025/9/22] 重构，原先使用LoadConfigAndBlog方法来加载博客信息与发布配置比较繁琐，现在改为直接作为参数来传入博客信息
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task PublishBlog(List<PublishConfigIdentity> configsTypeAndNames, BlogInformation blogInformation)
        {
            // [2025/9/20] 存储各个发布结果的列表
            var res = new List<PublishResult>();

            // [2025/9/20] 记录发布失败的原因
            var failedReason = new List<string>();

            // [2025/9/22] 被选中的配置信息
            _selectedConfigs = configsTypeAndNames;

            // [2025/9/22] 获取博客内容, 赋值到blogInformation中
            blogInformation.BlogContent = FileHelper.GetFileContent(blogInformation.BlogFilePath);

            // [2025/9/22] 如果博客标题为空, 则使用博客文件名作为标题
            if (string.IsNullOrWhiteSpace(blogInformation.Title))
                blogInformation.Title = FileHelper.GetFileNameWithoutExtension(blogInformation.BlogFilePath);

            if (_selectedConfigs == null || _selectedConfigs.Count == 0)
                failedReason.Add("没有选择发布配置");

            if (string.IsNullOrWhiteSpace(_blogInformation.BlogContent))
                failedReason.Add("博客内容为空");

            // 如果failedReason有元素了, 说明出问题了, 发个"PublishBlogError"事件就return了
            if (failedReason.Count > 0)
            {
                EventBus.PublishEvent(new PublishBlogResponseEvent()
                {
                    IsSuccessed = false,
                    FailReasons = failedReason
                });
                return;
            }

            // 发布博客异步方法列表， 用于后面的并发操作
            var tasks = _selectedConfigs.Select(configs =>
            {
                // 利用发布策略工厂根据发布配置的获取对应的发布策略
                var publishStrategy = _publisherStrategyFactory.GetPublishStrategy(configs.PublishConfigType);
                return publishStrategy.PublishBlogAsync(_blogInformation, configs);
            });

            // 并发操作执行博客任务, 并将结果信息加入res
            res.AddRange(await Task.WhenAll(tasks));

            // 能到这一步说明发布博客很顺利, 发个"PublishBlog"事件报告一下
            EventBus.PublishEvent(new PublishBlogResponseEvent
            {
                publishResults = res,
                FailReasons = null,
                IsSuccessed = true,
                Exception = null
            });
        }

    }
}
