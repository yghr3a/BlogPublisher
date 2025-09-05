using BlogPublisher.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlogPublisher.Model;

namespace BlogPublisher
{
    public partial class MainForm : Form
    {
        private PublishConfigService _config = new PublishConfigService();
        private BlogPublishService _blogPublishService = new BlogPublishService();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗口加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 加载发布配置内容到发布配置列表里
            LoadPublishConfig();

            // 初始化事件订阅
            InitSubcribeEvent();
        }

        /// <summary>
        /// 确认发布按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ConfirmPublishButton_Click(object sender, EventArgs e)
        {
            var checkedItems = PublishConfigCheckedListBox.CheckedItems;
            var selectedConfigs = new List<PublishConfigTypeAndName>();

            foreach (PublishConfigTypeAndName item in checkedItems)
            {
                selectedConfigs.Add(item);
            }

            _blogPublishService.LoadConfigAndBlog(selectedConfigs, FilePathTextBox.Text, BlogTitleTextBox.Text);
            await _blogPublishService.PublishBlog();
        }

        /// <summary>
        /// 加载发布配置内容到发布配置列表里
        /// </summary>
        private void LoadPublishConfig()
        {
            PublishConfigCheckedListBox.Items.Clear();
            var _configsTypeAndName = _config.LoadPublishConfigTypeAndName();

            foreach( var item in _configsTypeAndName)
            {
                PublishConfigCheckedListBox.Items.Add(item, false);
            }
        }

        /// <summary>
        /// 初始化事件订阅
        /// </summary>
        private void InitSubcribeEvent()
        {
            // 订阅发布博客成功与失败事件
            EventBus.SubscribeEvent("PublishBlogOK", OnPublishBlogOK);
            EventBus.SubscribeEvent("PublishBlogError", OnPublishBlogError);
        }

        /// <summary>
        /// 添加发布配置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPublishConfig(object sender, EventArgs e)
        {
            var form = new AddPublishConfigForm();
            form.Show();
        }

        /// <summary>
        /// 发布博客成功事件处理方法
        /// </summary>
        /// <param name="messges"></param>
        private void OnPublishBlogOK(object arg)
        {
            if (arg is List<string> messges)
            {            
                string messge = "";
                foreach (var m in messges)
                    messge += m;
                MessageBox.Show(Text = messge, "发布成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                throw new Exception("OnPublishBlogOK事件参数错误");
        }

        /// <summary>
        /// 发布博客失败事件处理方法
        /// </summary>
        /// <param name="messges"></param>
        private void OnPublishBlogError(object arg)
        {
            if (arg is List<string> messges)
            {
                string messge = "";
                foreach (var m in messges)
                    messge += m;
                MessageBox.Show(Text = messge, "发布失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                throw new Exception("OnPublishBlogError事件参数错误");
        }
    }
}
