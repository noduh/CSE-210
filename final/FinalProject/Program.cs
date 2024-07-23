using System;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static async Task Main()
    {
        Server server = new Server(11000);
        server.Run();
        while (true)
        {
            string command = Console.ReadLine();
            if (command.Equals("stop", StringComparison.CurrentCultureIgnoreCase))
            {
                server.Stop();
                break;
            }
        }
        // User testUser = new User("testUser");
        // Command testCommand = new Command(testUser, "testCommand", ["a1", "b2"]);
        // var options = new JsonSerializerOptions { IncludeFields = true };
        // Console.WriteLine(JsonSerializer.Serialize(testCommand, options));
    }
}
