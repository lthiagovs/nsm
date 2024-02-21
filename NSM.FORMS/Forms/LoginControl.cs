using NSM.COMMON;
using NSM.FORMS.CORE;

namespace NSM.FORMS.Forms
{
    public partial class LoginControl : UserControl
    {

        Thread MainFormThread;

        public LoginControl()
        {
            InitializeComponent();
        }

        private void OpenMainForm(string LoginData, string PasswordData)
        {
            Application.Run(new MainForm(LoginData, PasswordData));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessagePackage messagePackage = new MessagePackage();
            messagePackage.ClientId = 0;
            messagePackage.Informations = new List<string>();
            messagePackage.Informations.Add(txtLogin.Text);
            messagePackage.Informations.Add(txtPassword.Text);
            messagePackage.MessageType = MessageType.Message_GetUser;
            Client.Send(messagePackage);

            MessagePackage Message = Client.Listen();

            if (Message.MessageType == MessageType.Message_Confirmation)
            {
                AccountForm Parent = (AccountForm)this.Parent.Parent;
                Parent.Close();

                MessageBox.Show("Logado com sucesso.");
                MainFormThread = new Thread(() => OpenMainForm(Message.Informations[2], Message.Informations[3]));
                MainFormThread.SetApartmentState(ApartmentState.STA);
                MainFormThread.Start();
            }
            else if (Message.MessageType == MessageType.Message_Negation)
            {
                MessageBox.Show("Usuario ou senha incorretos.");
            }
            else
            {
                MessageBox.Show("Erro interno.");
            }



        }

        private void LoginControl_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
