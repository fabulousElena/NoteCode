using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Documents;
using System.Windows.Forms;
using QRCodeCommon;

namespace QRCodeMaker
{
    public partial class MainForm : Form
    {
        private bool triggerIcon = false;
        private bool triggerDrag = false;
        private Bitmap qrBitmap = null;
        private bool triggerChecked = false;

        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMakeQr_Click(object sender, EventArgs e)
        {
            //如果选择开启图标
            if (radioButton2.Checked)
            {
                if (!triggerIcon)
                {
                    MessageBox.Show("未选择图标。", "出错了！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                qrBitmap = QRCoderHelper.QrMaker(richTextBox1.Text, trackBar1.Value, trackBar2.Value, label12.Text, trackBar3.Value, trackBar4.Value, radioButton4.Checked);
            }
            else//反之
            {
                if (string.IsNullOrEmpty(richTextBox1.Text))
                {
                    MessageBox.Show("未输入二维码内容。", "出错了！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                qrBitmap = QRCoderHelper.QrMaker(richTextBox1.Text, trackBar1.Value, trackBar2.Value, radioButton4.Checked);
            }

            pictureBox1.Image = qrBitmap;
            panel1.Visible = false;
            pictureBox1.Visible = true;
            triggerDrag = true;

            CheckQrCodeWorks();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = trackBar2.Value.ToString();
        }

        //允许管理员启动时拖入文件
        private FileDropHandler fileDrop;
        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            panel1.Visible = true;
            comboBox1.SelectedIndex = 0;
            fileDrop = new FileDropHandler(this); //初始化
        }

        /// <summary>
        /// 保存生成的二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (qrBitmap == null || triggerDrag == false)
            {
                MessageBox.Show("未生成二维码", "出错了！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //提示 正在保存错误的二维码
            if (!triggerChecked)
            {
                DialogResult drTip = MessageBox.Show("正在保存不可用的二维码。是否继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (drTip != DialogResult.OK)
                {
                    return;
                }
            }

            List<object> formatList = FormatFactory.GetSelectFormat(comboBox1.SelectedItem.ToString());

            FileDialog fd = new SaveFileDialog();
            fd.Title = "请选择要保存的位置";
            fd.AddExtension = false;
            fd.Filter = "所有文件|*.*";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string thisImgPath = fd.FileName + formatList[0];
                qrBitmap.Save(thisImgPath, (ImageFormat)formatList[1]);
                DialogResult dr = MessageBox.Show("保存成功!是否打开文件目录？", "提示", MessageBoxButtons.OKCancel
                       , MessageBoxIcon.Asterisk);
                if (dr == DialogResult.OK)
                {
                    Process pr1 = Process.Start("Explorer.exe", "/select," + thisImgPath);
                }
            }
            //清理所有元素
            formatList.Clear();
            BtnMakeQr.Text = "生成二维码";
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            qrBitmap.Dispose();
            richTextBox1.Text = "";
            pictureBox1.Visible = false;
            pictureBox1.Image = null;
            panel1.Visible = true;
            label12.Text = "请选择图标";
            trackBar1.Value = 15;
            trackBar2.Value = 10;
            trackBar3.Value = 15;
            trackBar4.Value = 4;
            radioButton4.Checked = true;
            comboBox1.SelectedIndex = 0;
            triggerIcon = false;
        }

        /// <summary>
        /// 设置为开启图标的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == false)
            {
                panel2.Visible = false;
                triggerDrag = false;
            }
            else
            {
                panel2.Visible = true;
                triggerDrag = false;
            }
        }

        /// <summary>
        /// 选择图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.Title = "请选择图标";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                label12.Text = fd.FileName;
                triggerIcon = true;
            }
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            label14.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            label16.Text = trackBar4.Value.ToString();
        }


        /// <summary>
        /// 拖入二维码的时候。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            var paths = e.Data.GetData(typeof(string[])) as string[];
            richTextBox1.Text = QRCoderHelper.QrDecoder(paths[0]);
            pictureBox1.Image = new Bitmap(paths[0]);
            qrBitmap = new Bitmap(paths[0]);
            panel1.Visible = false;
            pictureBox1.Visible = true;
            BtnMakeQr.Text = "重新生成";
            triggerDrag = true;
        }

        /// <summary>
        /// 当二维码内容框 字符 变动的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            label21.Text = "内容字符串长度=" + richTextBox1.Text.Length;
        }


        /// <summary>
        /// 测试二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            CheckQrCodeWorks();
        }

        /// <summary>
        /// 检测二维码是否可用
        /// </summary>
        private void CheckQrCodeWorks()
        {
            if (qrBitmap == null)
            {
                MessageBox.Show("未生成二维码", "出错了！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (QRCoderHelper.QrDecoder(qrBitmap) != "error")
            {
                MessageBox.Show("检测结果：该二维码可用~", "检测完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                triggerChecked = true;
                return;
            }
            else
            {
                MessageBox.Show("检测结果：该二维码不可用，可能是二维码内容超出限制。" + "\n" + "                建议提高\'容量级别\'~", "检测完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                triggerChecked = false;
                return;
            }
        }
    }
}
