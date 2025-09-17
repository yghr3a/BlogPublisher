using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Core.Application
{
    /// <summary>
    /// Core初始化器, 用于Core组件的初始化, 属于Core项目的项目入口
    /// </summary>
    public class CoreInitializer
    {
        private static bool isInit = false;

        public static void Init()
        {
            // 确保只初始化一次
            if (isInit) return;

            // 初始化ServiceManager
            ServiceManager.InitSeviceManager();

            // 初始化ApplicationService
            // [2025/9/17] 需要重新考虑是由ServiceManager来初始化, 还是由CoreInitializer来初始化
            ApplicationService.InitApplicationService();

            // 订阅各个窗口初始化事件
            isInit = true;
        }
    }
}
