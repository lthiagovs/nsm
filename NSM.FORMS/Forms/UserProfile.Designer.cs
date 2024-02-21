namespace NSM.FORMS.Forms
{
    partial class UserProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfile));
            pcbProfilePicture = new PictureBox();
            btnChangePFP = new Button();
            txtName = new TextBox();
            label1 = new Label();
            btnSalvar = new Button();
            ((System.ComponentModel.ISupportInitialize)pcbProfilePicture).BeginInit();
            SuspendLayout();
            // 
            // pcbProfilePicture
            // 
            pcbProfilePicture.Image = (Image)resources.GetObject("pcbProfilePicture.Image");
            pcbProfilePicture.InitialImage = null;
            pcbProfilePicture.Location = new Point(10, 9);
            pcbProfilePicture.Margin = new Padding(3, 2, 3, 2);
            pcbProfilePicture.Name = "pcbProfilePicture";
            pcbProfilePicture.Size = new Size(350, 300);
            pcbProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbProfilePicture.TabIndex = 0;
            pcbProfilePicture.TabStop = false;
            pcbProfilePicture.Click += pictureBox1_Click;
            // 
            // btnChangePFP
            // 
            btnChangePFP.Location = new Point(270, 280);
            btnChangePFP.Margin = new Padding(3, 2, 3, 2);
            btnChangePFP.Name = "btnChangePFP";
            btnChangePFP.Size = new Size(80, 22);
            btnChangePFP.TabIndex = 1;
            btnChangePFP.Text = "Mudar foto";
            btnChangePFP.UseVisualStyleBackColor = true;
            btnChangePFP.Click += button1_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(10, 328);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.MaxLength = 20;
            txtName.Name = "txtName";
            txtName.Size = new Size(165, 23);
            txtName.TabIndex = 2;
            txtName.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 311);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 3;
            label1.Text = "Nome:";
            // 
            // btnSalvar
            // 
            btnSalvar.DialogResult = DialogResult.Yes;
            btnSalvar.Location = new Point(270, 327);
            btnSalvar.Margin = new Padding(3, 2, 3, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(82, 22);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // UserProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 362);
            Controls.Add(btnSalvar);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(btnChangePFP);
            Controls.Add(pcbProfilePicture);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserProfile";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UserProfile";
            Load += UserProfile_Load;
            ((System.ComponentModel.ISupportInitialize)pcbProfilePicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pcbProfilePicture;
        private Button btnChangePFP;
        private Label label1;
        private Button btnSalvar;
        public TextBox txtName;
    }
}