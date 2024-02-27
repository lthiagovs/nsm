using NSM.FORMS.CORE;

namespace NSM.FORMS.Forms
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {

            Client.Start();

            InitializeComponent();

            LoginControl loginControl = new LoginControl();
            pnMain.Controls.Clear();
            pnMain.Controls.Add(loginControl);

        }
        private void menuRegister_Click(object sender, EventArgs e)
        {
            RegisterControl registerControl = new RegisterControl();
            pnMain.Controls.Clear();
            pnMain.Controls.Add(registerControl);

        }

        private void menuLogin_Click(object sender, EventArgs e)
        {
            LoginControl loginControl = new LoginControl();
            pnMain.Controls.Clear();
            pnMain.Controls.Add(loginControl);
        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ptbProfilePicture_Click(object sender, EventArgs e)
        {

        }

        private void AccountForm_Load(object sender, EventArgs e)
        {

        }

        private void AccountForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
