namespace NSM.FORMS.Forms
{
    partial class GroupControl
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
            lbName = new Label();
            SuspendLayout();
            // 
            // lbName
            // 
            lbName.BorderStyle = BorderStyle.FixedSingle;
            lbName.Dock = DockStyle.Fill;
            lbName.Location = new Point(0, 0);
            lbName.Name = "lbName";
            lbName.Size = new Size(110, 60);
            lbName.TabIndex = 1;
            lbName.Text = "_name_";
            // 
            // GroupControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbName);
            Name = "GroupControl";
            Size = new Size(110, 60);
            ResumeLayout(false);
        }

        #endregion

        public Label lbName;
    }
}
