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
        // 事件名与事件处理方法的"花名册", 一个事件对应着一个委托列表
        private static readonly Dictionary<string, List<Delegate>> _eventAndHandler = new Dictionary<string, List<Delegate>>();

        public static void SubscribeEvent<T>(string eventName, Action<T> action)
        {
            // 如果还没有该事件的订阅列表, 则创建一个新的
            if (_eventAndHandler.ContainsKey(eventName) == false)
                _eventAndHandler.Add(eventName, new List<Delegate>());

            _eventAndHandler[eventName].Add(action);
        }

        public static void PublishEvent<T>(string eventName, T arg)
        {
            if (_eventAndHandler.ContainsKey(eventName))
            {
                // 选择所有订阅了该事件的处理委托
                var _goalEventDelegates = _eventAndHandler[eventName];

                // 这里使用类型转换成对应参数的方法列表, 然后调用
                //if (_goalEventDelegates is List<Action<T>> _goalEventHandlers)
                //{
                //    foreach (var handler in _goalEventHandlers)
                //    {
                //        handler?.Invoke(arg);
                //    }
                //}

                foreach (var del in _goalEventDelegates)
                {
                    if (del is Action<T> action)
                    {
                        action?.Invoke(arg);
                    }
                }
            }

            // TODO: 如果有机会增加日志功能可以在这里加上尝试发布未订阅的事件
        }
    }
}
