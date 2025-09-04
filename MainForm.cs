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


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPublishConfig();
        }

        private async void ConfirmPublishButton_Click(object sender, EventArgs e)
        {
            var checkedItems = PublishConfigCheckedListBox.CheckedItems;
            var selectedConfigs = new List<PublishConfigTypeAndName>();

            foreach (PublishConfigTypeAndName item in checkedItems)
            {
                selectedConfigs.Add(item);
            }

            _blogPublishService.LoadConfigAndBlog(selectedConfigs, FilePathTextBox.Text, BlogTitleTextBox.Text);
            var result = await _blogPublishService.PublishBlog();
            MessageBox.Show(result);
        }

        private void LoadPublishConfig()
        {
            PublishConfigCheckedListBox.Items.Clear();
            var _configsTypeAndName = _config.LoadPublishConfigTypeAndName();

            foreach( var item in _configsTypeAndName)
            {
                PublishConfigCheckedListBox.Items.Add(item, false);
            }

        }

        private void AddPublishConfig(object sender, EventArgs e)
        {
            var form = new AddPublishConfigForm();
            form.Show();
        }
    }
}
