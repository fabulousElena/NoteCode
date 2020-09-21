using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BLL;

namespace RecordPixivPics
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenSourceFolder_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择源文件夹";
            fbd.SelectedPath = @"C:\Users\花纸\Downloads\pics";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TxtSourcePath.Text = fbd.SelectedPath;
            }
        }

        private void OpenSaveFolder_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择目标文件夹";
            fbd.SelectedPath = @"E:\PicRespository\R-18-Not";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TxtAimPath.Text = fbd.SelectedPath;
            }
        }

        private string[] picNames;//存放文件路径的数组
        /// <summary>
        /// 开始操作图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartRecord_Click_1(object sender, EventArgs e)
        {
            picNames = Directory.GetFiles(TxtSourcePath.Text);
            if (NullOrEmpty(TxtAimPath.Text) || NullOrEmpty(TxtSourcePath.Text) || picNames.Length == 0)
            {
                MessageBox.Show("请填入密码和选择文件夹！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] firstArray = picNames.Take(picNames.Length / 2).ToArray();
            string[] secondArray = picNames.Skip(picNames.Length / 2).ToArray();


            StartRecord.Enabled = false;
            richTextBox1.Text = "正在处理中....." + "\n";

            Thread th = new Thread(StartOperate);
            th.IsBackground = true;
            th.Start(firstArray);

            Thread th2 = new Thread(StartOperate2);
            th2.IsBackground = true;
            th2.Start(secondArray);

            picNames = null;
        }
        //双线程操作
        private void StartOperate2(object secondArray)
        {
            string[] secondArr = secondArray as string[];

            BLLOperatePic bop = new BLLOperatePic();
            //在数据库查询所有图片
            bop.BllSearchPic(secondArr);
            //剪切新增的图片 
            bop.CutPicAndInsertSql(TxtAimPath.Text + "\\");

            Console.WriteLine("\n" + "正在准备将新图片录入数据库......" + "\n");

            //把新增的图片名插入数据库
            bop.InsertIntoMysql();

            Console.WriteLine("\n" + "\n" + "操作成功！图片录入完成。");

            richTextBox1.Text = "图片批量操作完成。";
            StartRecord.Enabled = true;
        }

        private void StartOperate(object firstArray)
        {
            string[] firstArr = firstArray as string[];

            BLLOperatePic bop = new BLLOperatePic();
            //在数据库查询所有图片
            bop.BllSearchPic(firstArr);
            //剪切新增的图片 
            bop.CutPicAndInsertSql(TxtAimPath.Text + "\\");

            Console.WriteLine("\n" + "正在准备将新图片录入数据库......" + "\n");

            //把新增的图片名插入数据库
            bop.InsertIntoMysql();

            Console.WriteLine("\n" + "\n" + "操作成功！图片录入完成。");

            richTextBox1.Text = "图片批量操作完成。";
            StartRecord.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private bool NullOrEmpty(string thisString)
        {
            if (string.IsNullOrEmpty(thisString))
            {
                return true;
            }

            return false;
        }

        private void OpenConfig_Click_1(object sender, EventArgs e)
        {
            string appConfig = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName + ".config";
            Process.Start(appConfig);
        }
        /// <summary>
        /// 打开链接文件进行校验。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenTxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"C:\Users\花纸\Desktop";
            fd.Title = "请选择链接文件~";
            fd.Filter = "文本文件(*.txt)|*.txt";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fd.FileName;
            }
        }
        List<string> urlList = new List<string>();
        /// <summary>
        /// 校验按钮点击以后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UrlCheck_Click(object sender, EventArgs e)
        {

            //if (urlList.Count == 0)
            //{
            //    textBox2.Text = "请先选择要打开的文件。";
            //    return;
            //}


            StreamReader srReader = new StreamReader(textBox1.Text, Encoding.UTF8);
            while (!srReader.EndOfStream)
            {
                urlList.Add(srReader.ReadLine());
            }



            BtnGather.Enabled = false;
            UrlCheck.Enabled = false;
            textBox2.Text = "正在校验中，请稍候......";

            string[] urlArray = urlList.ToArray();

            string[] firstUrlArray = urlArray.Take(urlArray.Length / 2).ToArray();
            string[] secondUrlArray = urlArray.Skip(urlArray.Length / 2).ToArray();


            string[] firstUrlArray_1 = firstUrlArray.Take(firstUrlArray.Length / 2).ToArray();
            string[] firstUrlArray_2 = firstUrlArray.Skip(firstUrlArray.Length / 2).ToArray();


            string[] secondUrlArray_1 = secondUrlArray.Take(secondUrlArray.Length / 2).ToArray();
            string[] secondUrlArray_2 = secondUrlArray.Skip(secondUrlArray.Length / 2).ToArray();

            //四线程 操作
            Thread th = new Thread(StartToCheckUrl);
            th.IsBackground = true;
            th.Start(firstUrlArray_1);

            Thread th2 = new Thread(StartToCheckUrl);
            th2.IsBackground = true;
            th2.Start(firstUrlArray_2);

            Thread th3 = new Thread(StartToCheckUrl);
            th3.IsBackground = true;
            th3.Start(secondUrlArray_1);

            Thread th4 = new Thread(StartToCheckUrl);
            th4.IsBackground = true;
            th4.Start(secondUrlArray_2);

            urlList.Clear();

        }
        StringBuilder sb2 = new StringBuilder();
        private void StartToCheckUrl(object o)
        {
            string[] thisUrlArray = o as string[];

            BLLOperatePic bop = new BLLOperatePic();
          List<string> reList = bop.CheckPicUrl(thisUrlArray);

            foreach (string picUrl in reList)
            {
                sb2.Append(picUrl + "\n");
            }

            UrlCheck.Enabled = true;
            textBox2.Text = "校验完成。点击合并结果按钮获得校验结果~";
            BtnGather.Enabled = true;
        }

        private void BtnGather_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = sb2.ToString();
            sb2.Clear();
            BtnGather.Enabled = false;
        }
    }
}
