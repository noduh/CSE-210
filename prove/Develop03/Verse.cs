class Verse
{
    private List<Word> words = new List<Word>();

    // Create the verse from the string found in the json
    public Verse(string verse)
    {
        string[] words = verse.Split(" ");
        foreach (string word in words)
        {
            this.words.Add(new Word(word)); // create each word and add it to the list of words for the verse
        }
    }

    // Attempt to modify the verse. Modify if possible, otherwise return false
    public bool ModifyVerse()
    {
        Random random = new Random();
        int maxRandomWords = 3;
        int wordsNotBlank = WordsNotBlank();

        if (wordsNotBlank < maxRandomWords) // change the max blank words if needed. this is also where the method can return false
        {
            if (wordsNotBlank == 0)
            {
                return false;
            }
            maxRandomWords = wordsNotBlank;
        }
        int newNewBlankWordCount = random.Next(1, maxRandomWords + 1);
        int numNewBlankWordsFinished = 0;
        while (numNewBlankWordsFinished < newNewBlankWordCount)
        {
            int randomIndex = random.Next(words.Count);
            if (!words[randomIndex].CheckBlank())
            {
                words[randomIndex].Blank();
                numNewBlankWordsFinished++;
            }
        }
        return true;
    }

    public override string ToString()
    {
        string verseString = "";
        foreach (Word word in words)
        {
            verseString += word.ToString() + " ";
        }
        return verseString;
    }

    private int WordsNotBlank()
    {
        int wordsNotBlank = 0;
        foreach (Word word in words)
        {
            if (!word.CheckBlank())
            {
                wordsNotBlank++;
            }
        }
        return wordsNotBlank;
    }
}
