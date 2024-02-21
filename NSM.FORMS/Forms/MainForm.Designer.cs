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
            panel6 = new Panel();
            lbPhoto = new PictureBox();
            btnSearchFriends = new Button();
            lbName = new Label();
            panel4 = new Panel();
            label1 = new Label();
            pnFriends = new Panel();
            panel3 = new Panel();
            pnMessages = new Panel();
            btnUpdateMessages = new Button();
            btnSendMessage = new Button();
            txtMessageContent = new TextBox();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lbPhoto).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(pnFriends);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(181, 450);
            panel1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(lbPhoto);
            panel6.Controls.Add(btnSearchFriends);
            panel6.Controls.Add(lbName);
            panel6.Controls.Add(panel4);
            panel6.Controls.Add(label1);
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
            // btnSearchFriends
            // 
            btnSearchFriends.Cursor = Cursors.Hand;
            btnSearchFriends.FlatAppearance.BorderSize = 0;
            btnSearchFriends.FlatStyle = FlatStyle.Flat;
            btnSearchFriends.Image = (Image)resources.GetObject("btnSearchFriends.Image");
            btnSearchFriends.Location = new Point(148, 191);
            btnSearchFriends.Name = "btnSearchFriends";
            btnSearchFriends.Size = new Size(26, 23);
            btnSearchFriends.TabIndex = 5;
            btnSearchFriends.UseVisualStyleBackColor = true;
            btnSearchFriends.Click += btnSearchFriends_Click;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 195);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 3;
            label1.Text = "Amigos:";
            // 
            // pnFriends
            // 
            pnFriends.AutoScroll = true;
            pnFriends.Dock = DockStyle.Bottom;
            pnFriends.Location = new Point(0, 223);
            pnFriends.Name = "pnFriends";
            pnFriends.Size = new Size(179, 225);
            pnFriends.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(pnMessages);
            panel3.Controls.Add(btnUpdateMessages);
            panel3.Controls.Add(btnSendMessage);
            panel3.Controls.Add(txtMessageContent);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(181, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(619, 450);
            panel3.TabIndex = 2;
            // 
            // pnMessages
            // 
            pnMessages.AutoScroll = true;
            pnMessages.BorderStyle = BorderStyle.FixedSingle;
            pnMessages.Location = new Point(5, 11);
            pnMessages.Name = "pnMessages";
            pnMessages.Size = new Size(588, 372);
            pnMessages.TabIndex = 3;
            // 
            // btnUpdateMessages
            // 
            btnUpdateMessages.Cursor = Cursors.Hand;
            btnUpdateMessages.FlatAppearance.BorderSize = 0;
            btnUpdateMessages.FlatStyle = FlatStyle.Flat;
            btnUpdateMessages.Image = Properties.Resources.refresh;
            btnUpdateMessages.Location = new Point(518, 389);
            btnUpdateMessages.Name = "btnUpdateMessages";
            btnUpdateMessages.Size = new Size(35, 30);
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
            btnSendMessage.Location = new Point(559, 389);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(35, 30);
            btnSendMessage.TabIndex = 1;
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // txtMessageContent
            // 
            txtMessageContent.Dock = DockStyle.Bottom;
            txtMessageContent.Location = new Point(0, 425);
            txtMessageContent.Name = "txtMessageContent";
            txtMessageContent.Size = new Size(617, 23);
            txtMessageContent.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NSM";
            FormClosed += MainForm_FormClosed;
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lbPhoto).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
    }
}