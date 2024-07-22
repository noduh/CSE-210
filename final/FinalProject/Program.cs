using System;

class Program
{
    static async Task Main()
    {
        Server server = new Server(11000);
        await server.Run();
    }
}
