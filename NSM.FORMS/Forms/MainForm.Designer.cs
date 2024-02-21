namespace NSM.FORMS.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            pnButtons = new Panel();
            btnSearchFriends = new Button();
            label1 = new Label();
            panel6 = new Panel();
            lbPhoto = new PictureBox();
            lbName = new Label();
            panel4 = new Panel();
            pnFriends = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            btnUpdateMessages = new Button();
            btnSendMessage = new Button();
            txtMessageContent = new TextBox();
            pnMessages = new Panel();
            panel1.SuspendLayout();
            pnButtons.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lbPhoto).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pnButtons);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(pnFriends);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(181, 450);
            panel1.TabIndex = 0;
            // 
            // pnButtons
            // 
            pnButtons.Controls.Add(btnSearchFriends);
            pnButtons.Controls.Add(label1);
            pnButtons.Dock = DockStyle.Top;
            pnButtons.Location = new Point(0, 217);
            pnButtons.Name = "pnButtons";
            pnButtons.Size = new Size(179, 67);
            pnButtons.TabIndex = 4;
            // 
            // btnSearchFriends
            // 
            btnSearchFriends.Cursor = Cursors.Hand;
            btnSearchFriends.FlatAppearance.BorderSize = 0;
            btnSearchFriends.FlatStyle = FlatStyle.Flat;
            btnSearchFriends.Image = (Image)resources.GetObject("btnSearchFriends.Image");
            btnSearchFriends.Location = new Point(148, 39);
            btnSearchFriends.Name = "btnSearchFriends";
            btnSearchFriends.Size = new Size(26, 23);
            btnSearchFriends.TabIndex = 5;
            btnSearchFriends.UseVisualStyleBackColor = true;
            btnSearchFriends.Click += btnSearchFriends_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 43);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 3;
            label1.Text = "Amigos:";
            // 
            // panel6
            // 
            panel6.Controls.Add(lbPhoto);
            panel6.Controls.Add(lbName);
            panel6.Controls.Add(panel4);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(179, 217);
            panel6.TabIndex = 6;
            // 
            // lbPhoto
            // 
            lbPhoto.BackColor = SystemColors.ControlLightLight;
            lbPhoto.BorderStyle = BorderStyle.FixedSingle;
            lbPhoto.Cursor = Cursors.Hand;
            lbPhoto.InitialImage = null;
            lbPhoto.Location = new Point(3, 3);
            lbPhoto.Name = "lbPhoto";
            lbPhoto.Size = new Size(171, 159);
            lbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            lbPhoto.TabIndex = 0;
            lbPhoto.TabStop = false;
            lbPhoto.Click += lbPhoto_Click;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(7, 165);
            lbName.Name = "lbName";
            lbName.Size = new Size(47, 15);
            lbName.TabIndex = 1;
            lbName.Text = "_name_";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaptionText;
            panel4.Location = new Point(4, 183);
            panel4.Name = "panel4";
            panel4.Size = new Size(170, 2);
            panel4.TabIndex = 2;
            // 
            // pnFriends
            // 
            pnFriends.Anchor = AnchorStyles.Top;
            pnFriends.AutoScroll = true;
            pnFriends.AutoSize = true;
            pnFriends.Location = new Point(0, 285);
            pnFriends.Name = "pnFriends";
            pnFriends.Size = new Size(179, 164);
            pnFriends.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(pnMessages);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(181, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(619, 450);
            panel3.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(txtMessageContent);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 389);
            panel2.Name = "panel2";
            panel2.Size = new Size(617, 59);
            panel2.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnUpdateMessages);
            panel5.Controls.Add(btnSendMessage);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(501, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(116, 36);
            panel5.TabIndex = 3;
            // 
            // btnUpdateMessages
            // 
            btnUpdateMessages.Cursor = Cursors.Hand;
            btnUpdateMessages.FlatAppearance.BorderSize = 0;
            btnUpdateMessages.FlatStyle = FlatStyle.Flat;
            btnUpdateMessages.Image = Properties.Resources.refresh;
            btnUpdateMessages.Location = new Point(53, 9);
            btnUpdateMessages.Name = "btnUpdateMessages";
            btnUpdateMessages.Size = new Size(27, 27);
            btnUpdateMessages.TabIndex = 2;
            btnUpdateMessages.UseVisualStyleBackColor = true;
            btnUpdateMessages.Click += btnUpdateMessages_Click;
            // 
            // btnSendMessage
            // 
            btnSendMessage.Cursor = Cursors.Hand;
            btnSendMessage.FlatAppearance.BorderSize = 0;
            btnSendMessage.FlatStyle = FlatStyle.Flat;
            btnSendMessage.Image = (Image)resources.GetObject("btnSendMessage.Image");
            btnSendMessage.Location = new Point(86, 9);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(27, 24);
            btnSendMessage.TabIndex = 1;
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // txtMessageContent
            // 
            txtMessageContent.Dock = DockStyle.Bottom;
            txtMessageContent.Location = new Point(0, 36);
            txtMessageContent.Name = "txtMessageContent";
            txtMessageContent.Size = new Size(617, 23);
            txtMessageContent.TabIndex = 0;
            // 
            // pnMessages
            // 
            pnMessages.AutoScroll = true;
            pnMessages.BorderStyle = BorderStyle.FixedSingle;
            pnMessages.Dock = DockStyle.Fill;
            pnMessages.Location = new Point(0, 0);
            pnMessages.Name = "pnMessages";
            pnMessages.Size = new Size(617, 448);
            pnMessages.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NSM";
            FormClosed += MainForm_FormClosed;
            Resize += MainForm_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnButtons.ResumeLayout(false);
            pnButtons.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lbPhoto).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label label1;
        private Panel panel4;
        private Button btnUpdateMessages;
        private Button btnSendMessage;
        private TextBox txtMessageContent;
        private Panel pnMessages;
        public Label lbName;
        public string LoginData;
        public string PasswordData;
        private Button btnSearchFriends;
        private Panel panel6;
        private PictureBox lbPhoto;
        public Panel pnFriends;
        private Panel pnButtons;
        private Panel panel2;
        private Panel panel5;
    }
}