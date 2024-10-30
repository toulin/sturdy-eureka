using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitTest
{
    public partial class Form1 : Form
    {
        internal readonly SynchronizationContext uiContext;

        private TestCall test1 = new TestCall();
        //private TestCall test2 = new TestCall();
        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                await test1.T1();
            });
        }
    }
}
