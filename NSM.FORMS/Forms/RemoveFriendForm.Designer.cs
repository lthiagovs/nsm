namespace NSM.FORMS.Forms
{
    partial class RemoveFriendForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveFriendForm));
            label1 = new Label();
            cbFriends = new ComboBox();
            btnRemove = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Amigos:";
            // 
            // cbFriends
            // 
            cbFriends.FormattingEnabled = true;
            cbFriends.Location = new Point(12, 27);
            cbFriends.Name = "cbFriends";
            cbFriends.Size = new Size(220, 23);
            cbFriends.TabIndex = 1;
            // 
            // btnRemove
            // 
            btnRemove.DialogResult = DialogResult.OK;
            btnRemove.Location = new Point(157, 56);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remover";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // RemoveFriendForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(242, 90);
            Controls.Add(btnRemove);
            Controls.Add(cbFriends);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RemoveFriendForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NSM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        public ComboBox cbFriends;
        private Button btnRemove;
    }
}