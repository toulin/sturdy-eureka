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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void popupContainerEdit1_KeyUp(object sender, KeyEventArgs e)
        {
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
    }
}
