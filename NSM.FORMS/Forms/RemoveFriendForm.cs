namespace NSM.FORMS.Forms
{
    public partial class RemoveFriendForm : Form
    {

        private List<string> friends = new List<string>();

        private string Name {  get; set; }

        public RemoveFriendForm(string Name)
        {
            InitializeComponent();
            this.Name = Name;

            if(File.Exists(@"friendlist" + this.Name + ".bin"))
            {

                using (Stream file = File.Open(@"friendlist" + this.Name + ".bin", FileMode.Open))
                {

                    BinaryReader reader = new BinaryReader(file);

                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        friends.Add(reader.ReadString());
                    }

                    reader.Close();

                }


            }

            cbFriends.DataSource = friends;

        }
    }
}
