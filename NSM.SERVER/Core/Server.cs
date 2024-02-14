using System.Net;
using System.Net.Sockets;

namespace NSM.SERVER.CORE
{
    public static class Server
    {

        public static TcpListener ServerListener;
        public static Socket Connection;
        public static NetworkStream SocketStream;
        public static BinaryWriter ServerWriter;
        public static BinaryReader ServerReader;
        private static bool Run = false;

        public static void Start()
        {
            Console.Write("ServerListener Started ");
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            ServerListener = new TcpListener(ip, 4444);
            ServerListener.Start();
            Connection = ServerListener.AcceptSocket();
            SocketStream = new NetworkStream(Connection);

            ServerWriter = new BinaryWriter(SocketStream);

            ServerReader = new BinaryReader(SocketStream);
            Console.Write("with sucess...\n");

            //Start listening...
            Listen();
        }

        public static void Listen()
        {
            Run = true;
            Console.WriteLine("ServerListener listening...");
            while (Run)
            {
                try
                {
                    Console.WriteLine("Listen*" + ServerReader.ReadString() +"*Listen");
                }
                catch
                {

                }
            }
        }

        public static void Close()
        {
            Run = false;
            ServerReader.Close();
            ServerWriter.Close();
            SocketStream.Close();
            Connection.Close();
            ServerListener.Dispose();
        }

    }

    //TEST CLIENT
    public static class Client
    {
        public static TcpClient ClientListener = new TcpClient();
        public static NetworkStream SocketStream;
        public static BinaryWriter ClientWriter;
        public static BinaryReader ClientReader;

        public static void Start()
        {
            ClientListener.Connect("127.0.0.1",4444);
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
