using NSM.COMMON;
using NSM.FORMS.CORE;

namespace NSM.FORMS.Forms
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
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

            if(Message.MessageType == MessageType.Message_Confirmation)
            {
                MessageBox.Show("Logado com sucesso.");
                MainForm mainForm = new MainForm ();
                mainForm.Show();
            }
            else if(Message.MessageType == MessageType.Message_Negation)
            {
                MessageBox.Show("Usuario ou senha incorretos.");
            }
            else
            {
                MessageBox.Show("Erro interno.");
            }



        }
    }
}
