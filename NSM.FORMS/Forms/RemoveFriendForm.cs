namespace NSM.FORMS.Forms
{
    public partial class RemoveFriendForm : Form
    {

        private List<string> friends = new List<string>();
        public RemoveFriendForm()
        {
            InitializeComponent();

            if(File.Exists("friendlist.bin"))
            {

                using (Stream file = File.Open("friendlist.bin", FileMode.Open))
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
