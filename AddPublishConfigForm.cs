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

        PublishConfigService _publishConfig = new PublishConfigService();

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

                _publishConfig.Add<WordPressPublishConfig>(config);
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

                _publishConfig.Add<CNBlogPublishConfig>(config);
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
            EventBus.SubscribeEvent<AddPublishConfigEvent>(OnAddPublishConfig);
        }


        private void OnAddPublishConfig(AddPublishConfigEvent _event)
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
            }

            MessageBox.Show($"[异常]{_event.Exception?.ToString()}", "出现异常", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
