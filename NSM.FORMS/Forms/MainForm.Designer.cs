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
            panel5 = new Panel();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            panel7 = new Panel();
            panel2 = new Panel();
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
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(textBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(110, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(580, 450);
            panel3.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Location = new Point(5, 11);
            panel5.Name = "panel5";
            panel5.Size = new Size(568, 372);
            panel5.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(507, 389);
            button2.Name = "button2";
            button2.Size = new Size(30, 30);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(543, 389);
            button1.Name = "button1";
            button1.Size = new Size(30, 30);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Bottom;
            textBox1.Location = new Point(0, 425);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(578, 23);
            textBox1.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Location = new Point(3, 33);
            panel7.Name = "panel7";
            panel7.Size = new Size(102, 412);
            panel7.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(panel7);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(690, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(110, 450);
            panel2.TabIndex = 1;
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
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Panel panel5;
        private Panel pnFriends;
        private Panel panel7;
        private Panel panel2;
        private Label label2;
        public Label lbName;
        public string LoginData;
        public string PasswordData;
        private Button btnSearchFriends;
        private Panel panel6;
    }
}