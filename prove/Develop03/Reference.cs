public class Reference
{
    private List<Verse> scriptures = new List<Verse>();
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;
    private string fileAddress;

    public Reference(string book, int chapter, int verse, string fileAddress)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = verse;
        this.endVerse = verse;
        this.fileAddress = fileAddress;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse, string fileAddress)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
        this.fileAddress = fileAddress;
    }

    public bool PrintScripture() { // returns true if every verse is blank
        int versesFinished = 0; // number of verses that are completely blank
        foreach (Verse verse in scriptures) {
            bool canBlank = verse.ModifyVerse(); // tries to modify the verse, and tells us if it was successful
            if (!canBlank) {
                versesFinished++;
            }
            Console.WriteLine(verse.ToString());
        }
        return !(versesFinished < scriptures.Count); // tells us if all the verses have finished
    }
}
