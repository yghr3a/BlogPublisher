using BlogPublisher.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Model
{
    public enum EventType
    {
        AddPublishConfigEvent,
        PublishBlogEvent,
        LoadPublishBlogEvent
    }

    public interface IEvent
    {
        EventType EventType { get; }
        string IsSuccessed { get; set; }
        Exception exception { get; set; }
    }

    public class AddPublishConfigEvent : IEvent
    {
        public EventType EventType { get; }
        public string ConfigName { get; set; }
        public string ConfigType { get; set; }
        public string IsSuccessed { get; set; }
        public Exception exception { get; set; }

        public AddPublishConfigEvent()
        {
            EventType = EventType.AddPublishConfigEvent;
        }
    }

    public class PublishBlogEvent : IEvent
    {
        public EventType EventType { get; }
        public string ConfigName { get; set; }
        public string ConfigType { get; set; }
        public string IsSuccessed { get; set; }
        public Exception exception { get; set; }

        public PublishBlogEvent()
        {
            EventType = EventType.PublishBlogEvent;
        }
    }

    public class LoadPublishBlogEvent : IEvent
    {
        public EventType EventType { get; }
        public List<KeyValuePair<string, ConfigType>> ConfigTypeAndName { get; set; }
        public string IsSuccessed { get; set; }
        public Exception exception { get; set; }
        public LoadPublishBlogEvent()
        {
            EventType = EventType.LoadPublishBlogEvent;
        }
    }

}
