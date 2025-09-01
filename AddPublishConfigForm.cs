using BlogPublisher.Model;
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

namespace BlogPublisher
{
    public partial class AddPublishConfigForm : Form
    {

        PublishConfigService _publishConfig = new PublishConfigService();

        public AddPublishConfigForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void 添加发布配置信息_Load(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void WordPressGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void ConfigInfoGroupBox_Enter(object sender, EventArgs e)
        {

        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void PublishConfigTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = PublishConfigTypeComboBox.SelectedItem.ToString();
            InitGroupBox.Visible = false;
            WordPressGroupBox.Visible = selected == "WordPress发布配置";
            BlogCNGroupBox.Visible = selected == "博客园发布配置";
        }

        private void WordPressGroupBox_Enter_1(object sender, EventArgs e)
        {

        }

        private void ConfirmAddConfigButton_Click(object sender, EventArgs e)
        {
            var selected = PublishConfigTypeComboBox.SelectedItem.ToString();
            if (selected == "WordPress发布配置")
            {
                var config = new WordPressPublishConfig();
                config.ConfigName = PublishConfigNameTextBox.Text;
                config.Url = WPUrlTextBox.Text;
                config.UserName = WPUserNameTextBox.Text;
                config.Password = WPPasswordTextBox.Text;

                _publishConfig.Add<WordPressPublishConfig>(config);
            }
            else
            {
                MessageBox.Show("未实装!");
            }
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // var name = "";
            var config = _publishConfig.Load<WordPressPublishConfig>("测试Json格式化与编码");

            MessageBox.Show($"配置名:{config.ConfigName}\r\nUrl:{config.Url}\r\n用户名:{config.UserName}\r\n密码:{config.Password}");
        }
    }
}
