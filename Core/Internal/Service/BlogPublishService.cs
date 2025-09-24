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
    internal class BlogPublishService
    {
        /// <summary>
        /// [2025/9/15] 这些服务后续改成构造函数依赖注入的方式
        /// </summary>
        private PublishConfigService _publishConfigService = ServiceManager.GetService<PublishConfigService>();
        private PublisherStrategyFactory _publisherStrategyFactory = ServiceManager.GetService<PublisherStrategyFactory>();

        /// [2025/9/20] 重构, 开始使用PublishResult来记录单独发布操作的发布结果
        /// [2025/9/22] 重构, 原先使用LoadConfigAndBlog方法来加载博客信息与发布配置比较繁琐，现在改为直接作为参数来传入博客信息
        /// [2025/9/23] 重构, 返回值类型改为Task<PublishAggregateResult>, 便于ApplicationServcie接受返回结果
        /// <summary>
        /// 发布博客操作
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal async Task<PublishAggregateResult> PublishBlog(List<PublishConfigIdentity> selectedConfigs, BlogInformation blogInformation)
        {
            // [2025/9/20] 存储各个发布结果的列表
            var res = new List<PublishResult>();

            // [2025/9/20] 记录发布失败的原因
            var failedReason = new List<string>();

            // [2025/9/22] 获取博客内容, 赋值到blogInformation中
            blogInformation.BlogContent = FileHelper.GetFileContent(blogInformation.BlogFilePath);

            // [2025/9/22] 如果博客标题为空, 则使用博客文件名作为标题
            if (string.IsNullOrWhiteSpace(blogInformation.Title))
                blogInformation.Title = FileHelper.GetFileNameWithoutExtension(blogInformation.BlogFilePath);

            if (selectedConfigs == null || selectedConfigs.Count == 0)
                failedReason.Add("没有选择发布配置");

            if (string.IsNullOrWhiteSpace(blogInformation.BlogContent))
                failedReason.Add("博客内容为空");

            // 如果failedReason有元素了, 说明出问题了
            if (failedReason.Count > 0)
                return new PublishAggregateResult()
                {
                    IsSuccessed = false,
                    FailedReasons = failedReason
                };

            // 发布博客异步方法列表， 用于后面的并发操作
            var tasks = selectedConfigs.Select(configs =>
            {
                // 利用发布策略工厂根据发布配置的获取对应的发布策略
                var publishStrategy = _publisherStrategyFactory.GetPublishStrategy(configs.PublishConfigType);
                return publishStrategy.PublishBlogAsync(blogInformation, configs);
            });

            // 并发操作执行博客任务, 并将结果信息加入res
            res.AddRange(await Task.WhenAll(tasks));

            // 能到这一步说明发布博客很顺利
            return new PublishAggregateResult
            {
                PublishResults = res,
                FailedReasons = null,
                IsSuccessed = true,
            };
        }

    }
}
