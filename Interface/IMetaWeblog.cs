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
        [XmlRpcMethod("metaWeblog.newPost")]
        string NewPost(string blogid, string username, string password,
            Post post, bool publish);

        [XmlRpcMethod("metaWeblog.getUsersBlogs")]
        BlogInfo[] GetUsersBlogs(string appKey, string username, string password);
    }

}
