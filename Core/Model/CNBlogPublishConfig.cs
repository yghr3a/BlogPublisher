using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogPublisher.Model
{
    public class CNBlogPublishConfig : IPublishConfig
    {
        [JsonPropertyName("config_name")]
        public string ConfigName { get; set; }
        [JsonPropertyName("config_type")]
        public string PublishConfigType { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}