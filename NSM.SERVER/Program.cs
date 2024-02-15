using NSM.SERVER.CORE;
using System.Text.Json;

class Program
{
    public static bool Run = true;

    public static void Main()
    {

        Thread ServerConsole = new Thread(Server.Show);
        Thread ServerListen = new Thread(Server.Listen);
        Thread ServerSend = new Thread(Server.SendMessages);

        Server.Start();

        //Start Operations
        ServerConsole.Start();
        ServerListen.Start();
        ServerSend.Start();

        while (Run) { Server.Execute();}

        Server.Close();

    }
}