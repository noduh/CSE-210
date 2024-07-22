public class Move
{
    private char startRank;
    private int startFile;
    private char endRank;
    private int endFile;

    public Move(char startRank, int startFile, char endRank, int endFile) // takes it in the standard chess format
    {
        this.startRank = char.ToUpper(startRank);
        this.startFile = startFile;
        this.endRank = char.ToUpper(endRank);
        this.endFile = endFile;
    }

    public (int, int) GetStartIndex()
    {
        int rankIndex = startRank - 65; // convert to an index (starts at 0)
        int fileIndex = startFile - 1; // move to start at indecx 0

        return (rankIndex, fileIndex);
    }

    public (int, int) GetEndIndex()
    {
        int rankIndex = endRank - 65; // convert to an index (starts at 0)
        int fileIndex = endFile - 1; // move to start at indecx 0

        return (rankIndex, fileIndex);
    }

    public override string ToString()
    {
        return $"{startRank}{startFile} {endRank}{endFile}";
    }
}
