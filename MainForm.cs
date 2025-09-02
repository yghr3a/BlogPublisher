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
using System.Linq;

namespace BlogPublisher
{
    public partial class MainForm : Form
    {
        private PublishConfigService _config = new PublishConfigService();

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPublishConfig();
        }

        private void ConfirmPublishButton_Click(object sender, EventArgs e)
        {
            var checkedItems = PublishConfigCheckedListBox.CheckedItems;
            var names = new List<string>();

            foreach (string item in checkedItems)
            {
                names.Add(item);
            }

        }

        private void LoadPublishConfig()
        {
            PublishConfigCheckedListBox.Items.Clear();
            var names = _config.LoadName();

            foreach( var name in names )
            {
                PublishConfigCheckedListBox.Items.Add( name, false);
            }
        }

        private void AddPublishConfig(object sender, EventArgs e)
        {
            var form = new AddPublishConfigForm();
            form.Show();
        }
    }
}
