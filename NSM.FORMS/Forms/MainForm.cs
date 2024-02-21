using NSM.COMMON;
using NSM.FORMS.CORE;

namespace NSM.FORMS.Forms
{

    public partial class MainForm : Form
    {

        private int Id { get; set; }
        private int CurrentChatId { get; set; }
        public int CurrentFriendId { get; set; }
        private string Name { get; set; }

        private byte[] Photo { get; set; } = File.ReadAllBytes("anonymAvatar.jpg");

        private List<string> Messages { get; set; }

        private int FriendListY = 0;

        //Load all messages from a friend chat

        public void UpdatePhotoAndName(string name, byte[] imageBytes)
        {
            this.Name = name;
            this.Photo = imageBytes;
            lbName.Text = this.Name;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);
                lbPhoto.Image = image;
            }
        }

        //Load all messages from a friend chat
        public void LoadMessages(int FriendId)
        {
            //Preparing Request
            MessagePackage Message = new MessagePackage();
            Message.ClientId = Id;
            Message.MessageType = MessageType.Message_GetFriendChatMessages;
            Message.Informations = new List<string>();
            Message.Informations.Add(Id + "");
            Message.Informations.Add(FriendId + "");
            Client.Send(Message);

            //Wait
            MessagePackage Received = Client.Listen();

            //Loading Chat Messages
            if (Received.MessageType == MessageType.Message_Confirmation)
            {

                Messages = Received.Informations;
                Image? friendPhoto = null;
                string friendName = "";

                //Get friend image
                foreach(FriendControl friend in pnFriends.Controls)
                {
                    if(friend.FriendID==FriendId)
                    {
                        friendPhoto = friend.pbPhoto.Image;
                        friendName = friend.lbName.Text;
                    }
                }
                //Get friend image

                //+70
                int messagePosY = 0;
                int messagePosX = 0;
                pnMessages.Controls.Clear();
                CurrentChatId = Convert.ToInt32(Received.Informations[0]);
                for (int i = 1; i < Messages.Count; i++)
                {
                    MessageControl messageControl = new MessageControl();

                    //Draw Photos and Name
                    if (Messages[i].Contains(this.Id+""))
                    {
                        messageControl.pbPhoto.Image = this.lbPhoto.Image;
                        messageControl.lbName.Text = this.Name;

                        //Adjust Controls
                        messageControl.lbText.Location = new Point(3, 18);
                        messageControl.pbPhoto.Location = new Point(352, 3);
                        messageControl.lbName.Location = new Point(280, 3);
                        messageControl.lbText.TextAlign = ContentAlignment.TopRight;
                        messagePosX = 153;
                    }
                    else if(friendPhoto!=null)
                    {
                        messageControl.pbPhoto.Image = friendPhoto;
                        messageControl.lbName.Text = friendName;

                    }
                    messageControl.pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    //Get true information from message
                    int deleteI = Messages[i].IndexOf('&');
                    if (i >= 0) Messages[i] = Messages[i].Substring(deleteI + 1);
                    //Draw Photos and Name

                    messageControl.lbText.Text = Messages[i];
                    messageControl.Location = new Point(messagePosX, messagePosY+20);
                    messagePosX = 0;
                    messagePosY += 70;
                    pnMessages.Controls.Add(messageControl);
                }

                //Scroll the bar
                pnMessages.VerticalScroll.Value = pnMessages.VerticalScroll.Maximum;
                pnMessages.PerformLayout();
                this.txtMessageContent.Text = "";

            }
            else
            {
                MessageBox.Show("Falha ao recuperar as mensagens...");
            }

            //



        }

        //Send a message to the current chat
        private void SendMessage(int ChatId, string Content)
        {
            if (ChatId != -1)
            {
                if (!this.txtMessageContent.Text.Equals(""))
                {

                    MessagePackage Message = new MessagePackage();
                    Message.MessageType = MessageType.Message_SendMessage;
                    Message.ClientId = this.Id;
                    Message.Informations = new List<string>();
                    Message.Informations.Add(ChatId + "");
                    Message.Informations.Add(this.Id+"&"+Content);
                    Client.Send(Message);

                    MessagePackage Received = Client.Listen();
                    if (Received.MessageType != MessageType.Message_Confirmation)
                    {
                        MessageBox.Show("Falha ao enviar mensagem");

                    }

                }

            }
            else
            {
                MessageBox.Show("Nenhum chat carregado...");
            }

        }

        public MainForm(string LoginData, string PasswordData)
        {
            //Gets Login/PasswordData
            this.LoginData = LoginData;
            this.PasswordData = PasswordData;

            InitializeComponent();
            using (MemoryStream ms = new MemoryStream(this.Photo))
            {
                Image image = Image.FromStream(ms);
                lbPhoto.Image = image;
            }
            this.Messages = new List<string>();
            this.CurrentChatId = -1;

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
                // this.Photo = Received.Informations[4];
                this.lbName.Text = this.Name;

            }
            else
            {
                MessageBox.Show("Erro interno.");
            }

            //Ready to go

            //Get Profile Image
            Message = new MessagePackage();
            Message.ClientId = this.Id;
            Message.MessageType = MessageType.Message_GetProfilePhoto;
            Message.Informations = new List<string>();
            Client.Send(Message);

            Received = Client.Listen();

            if (Received.MessageType == MessageType.Message_Confirmation)
            {

                byte[] imgBytes = Convert.FromBase64String(Received.Informations[0]);
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    Image image = Image.FromStream(ms);
                    this.lbPhoto.Image = image;
                }


            }

            //LoadAllFriends
            if (File.Exists("friendlist.bin"))
            {
                Stream friendList = File.Open("friendlist.bin", FileMode.Open);
                BinaryReader reader = new BinaryReader(friendList);
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {

                    string friendName = reader.ReadString();

                    //Search for the friend
                    Message = new MessagePackage();
                    Message.MessageType = MessageType.Message_SearchUser;
                    Message.ClientId = this.Id;
                    Message.Informations = new List<string>();
                    Message.Informations.Add(friendName);
                    Client.Send(Message);

                    //Wait
                    Received = Client.Listen();

                    if (Received.MessageType == MessageType.Message_Confirmation)
                    {
                        //Add friend to interface
                        FriendControl Friend = new FriendControl(Convert.ToInt32(Received.Informations[0]));
                        Friend.Location = new Point(0, this.FriendListY);
                        FriendListY += Friend.Size.Height;
                        Friend.lbName.Text = friendName;
                        pnFriends.Controls.Add(Friend);

                    }

                }
                

                reader.Close();
                friendList.Close();

            }

        }

        private void btnSearchFriends_Click(object sender, EventArgs e)
        {

            FriendsForm SearchFriends = new FriendsForm();
            SearchFriends.ShowDialog();
            if (SearchFriends.DialogResult == DialogResult.OK)
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

                if (Received.MessageType == MessageType.Message_Confirmation)
                {
                    //Add friend to interface
                    MessageBox.Show("Amigo: " + SearchFriends.txtName.Text + " encontrado!");
                    FriendControl Friend = new FriendControl(Convert.ToInt32(Received.Informations[0]));
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
                    Received = Client.Listen();
                    if (Received.MessageType != MessageType.Message_Confirmation)
                    {
                        MessageBox.Show("Erro interno ao criar chat...");
                    }
                    //Save friends in a file
                    if(!File.Exists("friendlist.bin"))
                    {
                        File.Create("friendlist.bin").Close();
                    }
                    Stream friendFile = File.Open("friendlist.bin", FileMode.Open);
                    BinaryWriter writer = new BinaryWriter(friendFile);

                    foreach(FriendControl fc in pnFriends.Controls)
                    {
                        writer.Write(fc.lbName.Text);
                    }
                    writer.Close();
                    friendFile.Close();


                }
                else
                {
                    MessageBox.Show("Amigo não encontrado...");
                }

            }

        }
  
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            SendMessage(this.CurrentChatId, this.txtMessageContent.Text);
            LoadMessages(this.CurrentFriendId);
        }

        private void btnUpdateMessages_Click(object sender, EventArgs e)
        {
            LoadMessages(this.CurrentFriendId);
        }

        private void lbPhoto_Click(object sender, EventArgs e)
        {

        }

        private void lbPhoto_Click_1(object sender, EventArgs e)
        {
            var UserProfile = new UserProfile(this.Name, this.Photo);
            var response = UserProfile.ShowDialog();
            if (response == DialogResult.OK)
            {
                byte[] PFPByte = File.ReadAllBytes(UserProfile.caminhoDaImagem);

                //Update Data in Server
                MessagePackage Message = new MessagePackage();
                Message.MessageType = MessageType.Message_ChangeProfilePhoto;
                Message.Informations = new List<string>();
                //Enconding image bytes in to string
                Message.Informations.Add(Convert.ToBase64String(PFPByte)) ;
                Message.ClientId = this.Id;

                //Send and Await
                Client.Send(Message);
                MessagePackage Received = Client.Listen();

                if(Received.MessageType != MessageType.Message_Confirmation)
                {
                    MessageBox.Show("Erro ao atualizar dados no servidor...");
                }
                //Update Data in Server

                UpdatePhotoAndName(UserProfile.txtName.Text, PFPByte);
            }
            else if (response == DialogResult.Yes)
            {
                this.Name = UserProfile.txtName.Text;
                lbName.Text = this.Name;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void lbName_Click(object sender, EventArgs e)
        {

        }
    }
    

}
