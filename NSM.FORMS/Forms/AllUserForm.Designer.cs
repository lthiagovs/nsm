namespace NSM.FORMS.Forms
{
    partial class AllUserForm
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
            label1 = new Label();
            cbUser = new ComboBox();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 0;
            label1.Text = "Todos os usuários:";
            // 
            // cbUser
            // 
            cbUser.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbUser.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbUser.FormattingEnabled = true;
            cbUser.Location = new Point(12, 27);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(230, 23);
            cbUser.Sorted = true;
            cbUser.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.DialogResult = DialogResult.OK;
            btnAdd.Location = new Point(167, 75);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // AllUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 110);
            Controls.Add(btnAdd);
            Controls.Add(cbUser);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AllUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NSM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAdd;
        public ComboBox cbUser;
    }
}