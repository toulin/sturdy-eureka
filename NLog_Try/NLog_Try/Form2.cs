using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NLog_Try
{
    public partial class Form2 : Form
    {
        private Interface1 f_Log;
        public Form2(Interface1 ILog)
        {
            InitializeComponent();
            f_Log = ILog;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            f_Log.log();
        }
    }
}
