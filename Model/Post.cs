using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Model
{
    public class Post
    {
        public string title;
        public string description;
        public string[] categories;
    }

    public struct BlogInfo
    {
        public string blogid;
        public string blogName;
        public string url;
    }
}
