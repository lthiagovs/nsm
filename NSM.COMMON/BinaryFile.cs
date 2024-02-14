namespace NSM.COMMON
{
    public class BinaryFile : IDisposable
    {
        public Stream FileStream { get; set; }

        public BinaryWriter FileWriter {get; set;}

        public BinaryReader FileReader { get; set;}

        //Creates a file if not exist
        public bool Create(string filename)
        {

            try
            {
                if (!File.Exists(filename))
                {
                    FileStream = File.Create(filename);
                    FileWriter = new BinaryWriter(FileStream);
                    FileReader = new BinaryReader(FileStream);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception();
            }

        }

        //Opens a file if exist
        public bool Open(string filename)
        {

            if (File.Exists(filename))
            {

                FileStream = File.Open(filename, FileMode.Open);
                FileWriter = new BinaryWriter(FileStream);
                FileReader = new BinaryReader(FileStream);
                return true;

            }

            return false;

        }

        //Writes all text lines on file
        public void WriteAll(List<string> Text)
        {
            try
            {
                foreach(string word in Text)
                {
                    FileWriter.Write(word);
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        //Reads all file strings
        public List<string> ReadAll()
        {
            List<string> FileText = new List<string>();
            try
            {
                string text = FileReader.ReadString();
                while (this.FileStream.Position != this.FileStream.Length)
                {
                    FileText.Add(text);
                    text = FileReader.ReadString();
                }

            }
            catch
            {
                throw new Exception();
            }
            return FileText;

        }

        //Interface IDisposable
        public void Dispose()
        {
            if( FileStream != null )
            FileStream.Close();

            if(FileWriter != null)
            FileWriter.Close();

            if(FileReader != null)
            FileReader.Close();

        }

    }
}
