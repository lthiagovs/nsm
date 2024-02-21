using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace NSM.FORMS.Forms
{
    public partial class UserProfile : Form
    {
        public string caminhoDaImagem;
        private bool photoChanged = false;
        public UserProfile(string name, byte[] photoInBytes)
        {
            InitializeComponent();
            txtName.Text = name;
            if (photoInBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(photoInBytes))
                {
                    Image image = Image.FromStream(ms);
                    pcbProfilePicture.Image = image;
                    photoChanged = true;
                }
            }
            else
            {
                pcbProfilePicture.ImageLocation = "anonymAvatar.jpg";
            }
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JPG File|*.jpg*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    caminhoDaImagem = openFileDialog.FileName;
                    pcbProfilePicture.ImageLocation = caminhoDaImagem;
                    // byte[] PFPByte = File.ReadAllBytes(caminhoDaImagem);
                }   
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (caminhoDaImagem != null)
            {
                if (photoChanged)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
