using System.Text;

namespace MyFirstWinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TEST");

            int count = 100;
            string[] guids = new string[count];
            for (int i = 0; i < count; i++)
            {
                guids[i] = Guid.NewGuid().ToString();
            }
            textBox1.Text = string.Join(",", guids);
        }
    }
}