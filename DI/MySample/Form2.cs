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
    public partial class Form2 : Form
    {
        private readonly IApiProvider ApiProvider;
        private readonly IPersonalAction PersonalAction;    
        private readonly double CreateSeconds;

        public Form2(IApiProvider provider,IPersonalAction personalAction)
        {
            InitializeComponent();
            ApiProvider = provider;
            PersonalAction = personalAction;
            CreateSeconds = Program.Watch.Elapsed.TotalSeconds;
        }

        public void Show(string id)
        {
            var product = ApiProvider.GetAPI(id);
            var info = PersonalAction.Information(id);
            textBox1.Text += $"{product},info={info}, from2'sHashCode={this.GetHashCode()} [{CreateSeconds}] {Environment.NewLine}";
            //Bind your controls etc
            this.Show();
        }

    }
}
