using NSM.COMMON;
using NSM.FORMS.CORE;

namespace NSM.FORMS.Forms
{

    public partial class MainForm : Form
    {

        private int Id { get; set; }
        private string Name { get; set; }

        private string Photo { get; set; }

        private int FriendListY = 0;

        public void LoadMessages(int FriendId)
        {

            MessageBox.Show("OK LETSSSSSSSSSSSSS GO");

        }

        public MainForm(string LoginData, string PasswordData)
        {
            //Gets Login/PasswordData
            this.LoginData = LoginData;
            this.PasswordData = PasswordData;

            InitializeComponent();

            //Ask to server all informations
            MessagePackage Message = new MessagePackage();
            Message.MessageType = MessageType.Message_GetUser;
            Message.ClientId = 0;
            Message.Informations = new List<string>();
            Message.Informations.Add(LoginData);
            Message.Informations.Add(PasswordData);
            Client.Send(Message);

            //Wait
            MessagePackage Received = Client.Listen();

            if (Received.MessageType == MessageType.Message_Confirmation)
            {

                this.Id = Convert.ToInt32(Received.Informations[0]);
                this.Name = Received.Informations[1];
                this.Photo = Received.Informations[4];
                this.lbName.Text = this.Name;

            }
            else
            {
                MessageBox.Show("Erro interno.");
            }

            //Ready to go


        }

        private void btnSearchFriends_Click(object sender, EventArgs e)
        {

            FriendsForm SearchFriends = new FriendsForm();
            SearchFriends.ShowDialog();
            if(SearchFriends.DialogResult==DialogResult.OK)
            {
                //Search for the friend
                MessagePackage Message = new MessagePackage();
                Message.MessageType = MessageType.Message_SearchUser;
                Message.ClientId = this.Id;
                Message.Informations = new List<string>();
                Message.Informations.Add(SearchFriends.txtName.Text);
                Client.Send(Message);

                //Wait
                MessagePackage Received = Client.Listen();

                if(Received.MessageType==MessageType.Message_Confirmation)
                {
                    //Add friend to interface
                    MessageBox.Show("Amigo: " + SearchFriends.txtName.Text + " encontrado!");
                    FriendControl Friend = new FriendControl(Convert.ToInt32(Received.Informations[0]));
                    Friend.pbPhoto.ImageLocation = "";
                    Friend.Location = new Point(0, this.FriendListY);
                    FriendListY += Friend.Size.Height;
                    Friend.lbName.Text = SearchFriends.txtName.Text;
                    pnFriends.Controls.Add(Friend);

                    //Send Chat Request
                    MessagePackage ChatMessage = new MessagePackage();
                    ChatMessage.MessageType = MessageType.Message_CreateFriendChat;
                    ChatMessage.ClientId = this.Id;
                    ChatMessage.Informations = new List<string>();
                    ChatMessage.Informations.Add(Received.Informations[0]);
                    Client.Send(ChatMessage);
                }
                else
                {
                    MessageBox.Show("Amigo não encontrado...");
                }


            }

        }
    }
}
