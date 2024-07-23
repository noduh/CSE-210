using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
                    HandleCommandJson(stringReceived, socket);
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

    private void HandleCommandJson(string commandJson, Socket socket)
    {
        bool allowed = false;
        Command command = null;
        User sender;
        string commandString;
        List<string> args;
        string reason = "unknown error";

        Response response; // response to be sent at the end

        try
        {
            command = JsonSerializer.Deserialize<Command>(commandJson);
        }
        catch (JsonException)
        {
            allowed = false;
            reason = "bad json";
        }

        if (command != null)
        {
            sender = command.GetSender();
            commandString = command.GetCommand();
            args = command.GetArgs();

            switch (commandString)
            {
                case "join":
                    if (board.AddPlayer(sender))
                    {
                        allowed = true;
                        reason = "successfully joined";
                    }
                    else
                    {
                        allowed = false;
                        reason = "couldn't join";
                    }
                    break;

                case "move":
                    if (args.Count != 2) // check for right amount of args
                    {
                        allowed = false;
                        reason = "bad move";
                        break;
                    }

                    string startLocationString = args[0];
                    string endLocationString = args[1];
                    if (startLocationString.Length != 2 || endLocationString.Length != 2) // check for right length of things
                    {
                        allowed = false;
                        reason = "bad move";
                        break;
                    }

                    // create start and end locations in chess notation
                    char startRank = char.ToUpper(startLocationString[0]);
                    int startFile = startLocationString[1];
                    char endRank = char.ToUpper(endLocationString[0]);
                    int endFile = endLocationString[1];

                    // create move from locations
                    Move attemptedMove = new Move(startRank, startFile, endRank, endFile);

                    // attempt to move
                    if (board.TakeTurn(sender, attemptedMove))
                    {
                        allowed = true;
                        reason = "successfully moved";
                    }
                    else
                    {
                        allowed = false;
                        reason = "move not allowed";
                    }

                    break;

                default:
                    allowed = false;
                    reason = "bad command";
                    break;
            }
        }

        response = new Response(allowed, 0, reason);

        // send the response
        string jsonString = JsonSerializer.Serialize(response);
        socket.SendAsync(Encoding.UTF8.GetBytes(jsonString));
    }
}
