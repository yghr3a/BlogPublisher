using BlogPublisher.Common;
using BlogPublisher.Helper;
using BlogPublisher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Service
{
    /// <summary>
    /// 对于BlogInfo的初始话与清理还需要多多考虑一下, 现在靠的是LoadConfigAndBlog方法来直接覆盖
    /// </summary>
    public class BlogPublishService
    {

        private PublishConfigService _publishConfigService = new PublishConfigService();
        private List<PublishConfigTypeAndName> _selectedconfigs = new List<PublishConfigTypeAndName>();

        private WordPressPublisher _wordPressPublisher = new WordPressPublisher();
        private CNBlogPublishConfig _cnBlogPublishConfig = new CNBlogPublishConfig();

        private BlogInfo _blogInfo = new BlogInfo();

        /// <summary>
        /// 加载发布配置与博客内容, 会将散乱的博客信息整理成BlogInfo类型并加载到所有发布器对象中
        /// 存储发布配置的名字与类型作为成员变量
        /// </summary>
        /// <param name="configsTypeAndNames"></param>
        /// <param name="blogFilePath"></param>
        /// <param name="blogTitle"></param>
        public void LoadConfigAndBlog(List<PublishConfigTypeAndName> configsTypeAndNames, string blogFilePath, string blogTitle, string[] categories = null, bool isDraft = false)
        {
            _selectedconfigs = configsTypeAndNames;

            var blogContent = FileHelper.GetFileContent(blogFilePath);
            
            if(string.IsNullOrWhiteSpace(blogTitle))
                blogTitle = FileHelper.GetFileNameWithoutExtension(blogFilePath);

            _blogInfo.title = blogTitle;
            _blogInfo.blogContent = blogContent;
            _blogInfo.isDraft = isDraft;
            _blogInfo.categories = categories;

            _wordPressPublisher.LoadBlogInfo(_blogInfo);
            // cn的加载还没写
        }

        /// <summary>
        /// 发布博客, 会根据发布配置的类型选择对应的发布器类
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> PublishBlog()
        {
            string res = "";

            if(_selectedconfigs == null || _selectedconfigs.Count == 0)
                return "没有选择发布配置";

            if (string.IsNullOrWhiteSpace(_blogInfo.blogContent))
                return "博客内容为空";

            foreach (var configs in _selectedconfigs)
            {
                if (configs.PublishConfigType == PublishConfigTypeHelper.wordPressPublishConfigType)
                {
                    res += await WordPressPublish(configs.PublishConfigName);
                }
                else if (configs.PublishConfigType == PublishConfigTypeHelper.cnBlogPublishConfigType)
                {
                    res += await CNBlogPublish();
                }
                else
                {
                    throw new Exception("不支持的发布类型");
                }

                res += '\n';
            }

            

            return res;
        }

        private async Task<string> WordPressPublish(string publishConfigName)
        {
            var config = _publishConfigService.Load<WordPressPublishConfig>(publishConfigName);
            var res = await _wordPressPublisher.PublishPostAsync(config);
            return res;
        }
        private async Task<string> CNBlogPublish()
        {
            return "";
        }
    }
}
