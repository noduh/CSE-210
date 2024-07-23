using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server
{
    private readonly int BUFFERSIZE = 1024;
    private readonly string DISCONNECT_STRING = "disconnect";
    private List<Socket> connected;
    private IPEndPoint iPEndPoint;
    private Socket listenerSocket;
    private bool isRunning;
    private CancellationTokenSource cts;
    private CancellationToken cancelationToken;

    // Game Variables
    public Board board;

    public Server(int port)
    {
        iPEndPoint = new(IPAddress.Any, port);
        connected = new List<Socket>();
        cts = new CancellationTokenSource();
        cancelationToken = cts.Token;

        // Create Game
        board = new Board();
    }

    public async Task Run()
    {
        ServerLog("Starting...");

        listenerSocket = new(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        listenerSocket.Bind(iPEndPoint);
        listenerSocket.Listen();

        isRunning = true;
        ServerLog("Started");

        while (isRunning)
        {
            try
            {
                Socket clientSocket = await listenerSocket.AcceptAsync(cancelationToken);
                connected.Add(clientSocket);
                ServerLog($"Client Connected: {((IPEndPoint)clientSocket.RemoteEndPoint).Address}"); // shows who connected
                HandleClient(clientSocket);
            }
            catch (OperationCanceledException) // when the server stops this will be thrown
            {
                ServerLog("Stopping...");
            }
        }

        // close the sockets (each client socket is closed automatically in HandleClient)
        listenerSocket.Close();
    }

    private async Task HandleClient(Socket socket)
    {
        bool keepListening = true;
        byte[] buffer = new byte[BUFFERSIZE];
        while (keepListening && isRunning)
        {
            try
            {
                int bytesReceived = await socket.ReceiveAsync(buffer, cancelationToken);
                string stringReceived = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                if (stringReceived.ToLower() == DISCONNECT_STRING) // only display and reply if it's not a disconnect message
                {
                    keepListening = false;
                    await socket.SendAsync(Encoding.UTF8.GetBytes(DISCONNECT_STRING));
                }
                else
                {
                    ServerLog($"Received Message: {stringReceived}");
                    await socket.SendAsync(Encoding.UTF8.GetBytes("Heard ya loud and clear!"));
                }
            }
            catch (OperationCanceledException) // for when the server stops
            {
                ServerLog("Closing Connection");
            }
        }
        socket.Close();
        connected.Remove(socket);
        ServerLog($"Client Disconnected");
    }

    public void Stop()
    {
        isRunning = false;
        cts.Cancel();
    }

    public static void ServerLog(string message)
    {
        Console.WriteLine($"[Server] {message}");
    }
}
