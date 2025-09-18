using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPublisher.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlogPublisher.Core.Application
{
    /// <summary>
    /// 服务管理器, 用于管理应用程序中的各种服务的生命周期和依赖注入
    /// </summary>
    internal class ServiceManager
    {
        internal static IServiceProvider ServiceProvider { get; private set; }
        internal static ServiceCollection Services { get; private set; }

        internal static void InitSeviceManager()
        {
            Services = new ServiceCollection();

            // 注册应用服务
            Services.AddSingleton<ApplicationService>();

            // 注册各种服务
            Services.AddSingleton<BlogPublishService>();
            Services.AddSingleton<PublishConfigService>();
            Services.AddSingleton<PublisherStrategyFactory>();

            // 注册发布策略
            Services.AddSingleton<WordPressPublishStrategy>();
            Services.AddSingleton<CNBlogPublishStrategy>();

            // 注册发布器
            Services.AddSingleton<WordPressPublisher>();
            Services.AddSingleton<CNBlogPublisher>();

            ServiceProvider = Services.BuildServiceProvider();
        }

        /// <summary>
        /// [2025/9/15] 获取所需服务方法,后续会实现通过构造方法来实现依赖注入以替换这个方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal static T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
