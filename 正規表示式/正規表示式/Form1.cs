using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace 正規表示式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            patternLst.Items.Clear();
            patternLst.Items.Add(@"\[.+?\]");   //取[]括住的字串
            patternLst.Items.Add(@"[0-9]");     //任意單一數字
            patternLst.Items.Add(@"[0-9]+");    //任意數字
            patternLst.Items.Add(@"+[0-9]");    //任意數字
            patternLst.Items.Add(@"[0-9]{3}");  //3組連續數字
            patternLst.Items.Add(@"[^0-9]");        //不含數字的任意字元
            patternLst.Items.Add(@"[^0-9]{3}");     //不含數字的3個連續字元
            patternLst.Items.Add(@"{cmoney.+?}");
            //截取文章中的網址
            patternLst.Items.Add(@"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)");
            patternLst.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string[] ary = Regex.Split("[wty],tyeh[67hj],rffv,[7]", @"[\]]");
            string pattern = patternLst.Items[patternLst.SelectedIndex].ToString();
            if (rdoIsMatch.Checked)
            {
                tOutput.Text = Regex.IsMatch(tInput.Text, pattern).ToString();
            }
            else
            {
                List<string> matchStr = new List<string>();
                foreach (Match m in Regex.Matches(tInput.Text, pattern))
                {
                    matchStr.Add(m.Value);
                }
                tOutput.Text = string.Join("\r\n", matchStr);
            }
        }
        #region TabPage2
        private void bTestR_Click(object sender, EventArgs e)
        {
            string pattern = tPattern.Text;
            List<string> matchStr = new List<string>();
            
            foreach (Match m in Regex.Matches(tInput2.Text, pattern))
            {
                matchStr.Add(m.Value);
            }
            tOutput2.Text = string.Join("\r\n", matchStr);
        }
        private void bMatch_Click(object sender, EventArgs e)
        {
            string pattern = tPattern.Text;
            tOutput2.Text = Regex.Match(tInput2.Text, pattern,RegexOptions.CultureInvariant ).Value;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string pattern = tPattern.Text;
            tOutput2.Text = Regex.IsMatch(tInput2.Text, pattern).ToString();
        }
        #endregion
    }
}
