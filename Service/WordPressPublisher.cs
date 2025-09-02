using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogPublisher.Service
{
    public class WordPressPublisher
    {
        private readonly HttpClient _client;
        private readonly string _apiBaseUrl;
        private readonly string _authHeader;

        public WordPressPublisher(string siteUrl, string username, string appPassword)
        {
            _client = new HttpClient();
            _apiBaseUrl = siteUrl;

            // 生成 Basic Auth 头
            var authBytes = Encoding.UTF8.GetBytes($"{username}:{appPassword}");
            _authHeader = Convert.ToBase64String(authBytes);
        }

        public async Task<string> PublishPostAsync(string title, string content, bool isDraft = false)
        {
            try
            {
                var postData = new
                {
                    title = new { raw = title },
                    content = new { raw = content },
                    status = isDraft ? "draft" : "publish"
                };

                var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiBaseUrl}/posts");
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", _authHeader);
                request.Content = new StringContent(JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json");

                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                using (var doc = JsonDocument.Parse(responseJson))
                {
                    return $"发布成功！文章ID: {doc.RootElement.GetProperty("id")}";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"发布失败: {ex.Message}");
            }
        }

    }

}
