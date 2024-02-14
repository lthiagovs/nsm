using NSM.SERVER.CORE;
using System.Text.Json;

class Program
{
    public static bool Run = true;
    public static void Send()
    {
        string command = "";
        List<object> bye = new List<object>();
        bye.Add("Bye bye...");

        while (!command.Equals("end")) {

            MessagePackage message = new MessagePackage();
            message.ClientId = 1;
            message.MessageType = MessageType.Message_CreateUser;
            message.Informations = bye;

            //Serializer
            var SerializeOptions = new JsonSerializerOptions();
            SerializeOptions.WriteIndented = true;


            string jsonMessage = JsonSerializer.Serialize<MessagePackage>(message, SerializeOptions);

            Client.ClientWriter.Write(jsonMessage);

            command = Console.ReadLine();
        }

        Run = false;
    }

    public static void Main()
    {

        Thread ServerConsole = new Thread(Server.Show);
        Thread ServerListen = new Thread(Server.Start);

        Server.Start();
        ServerConsole.Start();

        Server.Close();

    }
}