using BlogPublisher.Model;
using BlogPublisher.CustomException;
using BlogPublisher.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Core.Application
{
    /// <summary>
    /// 应用程序服务, 作为Core项目与UI项目交互的桥梁
    /// </summary>
    public class ApplicationService
    {
        private static ApplicationService _instance;
        // private PublishConfigService _publishConfigService;
        private static bool _isInit = false;

        /// <summary>
        /// 初始化应用程序服务, 主要工作用于订阅各种事件和获取一些服务实例
        /// </summary>
        internal static void InitApplicationService()
        {
            // [2025/9/17] 简单检测一下是否已经初始化过
            if (_isInit == true)
                return;

            if(_instance == null)
                _instance = ServiceManager.GetService<ApplicationService>();

            _instance.InitSubscribeEvent();

            _isInit = true;
        }

        private void InitSubscribeEvent()
        {
            // 订阅事件时需要指定具体的发布配置类型
            EventBus.SubscribeEvent<AddPublishConfigEvent<WordPressPublishConfig>>(OnAddPublishConfig);
            EventBus.SubscribeEvent<AddPublishConfigEvent<CNBlogPublishConfig>>(OnAddPublishConfig);
        }

        /// <summary>
        /// 添加发布配置事件处理函数
        /// [2025/9/18] 改为使用泛型事件来传递具体的发布配置对象,便于传递类型参数(天才的想法, 不需要定义太多方法了)
        /// </summary>
        /// <typeparam name="TPublishConfig"></typeparam>
        /// <param name="_event"></param>
        private void OnAddPublishConfig<TPublishConfig>(AddPublishConfigEvent<TPublishConfig> _event) where TPublishConfig : class, IPublishConfig, new()
        {
            // [2025/9/17] 目前还未解决如何通过构造函数注入服务实例的问题, 暂时通过ServiceManager来获取服务实例
            var _publishConfigService = ServiceManager.GetService<PublishConfigService>();

            try
            { 
                // 利用服务添加发布配置
                _publishConfigService.Add<TPublishConfig>(_event.PublishConfig);

                // 添加完成后发布添加完成事件
                EventBus.PublishEvent(new AddPublishConfigFinishedEvent()
                {
                    ConfigName = _event.PublishConfig.ConfigName,
                    ConfigType = null, //  这个字段暂时用不上
                    IsSuccessed = true,
                });
            }
            // 出现异常时发布添加完成事件, 并传递异常信息
            catch (FileHelperException ex)
            {
                EventBus.PublishEvent(new AddPublishConfigFinishedEvent()
                {
                    IsSuccessed = false,
                    Exception = ex
                });
            }
            catch(Exception ex)
            {
                EventBus.PublishEvent(new AddPublishConfigFinishedEvent()
                {
                    IsSuccessed = false,
                    Exception = ex
                });
            }
        }
    }
}
