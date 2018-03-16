using System;
using System.Net;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Media;

namespace AuroraBingWallpaper
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        //Global可以下载全球版壁纸 https://global.bing.com/HPImageArchive.aspx?format=js&idx={0}&n={1}&mkt={2}
        //www可以仅下载中国版壁纸，无论设置区域在哪 https://www.bing.com/HPImageArchive.aspx?format=js&idx={0}&n={1}&mkt={2}

        //http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&mkt=zh-CN
        //format：接口返回格式，已知可选项xml,js
        //idx:日期表示0为当天，-1为明天，1为昨天，2为前天，依次类推，已知可选项-1 ~ 18
        //n:当idx=0时，n的范围时1-8，为8表示下载前7天的数据
        //mkt:地区编号(可选项)，不同地区会获得不同壁纸。已知可选项en-US, zh-CN, ja-JP, en-AU, de-DE, en-NZ, en-CA

        string str_Url = "http://www.bing.com/hpimagearchive.aspx?format=js";
        string str_Area = "";
        string str_DownloadPath = Application.StartupPath + "\\AuroraBingWallpapers\\";
        string strWebResponse = "";
        string str_LocalFile = "";
        List<string> L_Langcode = new List<string>();   //zh-cn
        List<string> L_LangArea = new List<string>();   //中国

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private void MainFrm_Load(object sender, EventArgs e)
        {
            //AboutMe ab = new AboutMe();
            //ab.ShowDialog();
            ReadLangcode();
            comboBox_Area.SelectedIndex = 0;
        }

        private void ReadLangcode()
        {
            FileStream fs = new FileStream(Application.StartupPath + "\\Langcode.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            string strCode = "";
            while ((strCode = sr.ReadLine()) != null)
            {
                if (strCode == "")
                    continue;

                string[] str_Arr = strCode.Split(',');
                L_Langcode.Add(str_Arr[0]);
                L_LangArea.Add(str_Arr[1]);
                comboBox_Area.Items.Add(str_Arr[1]);
            }
            sr.Close();
            fs.Close();
        }

        private void comboBox_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = comboBox_Area.Text;
            int n = L_LangArea.IndexOf(temp);
            str_Area = L_Langcode[n];
            
            this.Text = "Aurora 必应壁纸 - 开始下载......";
            try
             {
                string strURL = "https://global.bing.com/HPImageArchive.aspx?format=js&idx={0}&n={1}&mkt={2}";
                Download(strURL, 0, 1, str_Area, str_DownloadPath);
                this.Text = "Aurora 必应壁纸 - 已下载今天的Bing壁纸.";
            }
            catch
            {
                this.Text = "Aurora 必应壁纸 - 遇到一点小问题. 可能被伟大的祖国屏蔽了接口, 已自动切换到备用服务器, 仅可以下载中国区壁纸";
                string strURL = "https://www.bing.com/HPImageArchive.aspx?format=js&idx={0}&n={1}&mkt={2}";
                Download(strURL, 0, 1, str_Area, str_DownloadPath);
            }
        }

        private void button_8days_Click(object sender, EventArgs e)
        {
            this.Text = "Aurora 必应壁纸 - 开始下载......";
            try
            {
                string strURL = "https://global.bing.com/HPImageArchive.aspx?format=js&idx={0}&n={1}&mkt={2}";
                Download(strURL, 16, 8, str_Area, str_DownloadPath);
                this.Text = "Aurora 必应壁纸 - 已下载最近几天的Bing壁纸.";
                System.Diagnostics.Process.Start(str_DownloadPath);
            }
            catch
            {
                this.Text = "Aurora 必应壁纸 - 遇到一点小问题. 可能被伟大的祖国屏蔽了接口, 已自动切换到备用服务器, 仅可以下载中国区壁纸";
                string strURL = "https://www.bing.com/HPImageArchive.aspx?format=js&idx={0}&n={1}&mkt={2}";
                Download(strURL, 16, 8, str_Area, str_DownloadPath);
                System.Diagnostics.Process.Start(str_DownloadPath);
            }
        }

        private void Download(string strURL, int idx, int n, string area, string rootpath)
        {
            if (area == "")
                area = "zh-cn";
            str_Url = string.Format(strURL, idx, n, area);
            rootpath += area + "\\";
            if (!Directory.Exists(rootpath))
            {
                Directory.CreateDirectory(rootpath);
            }

            WebClient mywebclient = new WebClient();
            mywebclient.Encoding = Encoding.UTF8;
            strWebResponse = mywebclient.DownloadString(str_Url);
            if (strWebResponse == "null")
                return;
            BingClass bc = JsonConvert.DeserializeObject<BingClass>(strWebResponse);

            for (int i = 0; i < bc.images.Count; i++)
            {
                string str_picture_url = bc.images[i].url;
                if (!str_picture_url.StartsWith("http://"))
                    str_picture_url = "http://www.bing.com" + str_picture_url;
                byte[] Bytes = mywebclient.DownloadData(new Uri(str_picture_url));
                str_LocalFile = rootpath + Path.GetFileName(str_picture_url);

                using (MemoryStream ms = new MemoryStream(Bytes))
                {
                    Image outputImg = Image.FromStream(ms);
                    pictureBox_Wallpaper.Image = outputImg;
                    textBox_Copyright.Text = bc.images[i].copyright;
                    outputImg.Save(str_LocalFile);
                }
            }

            SoundPlayer sp = new SoundPlayer(Properties.Resources.download_completed);
            sp.Play();
        }

        private void button_SetWallpaper_Click(object sender, EventArgs e)
        {
            if(str_LocalFile != "")
                SystemParametersInfo(20, 0, str_LocalFile, 0x2);
        }

        private void pictureBox_Wallpaper_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}
