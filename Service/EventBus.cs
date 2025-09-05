using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Service
{
    /// <summary>
    /// 事件总线, 目前主要负责服务层与UI层的消息通讯, 减少耦合度
    /// </summary>
    public class EventBus
    {
        // 事件名与事件处理方法的"花名册"
        private static readonly Dictionary<string, Action<object>> _eventAndHandler = new Dictionary<string, Action<object>>();

        public static void SubscribeEvent(string eventName, Action<object> action)
        {
            // 后面会针对性地搞一些客制化异常在这里的
            if (_eventAndHandler.ContainsKey(eventName))
                throw new Exception("该事件已被订阅");

            _eventAndHandler[eventName] = action;
        }

        public static void PublishEvent(string eventName, object arg)
        {
            if (_eventAndHandler.ContainsKey(eventName))
            {
                // 选择所有订阅了该事件的处理方法
                var _goalEventHandlers = from nameAndHandler in _eventAndHandler
                                         where nameAndHandler.Key == eventName
                                         select nameAndHandler.Value;

                foreach (var handler in _goalEventHandlers)
                {
                    handler?.Invoke(arg);
                }
            }

            // TODO: 如果有机会增加日志功能可以在这里加上尝试发布未订阅的事件
        }
    }
}
