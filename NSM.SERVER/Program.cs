using NSM.SERVER.CORE;

class Program
{
    public static bool Run = true;
    public static void Send()
    {
        string command = "";
        while (!command.Equals("end")) {
            Console.WriteLine("Write a message:");
            command = Console.ReadLine();
            Client.ClientWriter.Write(command);
        }
        Run = false;
    }

    public static void Main()
    {
        Console.WriteLine("ServerListener/Client Test...");

        //Start server
        Thread serverStart = new Thread(Server.Start);
        serverStart.Start();

        //Start client
        Thread clientSends = new Thread(Send);
        Client.Start();
        clientSends.Start();

        //ServerListener Loop
        while(Run)
        {
        }

        Client.Close();
        Server.Close();
    }
}