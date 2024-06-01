public class Word
{
    private string word;
    private int wordLen;
    private bool isBlank;

    public Word(string word)
    {
        this.word = word;
        this.wordLen = word.Length;
        this.isBlank = false;
    }

    public override string ToString()
    {
        if (isBlank)
        {
            string blankWord = "";
            for (int unused = 0; unused < wordLen; unused++)
            {
                blankWord += "_";
            }
            return blankWord;
        }
        return this.word;
    }

    public void Blank()
    {
        isBlank = !isBlank;
    }

    public bool CheckBlank()
    {
        return isBlank;
    }
}
