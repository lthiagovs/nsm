using NSM.COMMON;
using NSM.FORMS.CORE;
using System.Drawing;
using System.Text.RegularExpressions;

namespace NSM.FORMS.Forms
{
    public partial class RegisterControl : UserControl
    {
        public bool ValidarRegistro(string login, string senha, string senha2, string nome)
        {
            if (login.Length < 3) { MessageBox.Show("O nome de usuário deve ter pelo menos 3 caracteres", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            if (!Regex.IsMatch(login, "^[a-zA-Z0-9_.]+$")) { MessageBox.Show("O nome de usuário deve conter apenas letras, números, '.', ou '_'.",
                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            if (senha.Length < 8 || senha2.Length < 8 || !Regex.IsMatch(senha, @"^(?=.*[a-zA-Z])(?=.*\d).+$"))
            {
                MessageBox.Show("A senha deve ter pelo menos 8 caracteres e conter pelo menos uma letra e um número.", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Information); return false;
            }
            if (nome.Length <= 5)
            {
                MessageBox.Show("O nome de usuario deve possuir mais de 5 caracteres.", "Erro");
                return false;
            }


            return true;
        }
        public RegisterControl()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidarRegistro(txtLogin.Text, txtPassword.Text, txtPasswordRepeat.Text,txtName.Text))
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
                else if (Message.MessageType == MessageType.Message_Negation)
                {
                    MessageBox.Show("Uma conta com este usuário já existe.");
                }
                else
                {
                    MessageBox.Show("Erro interno.");
                }
                #endregion
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
