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
            pcbProfilePicture.Location = new Point(12, 12);
            pcbProfilePicture.Name = "pcbProfilePicture";
            pcbProfilePicture.Size = new Size(400, 400);
            pcbProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbProfilePicture.TabIndex = 0;
            pcbProfilePicture.TabStop = false;
            pcbProfilePicture.Click += pictureBox1_Click;
            // 
            // btnChangePFP
            // 
            btnChangePFP.Location = new Point(309, 373);
            btnChangePFP.Name = "btnChangePFP";
            btnChangePFP.Size = new Size(92, 29);
            btnChangePFP.TabIndex = 1;
            btnChangePFP.Text = "Mudar foto";
            btnChangePFP.UseVisualStyleBackColor = true;
            btnChangePFP.Click += button1_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 438);
            txtName.MaxLength = 20;
            txtName.Name = "txtName";
            txtName.Size = new Size(188, 27);
            txtName.TabIndex = 2;
            txtName.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 415);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 3;
            label1.Text = "Nome:";
            // 
            // btnSalvar
            // 
            btnSalvar.DialogResult = DialogResult.Yes;
            btnSalvar.Location = new Point(309, 436);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // UserProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 483);
            Controls.Add(btnSalvar);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(btnChangePFP);
            Controls.Add(pcbProfilePicture);
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