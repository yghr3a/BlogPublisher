using BlogPublisher.Helper;

namespace BlogPublisher.Model
{
    public class BlogInfo
    {
        public string title;
        public string blogContent;
        public string[] categories;
        public bool isDraft;
    }

    /// <summary>
    /// [2025/9/22] 新增博客信息数据类, 用于存储博客的相关信息. 开放供UI层使用, UI层需要将博客信息整理好传递进Core层
    /// 思路: 博客内容可以在get访问器里动态获取
    /// 最终决定职责容易造成混乱改为单一职责, 只负责存储博客信息
    /// </summary>
    public class BlogInformation
    {
        public string Title { get; set; }
        public string BlogFilePath{ get; set; }
        public string BlogContent { get; set; }
        public string[] Tags { get; set; }
        public string[] Categories { get; set; }
        public bool IsDraft { get; set; }
    }

}
