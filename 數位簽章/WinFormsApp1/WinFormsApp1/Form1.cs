namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JwtSign jwtSign = new JwtSign();
            jwtSign.AccessTokenMapScopes = new Dictionary<string, string[]>();

            var token = jwtSign.SignJwt();
            var response = jwtSign.ValidateJwt(token);
            var resource1 = jwtSign.AccessResource1(response.AccessToken);
            var resource2 = jwtSign.AccessResource2(response.AccessToken);

        }
    }
}