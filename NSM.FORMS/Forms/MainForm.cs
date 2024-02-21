﻿using NSM.COMMON;
using NSM.FORMS.CORE;

namespace NSM.FORMS.Forms
{

    public partial class MainForm : Form
    {

        private int Id { get; set; }
        public int CurrentChatId { get; set; }
        private string Name { get; set; }

        private string Photo { get; set; }

        private List<string> Messages { get; set; }

        private int FriendListY = 0;

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

                //+70
                int messagePosY = 0;
                pnMessages.Controls.Clear();

                this.CurrentChatId = Convert.ToInt32(Received.Informations[0]);

                for (int i = 1; i < Messages.Count; i++)
                {
                    MessageControl messageControl = new MessageControl();
                    messageControl.lbText.Text = Messages[i];
                    messageControl.Location = new Point(0, messagePosY);
                    messagePosY += 70;
                    messageControl.pbPhoto.ImageLocation = "";
                    pnMessages.Controls.Add(messageControl);
                }

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
                    Message.Informations.Add(Content);
                    Client.Send(Message);

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

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            SendMessage(this.CurrentChatId, this.txtMessageContent.Text);
            LoadMessages(this.CurrentChatId);
        }

        private void btnUpdateMessages_Click(object sender, EventArgs e)
        {
            LoadMessages(this.CurrentChatId);
        }
    }
}
