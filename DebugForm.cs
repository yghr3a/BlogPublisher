using BlogPublisher.Helper;
using BlogPublisher.Interface;
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
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ReadFileNameDebugButton_Click(object sender, EventArgs e)
        {
            string path = FilePathTextBox.Text;

            string name = FileHelper.GetFileNameWithoutExtension(path);

            MessageBox.Show(name);
        }

        private void ReadFileDebugBotton_Click(object sender, EventArgs e)
        {
            string path = FilePathTextBox.Text;

            string content = FileHelper.GetFileContent(path);

            MessageBox.Show(content);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            ArgeHelper.GoalUrl = urlTextBox.Text;
            ArgeHelper.BlogFilePath = PolishFilePathTextBox.Text;
            ArgeHelper.UserName = usernameTextBox.Text;
            ArgeHelper.Password = passwordTextBox.Text;

            //var blog = new BlogPublish();
            //blog.PublishBlog();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cnblog = new CNBlogPublisher();

            cnblog.testPublishBlog();
        }
    }
}
