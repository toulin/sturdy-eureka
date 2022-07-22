using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnvironmentPj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach(System.Collections.DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                list.Add(string.Format("{0} => {1}", item.Key, item.Value));
            }
            textBox1.Text = string.Join(Environment.NewLine, list);
            textBox1.Text += Environment.NewLine + $"解析度={PrimaryMonitorSize()}";
            textBox1.Text += Environment.NewLine + $"OS={OS()}";
            textBox1.Text += Environment.NewLine + $"DPI={DPI()}";
        }

        /// <summary>
        /// 解析度
        /// </summary>
        /// <returns></returns>
        private string PrimaryMonitorSize()
        {
            return $"{SystemInformation.PrimaryMonitorSize.Width}X{SystemInformation.PrimaryMonitorSize.Height}";
        }

        //private string GetDPI()
        //{
        //    //DPI 大小百分比
        //    //96  100 %
        //    //120 125 %
        //    //144 150 %
        //}

        private string OS()
        {
            //private const string Windows2000 = "5.0";
            //private const string WindowsXP = "5.1";
            //private const string Windows2003 = "5.2";
            //private const string Windows2008 = "6.0";
            //private const string Windows7 = "6.1";
            //private const string Windows8OrWindows81 = "6.2";
            //private const string Windows10 = "10.0";

            var version = System.Environment.OSVersion.Version;
            return $"{version.Major}.{version.Minor}";
        }

        /// <summary>
        /// 取得系統DPI
        /// </summary>
        /// <returns></returns>
        private float DPI()
        {
            Graphics graphics = this.CreateGraphics();
            return graphics.DpiX;
        }
    }
}
