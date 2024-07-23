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
        return ToIndex(startRank, startFile);
    }

    public (int, int) GetEndIndex()
    {
        return ToIndex(endRank, endFile);
    }

    public override string ToString()
    {
        return $"{startRank}{startFile} {endRank}{endFile}";
    }

    public static (char, int) ToChessNotation(int rankIndex, int fileIndex)
    {
        char rank = (char)(rankIndex + 65);
        int file = fileIndex + 1;

        return (rank, file);
    }

    public static (int, int) ToIndex(char rank, int file) {
        int rankIndex = rank - 65; // convert to an index (starts at 0)
        int fileIndex = file - 1; // move to start at indecx 0

        return (rankIndex, fileIndex);
    }

    public static bool InBounds(Move move)
    {
        (int rank, int file) = move.GetEndIndex();
        if (rank < 0 || rank > 7) // check rank in bounds
        {
            return false;
        }
        if (file < 0 || file > 7)
        {
            return false;
        }

        return true; // if neither were out of bounds, you're good
    }
}
