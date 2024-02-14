using System.Net;
using System.Net.Sockets;
using System.Text.Json;

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

        private static List<MessagePackage> Messages;


        //Start the server
        public static void Start()
        {
            Console.WriteLine("Starting Server...");
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            ServerListener = new TcpListener(ip, 4444);
            ServerListener.Start();
            Connection = ServerListener.AcceptSocket();
            SocketStream = new NetworkStream(Connection);
            ServerWriter = new BinaryWriter(SocketStream);
            ServerReader = new BinaryReader(SocketStream);
            Messages = new List<MessagePackage>();
            Console.Write("Server Started...\n");
        }

        //Listen to Message Packages
        public static void Listen()
        {
            Run = true;
            Console.WriteLine("ServerListener listening...");
            var SerializeOptions = new JsonSerializerOptions();
            SerializeOptions.WriteIndented = true;

            while (Run)
            {
                //Listening
                try
                {
                    string JSon = ServerReader.ReadString();
                    MessagePackage? message = JsonSerializer.Deserialize<MessagePackage>(JSon, SerializeOptions);
                    
                    if(message!=null)
                    {
                        Messages.Add(message);
                    }

                }
                catch
                {
                }
                //Listening
            }
        }

        //Send Message Packages to client
        public static void Send()
        {

        }
        
        //Reads Message Packages and take decisions
        public static void Execute()
        {
            while (Run)
            {

            }
        }

        //Show to user the current information
        public static void Show()
        {
            while(Run)
            {
                Console.Write("NSM SERVER ONLINE");
                Console.Write("Current Message Packages: "+Messages.Count);

                //Console.Clear();
            }

        }

        //Dispose the server
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

}
