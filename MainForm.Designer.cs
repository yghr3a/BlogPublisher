namespace BlogPublisher
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ConfirmPublishButton = new System.Windows.Forms.Button();
            this.HelpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PublishConfigCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.BlogInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.BlogTitleTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.BlogInfoGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.查看编辑ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(599, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.帮助ToolStripMenuItem.Text = "添加配置";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.AddPublishConfig);
            // 
            // 查看编辑ToolStripMenuItem
            // 
            this.查看编辑ToolStripMenuItem.Name = "查看编辑ToolStripMenuItem";
            this.查看编辑ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.查看编辑ToolStripMenuItem.Text = "删除配置";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BlogInfoGroupBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 531);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel6);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 434);
            this.groupBox4.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.groupBox4.MinimumSize = new System.Drawing.Size(0, 69);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(593, 94);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "操作";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.HelpLinkLabel, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(587, 70);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.ClearButton, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.ConfirmPublishButton, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(287, 64);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClearButton.Location = new System.Drawing.Point(157, 15);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(115, 33);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "清空";
            this.ClearButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmPublishButton
            // 
            this.ConfirmPublishButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConfirmPublishButton.Location = new System.Drawing.Point(14, 15);
            this.ConfirmPublishButton.Name = "ConfirmPublishButton";
            this.ConfirmPublishButton.Size = new System.Drawing.Size(114, 33);
            this.ConfirmPublishButton.TabIndex = 0;
            this.ConfirmPublishButton.Text = "确认发布";
            this.ConfirmPublishButton.UseVisualStyleBackColor = true;
            this.ConfirmPublishButton.Click += new System.EventHandler(this.ConfirmPublishButton_Click);
            // 
            // HelpLinkLabel
            // 
            this.HelpLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpLinkLabel.AutoSize = true;
            this.HelpLinkLabel.Location = new System.Drawing.Point(457, 55);
            this.HelpLinkLabel.Name = "HelpLinkLabel";
            this.HelpLinkLabel.Size = new System.Drawing.Size(127, 15);
            this.HelpLinkLabel.TabIndex = 1;
            this.HelpLinkLabel.TabStop = true;
            this.HelpLinkLabel.Text = "遇到困难？点这里";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PublishConfigCheckedListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(3, 103);
            this.groupBox1.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.groupBox1.MinimumSize = new System.Drawing.Size(0, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 325);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择发布配置";
            // 
            // PublishConfigCheckedListBox
            // 
            this.PublishConfigCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PublishConfigCheckedListBox.FormattingEnabled = true;
            this.PublishConfigCheckedListBox.Location = new System.Drawing.Point(3, 21);
            this.PublishConfigCheckedListBox.Name = "PublishConfigCheckedListBox";
            this.PublishConfigCheckedListBox.Size = new System.Drawing.Size(587, 301);
            this.PublishConfigCheckedListBox.TabIndex = 0;
            // 
            // BlogInfoGroupBox
            // 
            this.BlogInfoGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.BlogInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlogInfoGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BlogInfoGroupBox.Location = new System.Drawing.Point(3, 3);
            this.BlogInfoGroupBox.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.BlogInfoGroupBox.MinimumSize = new System.Drawing.Size(0, 84);
            this.BlogInfoGroupBox.Name = "BlogInfoGroupBox";
            this.BlogInfoGroupBox.Size = new System.Drawing.Size(593, 94);
            this.BlogInfoGroupBox.TabIndex = 1;
            this.BlogInfoGroupBox.TabStop = false;
            this.BlogInfoGroupBox.Text = "文章信息设置";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.FilePathTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BlogTitleTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(587, 70);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilePathTextBox.Location = new System.Drawing.Point(83, 3);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(501, 25);
            this.FilePathTextBox.TabIndex = 5;
            // 
            // BlogTitleTextBox
            // 
            this.BlogTitleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlogTitleTextBox.Location = new System.Drawing.Point(83, 38);
            this.BlogTitleTextBox.Name = "BlogTitleTextBox";
            this.BlogTitleTextBox.Size = new System.Drawing.Size(501, 25);
            this.BlogTitleTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "文章标题";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件路径";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 559);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "博客发布助手";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.BlogInfoGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox BlogInfoGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.TextBox BlogTitleTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox PublishConfigCheckedListBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ConfirmPublishButton;
        private System.Windows.Forms.LinkLabel HelpLinkLabel;
        private System.Windows.Forms.ToolStripMenuItem 查看编辑ToolStripMenuItem;
    }
}

