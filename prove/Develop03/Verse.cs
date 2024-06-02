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
        int newNewBlankWordCount = random.Next(1, maxRandomWords + 1); // picks a random number of words to make blank
        int numNewBlankWordsFinished = 0;
        while (numNewBlankWordsFinished < newNewBlankWordCount) // blanks all the words
        {
            int randomIndex = random.Next(words.Count);
            if (!words[randomIndex].CheckBlank()) // only try to blank the word if it's not already blank
            {
                words[randomIndex].Blank();
                numNewBlankWordsFinished++;
            }
        }
        return true;
    }

    // Reset the verse
    public void ResetVerse()
    {
        foreach (Word word in words)
        {
            if (word.CheckBlank()) // if it's blank, reset it to not blank
            {
                word.Blank();
            }
        }
    }

    // get the string version of the verse by getting the string for each word
    public override string ToString()
    {
        string verseString = "";
        foreach (Word word in words)
        {
            verseString += word.ToString() + " ";
        }
        return verseString;
    }

    // check how many words aren't blank
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
