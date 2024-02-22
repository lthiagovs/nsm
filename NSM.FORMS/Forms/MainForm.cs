using NSM.COMMON;
using NSM.FORMS.CORE;

namespace NSM.FORMS.Forms
{

    public partial class MainForm : Form
    {
        private Thread AccountFormThread;

        public int Id { get; set; }
        private int CurrentChatId { get; set; }
        public int CurrentFriendId { get; set; }
        private string Name { get; set; }

        private List<string> Notifications { get; set; }

        private byte[] Photo { get; set; } = File.ReadAllBytes("anonymAvatar.jpg");

        private List<string> Messages { get; set; }

        private int FriendListY = 0;

        //Reloads Friend List UI
        private void ReloadFriendList()
        {
            this.FriendListY = 0;
            foreach (FriendControl fc in pnFriends.Controls)
            {
                fc.Location = new Point(0, FriendListY);
                FriendListY += fc.Size.Height;
            }

        }

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
                foreach (FriendControl friend in pnFriends.Controls)
                {
                    if (friend.FriendID == FriendId)
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
                    if (Messages[i].Contains(this.Id + ""))
                    {
                        messageControl.pbPhoto.Image = this.lbPhoto.Image;
                        messageControl.lbName.Text = this.Name;

                        //Adjust Controls
                        messageControl.lbText.Location = new Point(3, 18);
                        messageControl.pbPhoto.Location = new Point(352, 3);
                        messageControl.lbName.Location = new Point(3, 3);
                        messageControl.lbText.TextAlign = ContentAlignment.TopRight;
                        messageControl.lbName.TextAlign = ContentAlignment.TopRight;
                        messagePosX = pnMessages.Size.Width - 450;
                    }
                    else if (friendPhoto != null)
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
                    messageControl.Location = new Point(messagePosX, messagePosY + 20);
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

        //Verifies if you already have a friend
        private bool HaveFriend(string name)
        {
            bool result = false;

            foreach (FriendControl fc in pnFriends.Controls)
            {
                if (fc.lbName.Text.Equals(name))
                {
                    result = true;
                    break;
                }
            }

            return result;

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
                    Message.Informations.Add(this.Id + "&" + Content);
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

        private void SendNotifications(int FriendID, string Content)
        {
            MessagePackage Message = new MessagePackage();
            Message.ClientId = FriendID;
            Message.Informations = new List<string>();
            Message.MessageType = MessageType.Message_SendNotification;
            Message.Informations.Add(Content);

            Client.Send(Message);

            MessagePackage Received = Client.Listen();

            if (Received.MessageType != MessageType.Message_Confirmation)
            {
                MessageBox.Show("Erro ao enviar notificação...");
            }


        }

        private void GetNotifications()
        {

            MessagePackage Message = new MessagePackage();
            Message.ClientId = this.Id;
            Message.Informations = new List<string>();
            Message.MessageType = MessageType.Message_GetNotification;

            Client.Send(Message);

            MessagePackage Received = Client.Listen();

            if (Received.MessageType == MessageType.Message_Confirmation)
            {

                this.Notifications.Clear();
                foreach (string notification in Received.Informations)
                {
                    this.Notifications.Add(notification);
                }

            }
            else
            {
                MessageBox.Show("Erro ao carregar notificações...");
            }

        }

        public MainForm(string LoginData, string PasswordData)
        {
            //Gets Login/PasswordData
            this.LoginData = LoginData;
            this.PasswordData = PasswordData;
            this.Notifications = new List<string>();

            InitializeComponent();
            using (MemoryStream ms = new MemoryStream(this.Photo))
            {
                Image image = Image.FromStream(ms);
                lbPhoto.Image = image;
            }
            this.Messages = new List<string>();
            this.CurrentChatId = -1;
            this.CurrentFriendId = -1;

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
                    this.Photo = imgBytes;
                }


            }

            //LoadAllFriends
            if (File.Exists(@"friendlist" + this.Name + ".bin"))
            {
                Stream friendList = File.Open(@"friendlist" + this.Name + ".bin", FileMode.Open);
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

                if (!SearchFriends.txtName.Text.Equals(this.Name))
                {

                    if (!HaveFriend(SearchFriends.txtName.Text))
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
                            if (!File.Exists(@"friendlist" + this.Name + ".bin"))
                            {
                                File.Create(@"friendlist" + this.Name + ".bin").Close();
                            }
                            Stream friendFile = File.Open(@"friendlist" + this.Name + ".bin", FileMode.Open);
                            BinaryWriter writer = new BinaryWriter(friendFile);

                            foreach (FriendControl fc in pnFriends.Controls)
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
                    else
                    {
                        MessageBox.Show("Este amigo já está na sua lista...");
                    }

                }
                else
                {
                    MessageBox.Show("Você não pode usar seu propio nome...");
                }

            }

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            SendMessage(this.CurrentChatId, this.txtMessageContent.Text);
            SendNotifications(this.CurrentFriendId, "Mensagem de " + this.Name);
            LoadMessages(this.CurrentFriendId);
        }

