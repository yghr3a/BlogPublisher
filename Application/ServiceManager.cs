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

            // 注册各种服务
            Services.AddSingleton<BlogPublishService>();
            Services.AddSingleton<PublishConfigService>();
            // 注册其他服务
            //

            ServiceProvider = Services.BuildServiceProvider();
        }

        internal static T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
