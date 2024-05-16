public class Journal
{
    private List<Entry> entries = [];
    private List<string> prompts = []; // default prompts
    private Random random = new Random();
    private string dateTimeFormat = "yyyy-MM-dd HH:mm:ss"; // default date/time format

    public void SetPrompts()
    {
        string currentPrompt;
        int promptNumber = 0;
        List<string> prompts = [];
        Console.WriteLine("Type your prompts below. Leave blank to finish.");
        Console.WriteLine("THIS WILL OVERWRITE YOUR PREVIOUS PROMPTS! LEAVE BLANK TO CANCEL!");

        // Continuously get new prompts until the user stops
        do
        {
            promptNumber++;
            Console.Write($"Prompt #{promptNumber}: ");
            currentPrompt = Console.ReadLine();
            if (currentPrompt != "")
            {
                prompts.Add(currentPrompt);
            }
        } while (currentPrompt != "");
        if (prompts.Count != 0)
        {
            this.prompts = prompts;
        }
    }

    // Lets the user change the format
    public void SetDateTimeFormat(string format)
    {
        dateTimeFormat = format;
    }

    public List<string> GetPrompts()
    {
        return prompts;
    }

    // Create a new entry and store it in the list of entries
    public void NewEntry()
    {
        string prompt = prompts[random.Next(prompts.Count)]; // picks a random prompt
        Entry newEntry = new Entry(prompt);
        newEntry.CreateContent();
        entries.Add(newEntry);
    }

    // Delete an entry based on where the entry is in the list of entries
    public void DeleteEntry(int entryNumber)
    {
        int index = entryNumber - 1;
        entries.RemoveAt(index);
    }

    // Get an entry based on where it is
    public Entry GetEntry(int entryNumber) {
        int index = entryNumber - 1;
        return entries[entryNumber];
    }

    // Displays an entry in it's completeness
    public void DisplayEntry(Entry entry)
    {
        Console.WriteLine(entry.GetTime(dateTimeFormat));
        Console.WriteLine(entry.GetContent());
    }

    // Displays all entries including which entry it is
    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Entry #{entries.IndexOf(entry) + 1}");
            DisplayEntry(entry);
        }
    }

    public int GetEntryCount() {
        int count;
        count = entries.Count;
        return count;
    }
}