        private void btnUpdateMessages_Click(object sender, EventArgs e)
        {
            LoadMessages(this.CurrentFriendId);
        }

        private void lbPhoto_Click(object sender, EventArgs e)
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
                Message.Informations.Add(Convert.ToBase64String(PFPByte));
                Message.ClientId = this.Id;

                //Send and Await
                Client.Send(Message);
                MessagePackage Received = Client.Listen();

                if (Received.MessageType != MessageType.Message_Confirmation)
                {
                    MessageBox.Show("Erro ao atualizar foto...");
                }
                else
                {
                    UpdatePhotoAndName(this.Name, PFPByte);
                }

                if (!this.Name.Equals(UserProfile.txtName.Text))
                {
                    //Change user name...
                    Message = new MessagePackage();
                    Message.ClientId = this.Id;
                    Message.Informations = new List<string>();
                    Message.Informations.Add(UserProfile.txtName.Text);
                    Message.MessageType = MessageType.Message_ChangeUserName;

                    Client.Send(Message);

                    Received = Client.Listen();

                    if (Received.MessageType != MessageType.Message_Confirmation)
                    {
                        MessageBox.Show("Algum usuario ja possui este nome...");
                    }
                    else
                    {
                        this.Name = UserProfile.txtName.Text;
                        lbName.Text = this.Name;
                    }
                }

                //Update Data in Server
            }
            else if (response == DialogResult.Yes)
            {
                //Change user name...
                if (!this.Name.Equals(UserProfile.txtName.Text))
                {
                    MessagePackage Message = new MessagePackage();
                    Message.ClientId = this.Id;
                    Message.Informations = new List<string>();
                    Message.Informations.Add(UserProfile.txtName.Text);
                    Message.MessageType = MessageType.Message_ChangeUserName;

                    Client.Send(Message);

                    MessagePackage Received = Client.Listen();

                    if (Received.MessageType != MessageType.Message_Confirmation)
                    {
                        MessageBox.Show("Algum usuario ja possui este nome...");
                    }
                    else
                    {
                        this.Name = UserProfile.txtName.Text;
                        lbName.Text = this.Name;
                    }
                }

            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Save friends in a file
            if (!File.Exists(@"friendlist" + this.Name + ".bin"))
            {
                File.Create(@"friendlist" + this.Name + ".bin").Close();
            }
            Stream friendFile = File.Open(@"friendlist" + this.Name + ".bin", FileMode.Open);
            BinaryWriter writer = new BinaryWriter(friendFile);

            foreach (FriendControl fc in pnFriends.Controls)
            {
                writer.Write(fc.lbName.Text);
            }
            writer.Close();
            friendFile.Close();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (CurrentFriendId != -1)
            {
                LoadMessages(CurrentFriendId);
            }
        }

