using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Model
{

    /// <summary>
    /// 配置文件的类型与名字，在本次项目中，“发布配置的类型与名字”是区别不同发布配置的唯一标识，也是最简化信息
    /// 用途一：在主窗口中会获取该类型的列表来显示在发布配置的选择列表中
    /// 用途二：在发布博客时会使用该类型来储存发布配置最简化信息
    /// 基于以上两点，该类在后续Core层与UI层分家时需要公开供UI层使用
    /// [2025/9/22] 改名字，PublishConfigIdentity比较符合该类的职责，突出了最简化信息的身份标识作用
    /// </summary>
    public class PublishConfigIdentity
    {
        public string PublishConfigName { get ; set; }
        public Type PublishConfigType { get; set; }

        // 为了在CheckedListBox中显示配置名称，重写ToString方法
        public override string ToString()
        {
            return PublishConfigName;
        }
    }
}
