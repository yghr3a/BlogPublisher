using BlogPublisher.Model;
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
        // 事件名与事件处理方法的"花名册", 一种事件对应着一个委托列表
        private static readonly Dictionary<Type, List<Delegate>> _eventAndHandler = new Dictionary<Type, List<Delegate>>();

        /// <summary>
        /// 订阅消息, 只需要传入处理该事件的委托
        /// where T : IEvent, new() 限定了事件类型必须是实现IEvent接口且有无参构造函数的非抽象类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        public static void SubscribeEvent<T>(Action<T> action) where T : IEvent, new()
        {
            var eventType = typeof(T);

            // 如果还没有该事件的订阅列表, 则创建一个新的
            if (_eventAndHandler.ContainsKey(eventType) == false)
                _eventAndHandler.Add(eventType, new List<Delegate>());

            _eventAndHandler[eventType].Add(action);
        }

        /// <summary>
        /// 发布消息, 只需要传入事件对象即可订阅对应的事件
        /// where T : IEvent, new() 限定了事件类型必须是实现IEvent接口且有无参构造函数的非抽象类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Event"></param>
        public static void PublishEvent<T>(T Event) where T : IEvent, new()
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
