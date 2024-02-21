using Microsoft.VisualBasic.Devices;
using NSM.COMMON;
using NSM.FORMS.CORE;
using System.Security.Cryptography;

namespace NSM.FORMS.Forms
{
    public partial class FriendControl : UserControl
    {
        public FriendControl(int FriendId)
        {
            InitializeComponent();
            this.FriendID = FriendId;

            //Request profile photo to server
            MessagePackage Message = new MessagePackage();
            Message.ClientId = FriendId;
            Message.MessageType = MessageType.Message_GetProfilePhoto;
            Message.Informations = new List<string>();

            Client.Send(Message);
            MessagePackage Received = Client.Listen();

            if(Received.MessageType==MessageType.Message_Confirmation)
            {

                byte[] imgBytes = Convert.FromBase64String(Received.Informations[0]);
                if(!File.Exists(this.FriendID+".jpg"))
                {
                    File.Create(this.FriendID + ".jpg").Close() ;
                }
                File.WriteAllBytes(this.FriendID + ".jpg", imgBytes);
                this.pbPhoto.ImageLocation = this.FriendID + ".jpg";
                this.pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else
            {
                this.pbPhoto.ImageLocation = "anonymAvatar.jpg";
                this.pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            //Request profile photo to server

        }

        public int FriendID;

        private void OpenChat()
        {
            try
            {
                MainForm parent = (MainForm)this.Parent.Parent.Parent;
                parent.LoadMessages(FriendID);
                parent.CurrentFriendId = FriendID;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FriendControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }

        private void FriendControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ActiveCaption;
        }

        private void lbName_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }

        private void lbName_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ActiveCaption;
        }

        private void pbPhoto_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }

        private void pbPhoto_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ActiveCaption;
        }

        private void lbName_DoubleClick(object sender, EventArgs e)
        {
            OpenChat();
        }

        private void pbPhoto_DoubleClick(object sender, EventArgs e)
        {
            OpenChat();
        }
    }
}