        private void OpenAccountForm()
        {
            Application.Run(new AccountForm());
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Client.ClientSocket.Close();
            AccountFormThread = new Thread(OpenAccountForm);
            AccountFormThread.SetApartmentState(ApartmentState.STA);
            AccountFormThread.Start();
        }

        private void menuSearch_Click(object sender, EventArgs e)
        {
            AllUserForm allUserForm = new AllUserForm();
            if (allUserForm.ShowDialog() == DialogResult.OK)
            {
                string UserName = allUserForm.cbUser.SelectedItem.ToString();
                if (!UserName.Equals(this.Name))
                {

                    if (!HaveFriend(UserName))
                    {
                        //Search for the friend
                        MessagePackage Message = new MessagePackage();
                        Message.MessageType = MessageType.Message_SearchUser;
                        Message.ClientId = this.Id;
                        Message.Informations = new List<string>();
                        Message.Informations.Add(UserName);
                        Client.Send(Message);

                        //Wait
                        MessagePackage Received = Client.Listen();

                        if (Received.MessageType == MessageType.Message_Confirmation)
                        {
                            //Add friend to interface
                            MessageBox.Show("Amigo: " + UserName + " encontrado!");
                            FriendControl Friend = new FriendControl(Convert.ToInt32(Received.Informations[0]));
                            Friend.Location = new Point(0, this.FriendListY);
                            FriendListY += Friend.Size.Height;
                            Friend.lbName.Text = UserName;
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
                            if (!File.Exists(@"friendlist"+this.Name+".bin"))
                            {
                                File.Create(@"friendlist" + this.Name + ".bin").Close();
                            }
                            Stream friendFile = File.Open(@"friendlist" + this.Name + ".bin", FileMode.Open);
                            BinaryWriter writer = new BinaryWriter(friendFile);

                            foreach (FriendControl fc in pnFriends.Controls)
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
                    else
                    {
                        MessageBox.Show("Este amigo já está na sua lista...");
                    }

                }
                else
                {
                    MessageBox.Show("Você não pode usar seu propio nome...");
                }
            }

        }

        private void menuRemove_Click(object sender, EventArgs e)
        {
            RemoveFriendForm removeFriendForm = new RemoveFriendForm();

            if (removeFriendForm.ShowDialog() == DialogResult.OK)
            {
                string FriendName = "";
                if (removeFriendForm.cbFriends.SelectedIndex != -1)
                {

                    FriendName = removeFriendForm.cbFriends.SelectedItem.ToString();

                    foreach (FriendControl fc in pnFriends.Controls)
                    {
                        if (fc.lbName.Text.Equals(FriendName))
                        {
                            pnFriends.Controls.Remove(fc);
                            MessageBox.Show("Amigo: " + FriendName + " removido.");
                            break;
                        }
                    }

                }

                pnMessages.Controls.Clear();
                ReloadFriendList();
                pnFriends.Update();
                this.CurrentChatId = -1;
                this.CurrentFriendId = -1;
                this.lbChatName.Text = "";

                File.Delete(@"friendlist" + this.Name + ".bin");
                //Save friends in a file
                File.Create(@"friendlist" + this.Name + ".bin").Close();
                Stream friendFile = File.Open(@"friendlist" + this.Name + ".bin", FileMode.Open);
                BinaryWriter writer = new BinaryWriter(friendFile);

                foreach (FriendControl fc in pnFriends.Controls)
                {
                    writer.Write(fc.lbName.Text);
                }
                writer.Close();
                friendFile.Close();


            }

        }

        private void txtMessageContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendMessage(this.CurrentChatId, this.txtMessageContent.Text);
                LoadMessages(this.CurrentFriendId);
            }
        }

        private void menuNotification_Click(object sender, EventArgs e)
        {
            NotificationForm notifications = new NotificationForm();
            GetNotifications();
            notifications.cbNotifications.DataSource = this.Notifications;
            notifications.ShowDialog();

        }


    }


}
