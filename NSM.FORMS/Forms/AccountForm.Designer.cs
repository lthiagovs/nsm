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
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { menuAccount });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Padding = new Padding(7, 3, 0, 3);
            menu.Size = new Size(359, 30);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            // 
            // menuAccount
            // 
            menuAccount.DropDownItems.AddRange(new ToolStripItem[] { menuLogin, menuRegister });
            menuAccount.Name = "menuAccount";
            menuAccount.Size = new Size(62, 24);
            menuAccount.Text = "Conta";
            // 
            // menuLogin
            // 
            menuLogin.Name = "menuLogin";
            menuLogin.Size = new Size(151, 26);
            menuLogin.Text = "Entrar";
            menuLogin.Click += menuLogin_Click;
            // 
            // menuRegister
            // 
            menuRegister.Name = "menuRegister";
            menuRegister.Size = new Size(151, 26);
            menuRegister.Text = "Registrar";
            menuRegister.Click += menuRegister_Click;
            // 
            // pnMain
            // 
            pnMain.BackColor = SystemColors.ButtonHighlight;
            pnMain.Location = new Point(0, 33);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(359, 556);
            pnMain.TabIndex = 2;
            // 
            // AccountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 593);
            Controls.Add(pnMain);
            Controls.Add(menu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menu;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AccountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NSM";
            Load += AccountForm_Load_1;
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