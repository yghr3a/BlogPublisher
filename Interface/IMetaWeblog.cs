using CookComputing.XmlRpc;
using BlogPublisher.Model;
using BlogPublisher.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Interface
{
    public interface IMetaWeblog : IXmlRpcProxy
    {
        /// <summary>
        /// MetaWeBlog发布文章
        /// </summary>
        /// <param name="blogid"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="post"></param>
        /// <param name="publish"></param>
        /// <returns></returns>
        [XmlRpcMethod("metaWeblog.newPost")]
        string NewPost(string blogid, string username, string password,
            Post post, bool publish);

        // 获取用户博客文章信息, 
        //[XmlRpcMethod("metaWeblog.getUsersBlogs")]
        //BlogInfo[] GetUsersBlogs(string appKey, string username, string password);
    }

}
