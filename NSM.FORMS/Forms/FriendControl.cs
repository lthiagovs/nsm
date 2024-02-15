namespace NSM.FORMS.Forms
{
    public partial class FriendControl : UserControl
    {
        public FriendControl(int FriendId)
        {
            InitializeComponent();
            this.FriendID = FriendId;
        }

        private int FriendID;

        private void OpenChat()
        {
            try
            {
                MainForm parent = (MainForm)this.Parent.Parent.Parent;
                parent.LoadMessages(FriendID);

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
