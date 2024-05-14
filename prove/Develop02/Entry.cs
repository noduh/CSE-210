public class Entry
{
    private string prompt;
    private string content;
    private int hour;
    private int minute;
    private int month;
    private int day;
    private int year;

    public Entry(string prompt)
    {
        this.prompt = prompt;
    }

    public void CreateContent()
    {
        Console.WriteLine(prompt);
        content = Console.ReadLine();
    }
}
