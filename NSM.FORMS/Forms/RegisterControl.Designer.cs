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
            txtPassword = new TextBox();
            txtLogin = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnRegister = new Button();
            txtPasswordRepeat = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(93, 147);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(130, 23);
            txtPassword.TabIndex = 9;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(93, 90);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(130, 23);
            txtLogin.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 129);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 7;
            label2.Text = "Senha:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 72);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 6;
            label1.Text = "Login:";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(211, 366);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Cadastrar";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtPasswordRepeat
            // 
            txtPasswordRepeat.Location = new Point(93, 210);
            txtPasswordRepeat.Name = "txtPasswordRepeat";
            txtPasswordRepeat.Size = new Size(130, 23);
            txtPasswordRepeat.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 192);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 10;
            label3.Text = "Repetir Senha:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 255);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 12;
            label4.Text = "Nome Completo:";
            // 
            // txtName
            // 
            txtName.Location = new Point(93, 273);
            txtName.Name = "txtName";
            txtName.Size = new Size(130, 23);
            txtName.TabIndex = 13;
            // 
            // RegisterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(txtPasswordRepeat);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label2;
        private Label label1;
        private Button btnRegister;
        private TextBox txtPasswordRepeat;
        private Label label3;
        private Label label4;
        private TextBox txtName;
    }
}
