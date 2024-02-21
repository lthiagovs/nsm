using NSM.COMMON;
using NSM.FORMS.CORE;

namespace NSM.FORMS.Forms
{
    public partial class AllUserForm : Form
    {

        List<string> userNames = new List<string>();

        public AllUserForm()
        {
            InitializeComponent();

            MessagePackage Message = new MessagePackage();
            Message.MessageType = MessageType.Message_GetAllUserNames;
            Message.ClientId = 0;
            Message.Informations = new List<string>();

            Client.Send(Message);

            MessagePackage Received = Client.Listen();

            if(Received.MessageType == MessageType.Message_Confirmation) 
            {
                userNames = Received.Informations;
            }
            else
            {
                MessageBox.Show("Erro ao receber nomes de usuarios...");
            }

            cbUser.DataSource = userNames;

        }
    }
}
