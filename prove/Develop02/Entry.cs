public class Entry
{
    private readonly string prompt;
    private string content;
    private DateTime time;

    public Entry(string prompt)
    {
        this.prompt = prompt;
    }

    // Takes a prompt and asks the user to answer. Also sets the time.
    public void CreateContent()
    {
        Console.WriteLine(prompt);
        content = Console.ReadLine();
        time = DateTime.Now;
    }

    public string GetContent()
    {
        return content;
    }

    public string GetTime(string format)
    {
        return time.ToString(format);
    }
}
