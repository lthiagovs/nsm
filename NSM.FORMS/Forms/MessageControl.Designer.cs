namespace NSM.FORMS.Forms
{
    partial class MessageControl
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
            lbText = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
            SuspendLayout();
            // 
            // pbPhoto
            // 
            pbPhoto.BorderStyle = BorderStyle.FixedSingle;
            pbPhoto.Location = new Point(3, 3);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(60, 60);
            pbPhoto.TabIndex = 0;
            pbPhoto.TabStop = false;
            // 
            // lbText
            // 
            lbText.Location = new Point(69, 3);
            lbText.Name = "lbText";
            lbText.Size = new Size(494, 60);
            lbText.TabIndex = 1;
            lbText.Text = "_message_";
            // 
            // MessageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lbText);
            Controls.Add(pbPhoto);
            Name = "MessageControl";
            Size = new Size(566, 68);
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox pbPhoto;
        public Label lbText;
        private Label label1;
    }
}
