public class Word
{
    private string word;
    private int wordLen;
    private bool isBlank;

    // create the word from a string
    public Word(string word)
    {
        this.word = word;
        this.wordLen = word.Length;
        this.isBlank = false;
    }

    // gets the word if it's not blank, otherwise returns blanks instead
    public override string ToString()
    {
        if (isBlank)
        {
            string blankWord = "";
            for (int unused = 0; unused < wordLen; unused++) // underscore for each character in the word
            {
                blankWord += "_";
            }
            return blankWord; // returns the blank
        }
        return this.word; // returns the word if the blank wasn't returned
    }

    // toggle the blank
    public void Blank()
    {
        isBlank = !isBlank;
    }

    // true if blank, otherwise false
    public bool CheckBlank()
    {
        return isBlank;
    }
}
