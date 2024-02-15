namespace NSM.FORMS.Forms
{
    partial class AccountForm
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
            menu = new MenuStrip();
            menuAccount = new ToolStripMenuItem();
            menuLogin = new ToolStripMenuItem();
            menuRegister = new ToolStripMenuItem();
            pnMain = new Panel();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { menuAccount });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(314, 24);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            // 
            // menuAccount
            // 
            menuAccount.DropDownItems.AddRange(new ToolStripItem[] { menuLogin, menuRegister });
            menuAccount.Name = "menuAccount";
            menuAccount.Size = new Size(51, 20);
            menuAccount.Text = "Conta";
            // 
            // menuLogin
            // 
            menuLogin.Name = "menuLogin";
            menuLogin.Size = new Size(120, 22);
            menuLogin.Text = "Entrar";
            menuLogin.Click += menuLogin_Click;
            // 
            // menuRegister
            // 
            menuRegister.Name = "menuRegister";
            menuRegister.Size = new Size(120, 22);
            menuRegister.Text = "Registrar";
            menuRegister.Click += menuRegister_Click;
            // 
            // pnMain
            // 
            pnMain.Dock = DockStyle.Fill;
            pnMain.Location = new Point(0, 24);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(314, 417);
            pnMain.TabIndex = 1;
            // 
            // AccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 441);
            Controls.Add(pnMain);
            Controls.Add(menu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menu;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AccountForm";
            Text = "NSM";
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem menuAccount;
        private ToolStripMenuItem menuLogin;
        private ToolStripMenuItem menuRegister;
        private Panel pnMain;
    }
}