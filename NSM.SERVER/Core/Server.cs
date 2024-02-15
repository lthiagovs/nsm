using NSM.COMMON;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using NSM.SERVER.Models;

namespace NSM.SERVER.CORE
{

    /*
         * Still needs to read another MessageTypes
         * Need to connect to other clients
     */


    public static class Server
    {

        public static TcpListener ServerListener;
        public static Socket Connection;
        public static NetworkStream SocketStream;
        public static BinaryWriter ServerWriter;
        public static BinaryReader ServerReader;
        private static bool Run = false;

        //Messages that the server received
        private static List<MessagePackage> ServerMessages;

        //Messages to send to clients
        private static List<MessagePackage> ClientMessages;
        private static int ServerMessages_Count = 0;
        private static int ClientMessages_Count = 0;
        private static int ExecutedOperations = 0;
        private static int WrongPackageReceived = 0;


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
            ServerMessages = new List<MessagePackage>();
            ClientMessages = new List<MessagePackage>();

            Console.Write("Server Started...\n");
            Run = true;

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
                        ServerMessages.Add(message);
                    }

                }
                catch
                {
                }
                //Listening
            }
        }

        //Send a Message Package to a client
        public static void Send(MessagePackage messagePackage)
        {
            string JsonMessage = JsonSerializer.Serialize<MessagePackage>(messagePackage);
            ServerWriter.Write(JsonMessage);
        }
        
        //Send messages to clients
        public static void SendMessages()
        {
            while(Run)
            {
                if (ClientMessages_Count != ClientMessages.Count)
                {
                    Send(ClientMessages[ClientMessages_Count]);
                    ClientMessages_Count++;
                    ExecutedOperations++;
                }

            }

        }

        //Create a message in ClientMessage to tell
        //that the last message send has a wrong format
        private static void WrongFormat(int ClientId)
        {
            MessagePackage messagePackage = new MessagePackage();
            messagePackage.MessageType = MessageType.Message_WrongFormat;
            messagePackage.ClientId = ClientId;
            messagePackage.Informations = new List<string>();
            ClientMessages.Add(messagePackage);

        }

        //Send a positive message to the client
        private static void Confirmation(int ClientId)
        {
            MessagePackage messagePackage = new MessagePackage();
            messagePackage.MessageType = MessageType.Message_Confirmation;
            messagePackage.ClientId = ClientId;
            messagePackage.Informations = new List<string>();
            ClientMessages.Add(messagePackage);
        }

        //Send a negative message to the client
        private static void Negation(int ClientId)
        {
            MessagePackage messagePackage = new MessagePackage();
            messagePackage.MessageType = MessageType.Message_Negation;
            messagePackage.ClientId = ClientId;
            messagePackage.Informations = new List<string>();
            ClientMessages.Add(messagePackage);
        }

        //Reads Message Packages and take decisions
        public static void Execute()
        {
            if (ServerMessages_Count != ServerMessages.Count)
            {
                MessagePackage? Message = ServerMessages[ServerMessages_Count];
                ServerMessages_Count++;
                ExecutedOperations++;

                try
                {
                    //Operations
                    if (Message.MessageType == MessageType.Message_CreateUser)
                    {
                        //Try to read the message

                        //Create a new user
                        User? User = Database.GetUser(Message.Informations[2], Message.Informations[1]);
                        if (User == null)
                        {
                            Database.CreateUser(Message.Informations[0], Message.Informations[1],
                                Message.Informations[2], Message.Informations[3]);

                            Confirmation(Message.ClientId);
                        }
                        else
                            Negation(Message.ClientId);

                    }
                    else if (Message.MessageType == MessageType.Message_GetUser)
                    {
                        User? User = Database.GetUser(Message.Informations[0], Message.Informations[1]);
                        if(User == null)
                        {
                            Negation(Message.ClientId);
                        }
                        else
                        {
                            //Send to client all informations about loged user
                            MessagePackage UserMessage = new MessagePackage();
                            UserMessage.ClientId = Message.ClientId;
                            UserMessage.MessageType = MessageType.Message_Confirmation;
                            UserMessage.Informations = new List<string>();
                            UserMessage.Informations.Add(User.Id+"");
                            UserMessage.Informations.Add(User.Name);
                            UserMessage.Informations.Add(User.Login);
                            UserMessage.Informations.Add(User.Password);
                            UserMessage.Informations.Add(User.Photo);
                            ClientMessages.Add(UserMessage);

                        }

                    }
                    else if (Message.MessageType == MessageType.Message_SearchUser)
                    {

                        User? User = Database.GetUser(Message.Informations[0]);

                        if(User != null)
                        {

                            //Send to client user Id
                            MessagePackage UserMessage = new MessagePackage();
                            UserMessage.ClientId = Message.ClientId;
                            UserMessage.MessageType = MessageType.Message_Confirmation;
                            UserMessage.Informations = new List<string>();
                            UserMessage.Informations.Add(User.Id + "");
                            ClientMessages.Add(UserMessage);

                        }
                        else
                        {
                            Negation(Message.ClientId);
                        }

                    }
                    else if (Message.MessageType == MessageType.Message_CreateFriendChat)
                    {
                        Database.CreateChat("FriendChat",Message.ClientId);
                        Chat chat = Database.GetLastChat();
                        Database.BoundChat(chat.Id, Convert.ToInt32(Message.Informations[0]));
                    }

                    //Operations

                }
                catch
                {
                    WrongPackageReceived++;
                    if (Message != null) { WrongFormat(Message.ClientId);}
                }
            }
        }

        //Show to user the current information
        public static void Show()
        {
            while(Run)
            {
                Console.WriteLine("NSM SERVER ONLINE");
                Console.WriteLine("------------------");
                Console.WriteLine("Current Message Packages to execute: "+(ServerMessages.Count-ServerMessages_Count));
                Console.WriteLine("Current Message Packages to send: " +(ClientMessages.Count-ClientMessages_Count));
                Console.WriteLine("------------------");
                Console.WriteLine("Executed Operations: " + ExecutedOperations);
                Console.WriteLine("Wrong Packages Received: " + WrongPackageReceived);
                Thread.Sleep(1000);
                Console.Clear();
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
