public class Command
{
    private User sender;
    private string command;
    private List<string> args;

    public Command(User sender, string command)
    {
        this.sender = sender;
        this.command = command;
    }

    public Command(User sender, string command, List<string> args)
    {
        this.sender = sender;
        this.command = command;
        this.args = args;
    }

    public string GetCommand() // sends a response to be used and a command to be run
    {
        return command;
    }

    public User GetSender()
    {
        return sender;
    }

    public List<string> GetArgs()
    {
        return args;
    }
}
