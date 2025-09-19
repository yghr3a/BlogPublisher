using BlogPublisher.Model;
using BlogPublisher.Service;
using BlogPublisher.Core.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogPublisher
{
    public partial class AddPublishConfigForm : Form
    {

        public AddPublishConfigForm()
        {
            // 初始化配件操作
            InitializeComponent();
            // 初始化事件订阅
            InitSubcribeEvent();
        }


        /// <summary>
        /// 发布配置组合框所选项改变时的方法, 根据选择的发布配置类型更新显示的GropBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PublishConfigTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = PublishConfigTypeComboBox.SelectedItem.ToString();
            InitGroupBox.Visible = false;
            WordPressGroupBox.Visible = selected == "WordPress发布配置";
            BlogCNGroupBox.Visible = selected == "博客园发布配置";
        }

        /// <summary>
        /// 当确认添加配置按钮被点击时
        /// [2025/9/18] 重构, 通过发布事件的方式将添加配置的请求传递到Core应用层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmAddConfigButton_Click(object sender, EventArgs e)
        {
            var selected = PublishConfigTypeComboBox.SelectedItem.ToString();
            if (selected == "WordPress发布配置")
            {
                var config = new WordPressPublishConfig
                {
                    ConfigName = PublishConfigNameTextBox.Text,
                    Url = WPUrlTextBox.Text,
                    UserName = WPUserNameTextBox.Text,
                    Password = WPPasswordTextBox.Text
                };

                EventBus.PublishEvent(new AddPublishConfigRequestEvent<WordPressPublishConfig>
                {
                    PublishConfig = config,
                });
            }
            else if(selected == "博客园发布配置")
            {
                var config = new CNBlogPublishConfig
                {
                    ConfigName = PublishConfigNameTextBox.Text,
                    Url = BKUrlTextBox.Text,
                    UserName = BKUserNameTextBox.Text,
                    Password = BKPasswordTextBox.Text
                };

                EventBus.PublishEvent(new AddPublishConfigRequestEvent<CNBlogPublishConfig>
                { 
                    PublishConfig = config
                });
            }
            else
            {
                MessageBox.Show("未实装!");
            }
        }

        /// <summary>
        /// 初始化事件订阅
        /// </summary>
        private void InitSubcribeEvent()
        {
            EventBus.SubscribeEvent<AddPublishConfigResponseEvent>(OnAddPublishConfig);
        }


        private void OnAddPublishConfig(AddPublishConfigResponseEvent _event)
        {
            if( _event == null)
                return;

            if(_event.IsSuccessed == true)
            {
                MessageBox.Show($"[{_event.ConfigName}]配置添加成功", "配置添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"[{_event.ConfigName}]配置添加失败", "配置添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (_event.Exception != null)
                {
                    MessageBox.Show($"异常信息:{_event.Exception.ToString()}", "配置添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
