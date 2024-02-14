using System.Net.Sockets;

namespace NSM.FORMS.Core
{
    public static class Client
    {
        public static TcpClient ClientListener = new TcpClient();
        public static NetworkStream SocketStream;
        public static BinaryWriter ClientWriter;
        public static BinaryReader ClientReader;

        public static void Start()
        {
            ClientListener.Connect("127.0.0.1", 4444);
            SocketStream = ClientListener.GetStream();
            ClientReader = new BinaryReader(SocketStream);
            ClientWriter = new BinaryWriter(SocketStream);


        }

        public static void Close()
        {
            ClientReader.Close();
            ClientWriter.Close();
            SocketStream.Close();
            ClientListener.Dispose();
        }

    }
}
