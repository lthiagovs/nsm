using NSM.SERVER.CORE;

class Program
{
    public static void Main()
    {
        if(!Directory.Exists("Photos"))
        {
            Directory.CreateDirectory("Photos");
        }

        Server.Start();

    }

}