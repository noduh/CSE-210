using System.Text.Json;

public class Reference
{
    private List<Verse> scriptures = new List<Verse>();
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;
    private string fileAddress;
    private string scriptureReference;

    // create the whole scripture from the information given, and prints the scripture
    public Reference(string book, int chapter, int verse, string fileAddress)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = verse;
        this.endVerse = verse;
        this.fileAddress = fileAddress;
        this.scriptureReference = $"{book} {chapter}:{verse}";

        Console.Clear();
        Console.WriteLine(scriptureReference);
        FindVerses(); // create the list of verses in 'scriptures'
        foreach (Verse v in scriptures) // print the scriptures
        {
            Console.WriteLine(v.ToString());
        }
    }

    // create the whole scripture from the information given, and prints the scripture
    public Reference(string book, int chapter, int startVerse, int endVerse, string fileAddress)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
        this.fileAddress = fileAddress;
        this.scriptureReference = $"{book} {chapter}:{startVerse}-{endVerse}";

        Console.Clear();
        Console.WriteLine(scriptureReference);
        FindVerses();
        foreach (Verse v in scriptures) // create the list of verses in 'scriptures'
        {
            Console.WriteLine(v.ToString()); // print the scriptures
        }
    }

    // Modify the Scripture and print it
    public bool PrintModifyScripture() // returns false if every verse is blank
    {
        Console.Clear();
        int versesFinished = 0; // number of verses that are completely blank
        Console.WriteLine(scriptureReference);
        foreach (Verse verse in scriptures)
        {
            bool canBlank = verse.ModifyVerse(); // tries to modify the verse, and tells us if it was successful
            if (!canBlank)
            {
                versesFinished++;
            }
            Console.WriteLine(verse.ToString()); // prints the verse
        }
        return versesFinished < scriptures.Count; // tells us if all the verses have finished
    }

    // Reset the scripture and print
    public void ResetReferenceAndPrint()
    {
        foreach (Verse verse in scriptures)
        {
            Console.Clear();
            Console.WriteLine(scriptureReference);
            verse.ResetVerse();
            foreach (Verse v in scriptures) // create the list of verses in 'scriptures'
            {
                Console.WriteLine(v.ToString()); // print the scriptures
            }
        }
    }

    // create the verse from the json
    private void FindVerses()
    {
        string jsonText = File.ReadAllText(fileAddress); // turn the file into a string
        JsonDocument standardWorkJson = JsonDocument.Parse(jsonText); // parse the string to a JsonDocument
        JsonElement bookJson = standardWorkJson.RootElement.GetProperty(book); // get the book
        JsonElement chapterJson = bookJson.GetProperty(chapter.ToString()); // get the chapter
        for (int verseNum = startVerse; verseNum <= endVerse; verseNum++)
        {
            string verseString = chapterJson.GetProperty(verseNum.ToString()).GetString();
            scriptures.Add(new Verse(verseString)); // creates a new instance of Verse and appends it to the verses
        }
    }
}
