namespace NSM.FORMS.Forms
{
    partial class FriendControl
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
            pbPhoto = new PictureBox();
            lbName = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
            SuspendLayout();
            // 
            // pbPhoto
            // 
            pbPhoto.Cursor = Cursors.Hand;
            pbPhoto.Location = new Point(3, 3);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(50, 50);
            pbPhoto.TabIndex = 0;
            pbPhoto.TabStop = false;
            pbPhoto.DoubleClick += pbPhoto_DoubleClick;
            pbPhoto.MouseEnter += pbPhoto_MouseEnter;
            pbPhoto.MouseLeave += pbPhoto_MouseLeave;
            // 
            // lbName
            // 
            lbName.Cursor = Cursors.Hand;
            lbName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbName.ForeColor = Color.Black;
            lbName.Location = new Point(59, 3);
            lbName.Name = "lbName";
            lbName.Size = new Size(86, 50);
            lbName.TabIndex = 1;
            lbName.Text = "_name_";
            lbName.DoubleClick += lbName_DoubleClick;
            lbName.MouseEnter += lbName_MouseEnter;
            lbName.MouseLeave += lbName_MouseLeave;
            // 
            // FriendControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbName);
            Controls.Add(pbPhoto);
            Name = "FriendControl";
            Size = new Size(160, 60);
            MouseEnter += FriendControl_MouseEnter;
            MouseLeave += FriendControl_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox pbPhoto;
        public Label lbName;
    }
}
