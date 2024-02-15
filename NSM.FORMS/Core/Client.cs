using NSM.COMMON;
using System.Net.Sockets;
using System.Text.Json;
using System.Text;

namespace NSM.FORMS.CORE
{
    public static class Client
    {
        public static TcpClient ClientListener = new TcpClient();
        public static NetworkStream SocketStream;
        public static BinaryWriter ClientWriter;
        public static BinaryReader ClientReader;

        public static void Start()
        {
            ClientListener.Connect("localhost", 4444);
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

        public static MessagePackage Listen()
        {

            string Json = Client.ClientReader.ReadString();
            MessagePackage Message = JsonSerializer.Deserialize<MessagePackage>(Json);
            return Message;

        }

        public static void Send(MessagePackage MessagePackage)
        {

            string JsonMessage = JsonSerializer.Serialize<MessagePackage>(MessagePackage);
            Client.ClientWriter.Write(JsonMessage);

        }

    }

}
