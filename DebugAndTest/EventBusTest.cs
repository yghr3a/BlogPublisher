using BlogPublisher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPublisher.Model;

namespace BlogPublisher.Service
{
    /// <summary>
    /// 事件总线, 目前主要负责服务层与UI层的消息通讯, 减少耦合度
    /// </summary>
    public class EventBusTest
    {
        // 事件名与事件处理方法的"花名册", 一个事件对应着一个委托列表
        private static readonly Dictionary<Type, List<Delegate>> _eventAndHandler = new Dictionary<Type, List<Delegate>>();

        public static void SubscribeEvent<T>(Action<T> action) where T : IEvent
        {
            var eventType = typeof(T);

            // 如果还没有该事件的订阅列表, 则创建一个新的
            if (_eventAndHandler.ContainsKey(eventType) == false)
                _eventAndHandler.Add(eventType, new List<Delegate>());

            _eventAndHandler[eventType].Add(action);
        }

        public static void PublishEvent<T>(T Event) where T : IEvent
        {
            var eventType = typeof(T);

            if (_eventAndHandler.ContainsKey(eventType))
            {
                // 选择所有订阅了该事件的处理委托
                var _goalEventDelegates = _eventAndHandler[eventType];

                foreach (var del in _goalEventDelegates)
                {
                    if (del is Action<T> action)
                    {
                        action?.Invoke(Event);
                    }
                }
            }

            // TODO: 如果有机会增加日志功能可以在这里加上尝试发布未订阅的事件
        }
    }
}
