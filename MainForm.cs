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
using BlogPublisher.Core.Application;

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
        /// TODO : 这里后续可以考虑加个刷新按钮
        /// TODO : 后续要改为事件驱动
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
            // 订阅发布博客事件 
            EventBus.SubscribeEvent<PublishBlogEvent>(OnPublishBlog);
            // 订阅添加发布配置事件
            EventBus.SubscribeEvent<AddPublishConfigFinishedEvent>(OnAddPublishConfig);
            // 订阅加载发布配置事件
            EventBus.SubscribeEvent<LoadPublishConfigEvent>(OnLoadPublishConfig);

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

        private void OnPublishBlog(PublishBlogEvent _event)
        {         
            if(_event.IsSuccessed == true)
            {
                var info = "";
                // Tips : 注释掉的部分是后面才要实现的内容:"服务层只提供每个配置的名字、类型、是否成功、若失败的原因，之后交给UI端拼接内容"
                //foreach(var item in _event.configInfoAndIsSuccessed)
                //{
                //    info += $"[{item.Key.Key}]";
                //    if(item.Value == true)
                //        info += "发布成功\n";
                //    else
                //        info += "发布失败\n";
                //}
                //MessageBox.Show(info, "博客发布成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //  目前为了适配服务端现有的代码，先简单点
                foreach(var msg in _event.Messages)
                {
                    info += $"{msg}\n";
                }
                MessageBox.Show(info, "博客发布成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var info = $"[异常]{_event.Exception.ToString()}";
                MessageBox.Show(info, "博客发布失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 当发布配置添加成功时, 主窗口这里也需要重新加载配置框得内容
        /// </summary>
        /// <param name="obj"></param>
        private void OnAddPublishConfig(AddPublishConfigFinishedEvent _event)
        {
            // 直接调用自带的发布配置加载方法就OK了
            LoadPublishConfig();
        }


        private void OnLoadPublishConfig(LoadPublishConfigEvent _event)
        {

        }
    }
}
