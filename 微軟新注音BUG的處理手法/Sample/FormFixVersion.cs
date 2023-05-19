using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp28
{
    public partial class FormFixVersion : Form
    {
        public FormFixVersion()
        {
            InitializeComponent();

            for (int i = 1; i < 99; i++)
            {
                listBox1.Items.Add($"List-{i}");
            }
        }

        private void popupContainerEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            //在這裡將可辦識的 帶入tag中
            (sender as Control).Tag = e.KeyCode;
            
        }

        private void popupContainerEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((sender as Control).Tag is Keys)
            {
                if ((Keys)(sender as Control).Tag == Keys.ProcessKey)
                {
                    //選字狀態中，不處理對控項的操作
                    return;
                }
            }

            //處理對控項的操作
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
    } 
}
