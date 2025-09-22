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
            var selectedConfigs = new List<PublishConfigIdentity>();

            foreach (PublishConfigIdentity item in checkedItems)
            {
                selectedConfigs.Add(item);
            }

            var blog = new BlogInformation()
            {
                BlogFilePath = FilePathTextBox.Text,
                Title = BlogTitleTextBox.Text
            };

            await _blogPublishService.PublishBlog(selectedConfigs, blog);
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
            EventBus.SubscribeEvent<PublishBlogResponseEvent>(OnPublishBlog);
            // 订阅添加发布配置事件
            EventBus.SubscribeEvent<AddPublishConfigResponseEvent>(OnAddPublishConfig);
            // 订阅加载发布配置响应事件
            EventBus.SubscribeEvent<LoadPublishConfigResponseEvent>(OnLoadPublishConfig);
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

        private void OnPublishBlog(PublishBlogResponseEvent _event)
        {         
            if(_event.IsSuccessed == true)
            {
                var successedInfo = "";
                var failedInfo = "";
                // Tips : 注释掉的部分是后面才要实现的内容:"服务层只提供每个配置的名字、类型、是否成功、若失败的原因，之后交给UI端拼接内容"
                var successedResult = _event.publishResults.Where(r => r.IsSuccessed == true).ToList();
                var failedResult = _event.publishResults.Where(r => r.IsSuccessed == false).ToList();
                var exceptionResult = failedResult.Where(r => r.Exception != null).ToList();

                successedResult.ForEach(r =>successedInfo += $"[{r.PublishConfigName}] 发布成功\n");
                failedResult.ForEach(r => failedInfo += $"[{r.PublishConfigName}] 发布失败, 失败原因: {r.FailedReason}\n");

                // TODO 后面需要更新对各种异常结果的处理操作
                //foreach(var r in exceptionResult)
                //{

                //}
                // 有对应的发布结果才弹窗
                if (successedResult.Count != 0)
                    MessageBox.Show(successedInfo, "博客发布成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(failedResult.Count != 0)
                    MessageBox.Show(failedInfo, "博客发布失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void OnAddPublishConfig(AddPublishConfigResponseEvent _event)
        {
            // 直接调用自带的发布配置加载方法就OK了
            LoadPublishConfig();
        }


        private void OnLoadPublishConfig(LoadPublishConfigResponseEvent _event)
        {
           
        }
    }
}
