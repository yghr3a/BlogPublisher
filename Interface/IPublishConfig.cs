using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Model
{
    public interface IPublishConfig
    {
        // 每一个配置都应该有一个名字, 用于区分
        string ConfigName { get; set; }

        // 发布配置接口的运行时类型
        string PublishConfigType {  get; set; }
    }
}
