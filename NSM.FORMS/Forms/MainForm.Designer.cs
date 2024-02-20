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
            pnGroups = new Panel();
            panel2 = new Panel();
            btnUpdateGroups = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lbPhoto).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
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
            panel1.Size = new Size(110, 450);
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
            panel6.Size = new Size(108, 179);
            panel6.TabIndex = 6;
            // 
            // lbPhoto
            // 
            lbPhoto.BorderStyle = BorderStyle.FixedSingle;
            lbPhoto.Location = new Point(3, 3);
            lbPhoto.Name = "lbPhoto";
            lbPhoto.Size = new Size(100, 100);
            lbPhoto.TabIndex = 0;
            lbPhoto.TabStop = false;
            // 
            // btnSearchFriends
            // 
            btnSearchFriends.Location = new Point(3, 147);
            btnSearchFriends.Name = "btnSearchFriends";
            btnSearchFriends.Size = new Size(75, 23);
            btnSearchFriends.TabIndex = 5;
            btnSearchFriends.Text = "Buscar";
            btnSearchFriends.UseVisualStyleBackColor = true;
            btnSearchFriends.Click += btnSearchFriends_Click;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(3, 106);
            lbName.Name = "lbName";
            lbName.Size = new Size(47, 15);
            lbName.TabIndex = 1;
            lbName.Text = "_name_";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaptionText;
            panel4.Location = new Point(3, 124);
            panel4.Name = "panel4";
            panel4.Size = new Size(102, 2);
            panel4.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 129);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 3;
            label1.Text = "Amigos:";
            // 
            // pnFriends
            // 
            pnFriends.AutoScroll = true;
            pnFriends.Dock = DockStyle.Bottom;
            pnFriends.Location = new Point(0, 185);
            pnFriends.Name = "pnFriends";
            pnFriends.Size = new Size(108, 263);
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
            panel3.Location = new Point(110, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(580, 450);
            panel3.TabIndex = 2;
            // 
            // pnMessages
            // 
            pnMessages.AutoScroll = true;
            pnMessages.Location = new Point(5, 11);
            pnMessages.Name = "pnMessages";
            pnMessages.Size = new Size(568, 372);
            pnMessages.TabIndex = 3;
            // 
            // btnUpdateMessages
            // 
            btnUpdateMessages.Location = new Point(507, 389);
            btnUpdateMessages.Name = "btnUpdateMessages";
            btnUpdateMessages.Size = new Size(30, 30);
            btnUpdateMessages.TabIndex = 2;
            btnUpdateMessages.UseVisualStyleBackColor = true;
            btnUpdateMessages.Click += btnUpdateMessages_Click;
            // 
            // btnSendMessage
            // 
            btnSendMessage.Location = new Point(543, 389);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(30, 30);
            btnSendMessage.TabIndex = 1;
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // txtMessageContent
            // 
            txtMessageContent.Dock = DockStyle.Bottom;
            txtMessageContent.Location = new Point(0, 425);
            txtMessageContent.Name = "txtMessageContent";
            txtMessageContent.Size = new Size(578, 23);
            txtMessageContent.TabIndex = 0;
            // 
            // pnGroups
            // 
            pnGroups.BorderStyle = BorderStyle.FixedSingle;
            pnGroups.Location = new Point(3, 33);
            pnGroups.Name = "pnGroups";
            pnGroups.Size = new Size(102, 412);
            pnGroups.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnUpdateGroups);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pnGroups);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(690, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(110, 450);
            panel2.TabIndex = 1;
            // 
            // btnUpdateGroups
            // 
            btnUpdateGroups.Location = new Point(59, 7);
            btnUpdateGroups.Name = "btnUpdateGroups";
            btnUpdateGroups.Size = new Size(30, 23);
            btnUpdateGroups.TabIndex = 5;
            btnUpdateGroups.UseVisualStyleBackColor = true;
            btnUpdateGroups.Click += btnUpdateGroups_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 15);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 4;
            label2.Text = "Grupos:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NSM";
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lbPhoto).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label label1;
        private Panel panel4;
        private PictureBox lbPhoto;
        private Button btnUpdateMessages;
        private Button btnSendMessage;
        private TextBox txtMessageContent;
        private Panel pnMessages;
        private Panel pnFriends;
        private Panel pnGroups;
        private Panel panel2;
        private Label label2;
        public Label lbName;
        public string LoginData;
        public string PasswordData;
        private Button btnSearchFriends;
        private Panel panel6;
        private Button btnUpdateGroups;
    }
}