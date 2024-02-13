namespace NSM.SERVER.CORE
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
