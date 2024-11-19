using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsRadius.Model;

namespace WindowsFormsRadius
{
    public partial class SolFormA : Form
    {
        private MoveArgs MoveArg = new MoveArgs();
        public SolFormA()
        {
            InitializeComponent();
            //讓表單呈現圓角
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            Helper.CustomFormTitleHelper.CustomFormTitle(this, panel1, MoveArg);
        }

        // Native method to create a rounded rectangle region
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

    }
}
