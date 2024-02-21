namespace NSM.FORMS.Forms
{
    partial class RegisterControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterControl));
            txtPassword = new TextBox();
            txtLogin = new TextBox();
            btnRegister = new Button();
            txtPasswordRepeat = new TextBox();
            label4 = new Label();
            txtName = new TextBox();
            lbLogo = new Label();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(91, 192);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(130, 23);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(91, 135);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(130, 23);
            txtLogin.TabIndex = 8;
            // 
            // btnRegister
            // 
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Image = (Image)resources.GetObject("btnRegister.Image");
            btnRegister.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegister.Location = new Point(200, 369);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(105, 37);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Cadastrar";
            btnRegister.TextAlign = ContentAlignment.MiddleRight;
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtPasswordRepeat
            // 
            txtPasswordRepeat.Location = new Point(91, 255);
            txtPasswordRepeat.Name = "txtPasswordRepeat";
            txtPasswordRepeat.Size = new Size(130, 23);
            txtPasswordRepeat.TabIndex = 11;
            txtPasswordRepeat.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.Image = (Image)resources.GetObject("label4.Image");
            label4.ImageAlign = ContentAlignment.MiddleLeft;
            label4.Location = new Point(91, 285);
            label4.Name = "label4";
            label4.Size = new Size(130, 30);
            label4.TabIndex = 12;
            label4.Text = "Nome Completo:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Location = new Point(91, 318);
            txtName.Name = "txtName";
            txtName.Size = new Size(130, 23);
            txtName.TabIndex = 13;
            // 
            // lbLogo
            // 
            lbLogo.Image = (Image)resources.GetObject("lbLogo.Image");
            lbLogo.Location = new Point(103, 0);
            lbLogo.Name = "lbLogo";
            lbLogo.Size = new Size(109, 106);
            lbLogo.TabIndex = 14;
            // 
            // label2
            // 
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(91, 168);
            label2.Name = "label2";
            label2.Size = new Size(67, 21);
            label2.TabIndex = 15;
            label2.Text = "Senha:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(89, 231);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 16;
            label3.Text = "Repetir Senha:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(91, 112);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 17;
            label1.Text = "Login:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // RegisterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lbLogo);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(txtPasswordRepeat);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(btnRegister);
            Name = "RegisterControl";
            Padding = new Padding(25);
            Size = new Size(314, 417);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtLogin;
        private Button btnRegister;
        private TextBox txtPasswordRepeat;
        private Label label4;
        private TextBox txtName;
        private Label lbLogo;
        private Label label2;
        private Label label3;
        private Label label1;
    }
}
