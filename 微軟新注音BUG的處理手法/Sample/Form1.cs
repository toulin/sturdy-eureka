using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 可用新、舊注音 在輸入框進行輸入與選字行為，可以看出差異
//在KeyUp事件處理，原本預期是要移動下拉選單行為， 在使用舊注音(或其他輸入法)，在選字時是正常選字，不會影響下拉選單
//但在 新注音，則會因為 傳送 KeyDown而無法判定"它正在選字"，而造成異常。
//注：新注音在KeyUp事件中，其他參數也未見"可辦識選字狀態"的屬性。

namespace WindowsFormsApp28
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void popupContainerEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.KeyCode);
            switch (e.KeyCode)
            {
                case Keys.Down: 

                    if (!popupContainerEdit1.IsPopupOpen)
                    {
                        popupContainerEdit1.ShowPopup();
                    }
                    ListBoxDown();
                    break;
            }
        }

        private void ListBoxDown()
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count)
            {
                listBox1.SelectedIndex += 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 99; i++)
            {
                listBox1.Items.Add($"List-{i}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormFixVersion formFixVersion = new FormFixVersion();
            formFixVersion.Show();
            this.Hide();
        }
    }
}
