﻿using NSM.COMMON;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text;
using NSM.SERVER.Models;

namespace NSM.SERVER.CORE
{
    public static class Server
    {
        public static int Port = 8080;
        public static string IP = "127.0.0.1";

        public static Socket ServerListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static IPEndPoint Adress = new IPEndPoint(IPAddress.Parse(IP), Port);

        //Informations
        public static int MessagesReceived = 0;
        public static int MessagesSend = 0;
        public static int WrongPackages = 0;
        public static int Operations = 0;

        public static void Start()
        {
            ServerListener.Bind(Adress);
            ServerListener.Listen(100);
            Run();
        }

        public static void Run()
        {
            Console.WriteLine("Server is listening...");

            Socket ClientSocket = default(Socket);
            int ClientCounter = 0;
            while (true)
            {
                Console.WriteLine("Clients number:" + ClientCounter);

                //Connect to another client
                ClientSocket = ServerListener.Accept();

                //Start thread to answer the user
                Thread operateThread = new Thread(new ThreadStart(() => Operate(ClientSocket)));
                operateThread.Start();
                ClientCounter++;

            }
        }

        public static void Operate(Socket Client)
        {
            while (true)
            {
                //Get Json from Client
                byte[] ClientMsg = new byte[1024];
                int size = Client.Receive(ClientMsg);
                string json = (Encoding.ASCII.GetString(ClientMsg, 0, size));
                MessagePackage Message;
                MessagePackage Send = new MessagePackage();
                Send.Informations = new List<string>();
                Send.ClientId = 0;
                try
                {
                    Message = JsonSerializer.Deserialize<MessagePackage>(json);
                    //Operate
                    #region
                    if (Message.MessageType == MessageType.Message_CreateUser)
                    {
                        //Try to read the message

                        //Create a new user
                        User? User = Database.GetUser(Message.Informations[2], Message.Informations[1]);
                        if (User == null)
                        {
                            Database.CreateUser(Message.Informations[0], Message.Informations[1],
                                Message.Informations[2], Message.Informations[3]);

                            Send.MessageType = MessageType.Message_Confirmation;
                        }
                        else
                            Send.MessageType = MessageType.Message_Negation;

                    }
                    else if (Message.MessageType == MessageType.Message_GetUser)
                    {
                        User? User = Database.GetUser(Message.Informations[0], Message.Informations[1]);
                        if (User == null)
                        {
                            Send.MessageType = MessageType.Message_Negation;
                        }
                        else
                        {
                            //Send to client all informations about loged user
                            Send.MessageType = MessageType.Message_Confirmation;
                            Send.Informations = new List<string>();
                            Send.Informations.Add(User.Id + "");
                            Send.Informations.Add(User.Name);
                            Send.Informations.Add(User.Login);
                            Send.Informations.Add(User.Password);
                            Send.Informations.Add(User.Photo);

                        }

                    }
                    else if (Message.MessageType == MessageType.Message_SearchUser)
                    {

                        User? User = Database.GetUser(Message.Informations[0]);

                        if (User != null)
                        {

                            //Send to client user Id
                            Send.MessageType = MessageType.Message_Confirmation;
                            Send.Informations = new List<string>();
                            Send.Informations.Add(User.Id + "");

                        }
                        else
                        {
                            Send.MessageType = MessageType.Message_Negation;
                        }

                    }
                    else if (Message.MessageType == MessageType.Message_CreateFriendChat)
                    {
                        Database.CreateChat("FriendChat", Message.ClientId);
                        Chat chat = Database.GetLastChat();
                        Database.BoundChat(chat.Id, Convert.ToInt32(Message.Informations[0]));
                    }
                    else if (Message.MessageType == MessageType.Message_GetFriendChatMessages)
                    {

                        Chat chat = Database.GetFriendChat(Convert.ToInt32(Message.Informations[0]), Convert.ToInt32(Message.Informations[1]));
                        Send.ClientId = Message.ClientId;
                        Send.MessageType = MessageType.Message_Confirmation;
                        Send.Informations = new List<string>();
                        List<Message> ObjMessages = new List<Message>();
                        ObjMessages = Database.GetMessages(chat.Id);
                        //Add message string to Send.Informations
                        Send.Informations.Add(chat.Id + "");
                        foreach (Message message in ObjMessages)
                        {
                            Send.Informations.Add(message.Content);
                        }

                    }
                    else if (Message.MessageType == MessageType.Message_SendMessage)
                    {
                        Database.CreateMessage(Message.Informations[1], Convert.ToInt32(Message.Informations[0]));
                    }
                    else if (Message.MessageType == MessageType.Message_GetChatMessages)
                    {
                        List<Message> messages = Database.GetMessages(Convert.ToInt32(Message.Informations[0]));
                        Send.MessageType = MessageType.Message_Confirmation;
                        Send.ClientId = Message.ClientId;
                        Send.Informations = new List<string>();

                        foreach (Message message in messages)
                        {
                            Send.Informations.Add(message.Content);
                        }

                    }
                    else if (Message.MessageType == MessageType.Message_DeleteUser)
                    {
                        Database.DeleteUser(Message.Informations[0], Message.Informations[1]);
                        Send.MessageType = MessageType.Message_Confirmation;

                    }
                    #endregion
                    //Operate

                }
                catch //Wrong Package Received
                {
                    Send.MessageType = MessageType.Message_WrongFormat;
                }

                //Send back
                string messageClient = JsonSerializer.Serialize<MessagePackage>(Send);
                Client.Send(Encoding.ASCII.GetBytes(messageClient), 0, messageClient.Length, SocketFlags.None);

            }

        }

    }

}
