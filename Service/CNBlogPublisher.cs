using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlogPublisher.Common;
using BlogPublisher.Helper;
using BlogPublisher.Model;

namespace BlogPublisher.Service
{
    internal class CNBlogPublisher
    {
        string url = "https://rpc.cnblogs.com/metaweblog/yghr3a";
        string username = "yghr3a";
        string password = "<填写你的密钥>";
        string path = "";

        public void testPublishBlog()
        {
            var post = new Post()
            {
                title = "博客园MetaWeBlog测试文章",
                description = "这是内容",
                categories = new string[] { "随笔" }
            };

            var proxy = MetaWeblogHelper.Create(url);

            var res = proxy.NewPost("233", username, password, post, false);

            MessageBox.Show(res);
        }
    }
}
