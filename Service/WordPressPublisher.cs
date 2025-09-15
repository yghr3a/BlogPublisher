using BlogPublisher.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogPublisher.Service
{
    /// <summary>
    /// WordPress 博客发布服务, 使用 WordPress REST API
    /// 在后面会考虑将C# HttpClient相关的底层操作交给一个单独的Helper类来处理
    /// </summary>
    public class WordPressPublisher
    {
        private readonly HttpClient _client = new HttpClient();
        /// <summary>
        /// 博客信息, 因为用户的一次确认发布根据多个发布配置发布, 但只发布一篇博客
        /// 所以先缓存博客信息作为成员变量, 然后每次发布时使用即可, 能有效减少参数传递
        /// [2025/9/15] 放弃使用上面的思路，改为每次发布时传递博客信息
        /// 1. 可以是这个类从带状态的类变为无状态的类，更加符合单一职责原则，也更容易维护
        /// 2. 避免了多线程环境下的状态冲突问题
        /// 后续会将WordPressPublisher与其他的发布者类订阅成Single模式，减少内存占用与资源浪费
        /// 同时并不会影响批量并发发布博客（并发的是异步方法并非对对象）
        /// </summary>
        private BlogInfo _blogInfo;
        private string title => _blogInfo.title;
        private string content => _blogInfo.blogContent;
        private bool isDraft => _blogInfo.isDraft;

        // 发布博客
        public async Task<string> PublishBlogAsync(BlogInfo blogInfo, WordPressPublishConfig config)
        {
            _blogInfo = blogInfo;

            var siteUrl = config.Url;
            var username = config.UserName;
            var appPassword = config.Password;
            var _apiBaseUrl = siteUrl;

            var postData = new
            {
                title,
                content,
                status = isDraft ? "draft" : "publish"
            };

            if (string.IsNullOrWhiteSpace(username))
                return $"[{config.ConfigName}]:发布失败！配置用户名为空!";

            if(string.IsNullOrWhiteSpace(appPassword))
                return $"[{config.ConfigName}]:发布失败！配置密码为空!";

            // 生成 Basic Auth 头
            var authBytes = Encoding.UTF8.GetBytes($"{username}:{appPassword}");
            var _authHeader = Convert.ToBase64String(authBytes);


            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiBaseUrl}/wp-json/wp/v2/posts");
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", _authHeader);
                request.Content = new StringContent(JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json");

                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                using (var doc = JsonDocument.Parse(responseJson))
                {
                    return $"[{config.ConfigName}]发布成功！文章ID: {doc.RootElement.GetProperty("id")}";
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"发布失败: {ex.Message}");
            }
        }

    }

}
