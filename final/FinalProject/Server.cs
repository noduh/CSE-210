using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server
{
    private readonly int BUFFERSIZE = 1024;
    private List<Socket> connected;
    private IPEndPoint iPEndPoint;
    private Socket listener;

    public Server(int port)
    {
        iPEndPoint = new(IPAddress.Any, port);
        connected = new List<Socket>();
    }

    public async Task Run()
    {
        ServerLog("Starting...");

        listener = new(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        listener.Bind(iPEndPoint);
        listener.Listen();

        ServerLog("Started");

        while (true)
        {
            Socket clientSocket = await listener.AcceptAsync();
            connected.Add(clientSocket);
            ServerLog($"Client Connected: {((IPEndPoint)clientSocket.RemoteEndPoint).Address}"); // shows who connected
            HandleClient(clientSocket);
        }
    }

    private async Task HandleClient(Socket socket)
    {
        byte[] buffer = new byte[BUFFERSIZE];
        int bytesReceived = await socket.ReceiveAsync(buffer, SocketFlags.None);
        string stringReceived = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
        ServerLog($"Received Message: {stringReceived}");
        socket.Close();
        connected.Remove(socket);
        ServerLog($"Client Disconnected");
    }

    private static void ServerLog(string message)
    {
        Console.WriteLine($"[Server] {message}");
    }
}
