namespace RecordPixivPics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.OpenConfig = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.StartRecord = new System.Windows.Forms.Button();
            this.TxtAimPath = new System.Windows.Forms.TextBox();
            this.TxtSourcePath = new System.Windows.Forms.TextBox();
            this.OpenSaveFolder = new System.Windows.Forms.Button();
            this.OpenSourceFolder = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.OpenTxt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UrlCheck = new System.Windows.Forms.Button();
            this.BtnGather = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(574, 328);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.OpenConfig);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.StartRecord);
            this.tabPage1.Controls.Add(this.TxtAimPath);
            this.tabPage1.Controls.Add(this.TxtSourcePath);
            this.tabPage1.Controls.Add(this.OpenSaveFolder);
            this.tabPage1.Controls.Add(this.OpenSourceFolder);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(566, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "图片操作";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // OpenConfig
            // 
            this.OpenConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OpenConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OpenConfig.Location = new System.Drawing.Point(425, 237);
            this.OpenConfig.Name = "OpenConfig";
            this.OpenConfig.Size = new System.Drawing.Size(123, 33);
            this.OpenConfig.TabIndex = 13;
            this.OpenConfig.Text = "配置数据库";
            this.OpenConfig.UseVisualStyleBackColor = false;
            this.OpenConfig.Click += new System.EventHandler(this.OpenConfig_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 9.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Blue;
            this.richTextBox1.Location = new System.Drawing.Point(8, 132);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(551, 82);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "第一次使用请配置数据库。修改conStr这一行的value值为自己的数据库连接字符串，conStr2有介绍。";
            // 
            // StartRecord
            // 
            this.StartRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StartRecord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartRecord.Location = new System.Drawing.Point(8, 232);
            this.StartRecord.Name = "StartRecord";
            this.StartRecord.Size = new System.Drawing.Size(378, 42);
            this.StartRecord.TabIndex = 11;
            this.StartRecord.Text = "开始操作";
            this.StartRecord.UseVisualStyleBackColor = false;
            this.StartRecord.Click += new System.EventHandler(this.StartRecord_Click_1);
            // 
            // TxtAimPath
            // 
            this.TxtAimPath.Location = new System.Drawing.Point(137, 83);
            this.TxtAimPath.Name = "TxtAimPath";
            this.TxtAimPath.ReadOnly = true;
            this.TxtAimPath.Size = new System.Drawing.Size(422, 30);
            this.TxtAimPath.TabIndex = 10;
            this.TxtAimPath.Text = "E:\\PicRespository\\R-18-Not";
            // 
            // TxtSourcePath
            // 
            this.TxtSourcePath.Location = new System.Drawing.Point(137, 18);
            this.TxtSourcePath.Name = "TxtSourcePath";
            this.TxtSourcePath.ReadOnly = true;
            this.TxtSourcePath.Size = new System.Drawing.Size(422, 30);
            this.TxtSourcePath.TabIndex = 9;
            this.TxtSourcePath.Text = "C:\\Users\\花纸\\Downloads\\pics";
            // 
            // OpenSaveFolder
            // 
            this.OpenSaveFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OpenSaveFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OpenSaveFolder.Location = new System.Drawing.Point(8, 76);
            this.OpenSaveFolder.Name = "OpenSaveFolder";
            this.OpenSaveFolder.Size = new System.Drawing.Size(123, 42);
            this.OpenSaveFolder.TabIndex = 8;
            this.OpenSaveFolder.Text = "目标文件夹";
            this.OpenSaveFolder.UseVisualStyleBackColor = false;
            this.OpenSaveFolder.Click += new System.EventHandler(this.OpenSaveFolder_Click_1);
            // 
            // OpenSourceFolder
            // 
            this.OpenSourceFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OpenSourceFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OpenSourceFolder.Location = new System.Drawing.Point(8, 11);
            this.OpenSourceFolder.Name = "OpenSourceFolder";
            this.OpenSourceFolder.Size = new System.Drawing.Size(123, 42);
            this.OpenSourceFolder.TabIndex = 7;
            this.OpenSourceFolder.Text = "源文件夹";
            this.OpenSourceFolder.UseVisualStyleBackColor = false;
            this.OpenSourceFolder.Click += new System.EventHandler(this.OpenSourceFolder_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnGather);
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.OpenTxt);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.UrlCheck);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(566, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "链接校验";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(138, 148);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(422, 140);
            this.richTextBox2.TabIndex = 14;
            this.richTextBox2.Text = "待校验完成以后，点击合并结果，校验完成的链接或放在这里。";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(138, 87);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(422, 30);
            this.textBox2.TabIndex = 13;
            // 
            // OpenTxt
            // 
            this.OpenTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OpenTxt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OpenTxt.Location = new System.Drawing.Point(8, 13);
            this.OpenTxt.Name = "OpenTxt";
            this.OpenTxt.Size = new System.Drawing.Size(123, 42);
            this.OpenTxt.TabIndex = 12;
            this.OpenTxt.Text = "打开txt";
            this.OpenTxt.UseVisualStyleBackColor = false;
            this.OpenTxt.Click += new System.EventHandler(this.OpenTxt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(422, 30);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "C:\\Users\\花纸\\Desktop\\PicUrl.txt";
            // 
            // UrlCheck
            // 
            this.UrlCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UrlCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UrlCheck.Location = new System.Drawing.Point(9, 79);
            this.UrlCheck.Name = "UrlCheck";
            this.UrlCheck.Size = new System.Drawing.Size(123, 42);
            this.UrlCheck.TabIndex = 10;
            this.UrlCheck.Text = "开始校验";
            this.UrlCheck.UseVisualStyleBackColor = false;
            this.UrlCheck.Click += new System.EventHandler(this.UrlCheck_Click);
            // 
            // BtnGather
            // 
            this.BtnGather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnGather.Location = new System.Drawing.Point(10, 190);
            this.BtnGather.Name = "BtnGather";
            this.BtnGather.Size = new System.Drawing.Size(122, 42);
            this.BtnGather.TabIndex = 15;
            this.BtnGather.Text = "合并结果";
            this.BtnGather.UseVisualStyleBackColor = false;
            this.BtnGather.Click += new System.EventHandler(this.BtnGather_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(591, 341);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pixiv图片记录";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button OpenConfig;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button StartRecord;
        private System.Windows.Forms.TextBox TxtAimPath;
        private System.Windows.Forms.TextBox TxtSourcePath;
        private System.Windows.Forms.Button OpenSaveFolder;
        private System.Windows.Forms.Button OpenSourceFolder;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button OpenTxt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button UrlCheck;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button BtnGather;
    }
}

