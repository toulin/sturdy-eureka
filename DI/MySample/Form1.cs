using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySample
{ 
    /// <summary>
    /// 本示範為了展示多次開啟同一個實例視窗的情境，若手動關閉視窗，則會導致下次開啟視窗時，無法正常顯示
    /// 實際應用時，應該要在視窗關閉時，將實例移除，或是禁止手動關閉視窗(僅能透過程式碼關閉，手動僅可隱藏該視窗)
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly IApiProvider ApiProvider;
        private readonly double CreateSeconds;

        public Form1(IApiProvider provider)
        {
            InitializeComponent();
            ApiProvider = provider;
            CreateSeconds = Program.Watch.Elapsed.TotalSeconds;
        }

        public void Show(string id)
        {
            var product = ApiProvider.GetAPI(id);

            textBox1.Text += $"{product}, from1'sHashCode={this.GetHashCode()} [{CreateSeconds}] {Environment.NewLine}";
            //Bind your controls etc
            this.Show();
        }
    }
}
