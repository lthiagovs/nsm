using NSM.COMMON;
using NSM.FORMS.CORE;

namespace NSM.FORMS.Forms
{
    public partial class RegisterControl : UserControl
    {
        public RegisterControl()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            MessagePackage MessagePackage = new MessagePackage();
            MessagePackage.MessageType = MessageType.Message_CreateUser;
            MessagePackage.ClientId = 0;
            MessagePackage.Informations = new List<string>();
            MessagePackage.Informations.Add(txtName.Text);
            MessagePackage.Informations.Add(txtPassword.Text);
            MessagePackage.Informations.Add(txtLogin.Text);
            MessagePackage.Informations.Add("");

            Client.Send(MessagePackage);

            MessagePackage Message = Client.Listen();

            //Interpretando servidor
            #region
            if (Message.MessageType == MessageType.Message_Confirmation)
            {
                MessageBox.Show("Conta criada com sucesso!");
            }
            else if(Message.MessageType == MessageType.Message_Negation)
            {
                MessageBox.Show("Uma conta com estas credenciais já existe.");
            }
            else
            {
                MessageBox.Show("Erro interno.");
            }
            #endregion

        }
    }
}
