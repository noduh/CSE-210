public class Knight : Piece
{
    public Knight(string color, (int, int) startIndex)
        : base(Knight, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        List<Move> legalMoves = new List<Move>();
        List<Move> potentialMoves = new List<Move>();

        (char startRank, int startFile) = Move.ToChessNotation(
            currentIndex.rank,
            currentIndex.file
        );

        potentialMoves.Add(new Move(startRank, startFile, (char)(startRank + 2), startFile - 1));
        potentialMoves.Add(new Move(startRank, startFile, (char)(startRank + 2), startFile + 1));
        potentialMoves.Add(new Move(startRank, startFile, (char)(startRank - 2), startFile - 1));
        potentialMoves.Add(new Move(startRank, startFile, (char)(startRank - 2), startFile + 1));
        potentialMoves.Add(new Move(startRank, startFile, (char)(startRank + 1), startFile - 2));
        potentialMoves.Add(new Move(startRank, startFile, (char)(startRank + 1), startFile + 2));
        potentialMoves.Add(new Move(startRank, startFile, (char)(startRank - 1), startFile - 2));
        potentialMoves.Add(new Move(startRank, startFile, (char)(startRank - 1), startFile + 2));

        foreach (Move testMove in potentialMoves) // check that each is in bounds
        {
            if (Move.InBounds(testMove))
            {
                legalMoves.Add(testMove);
            }
        }

        return legalMoves;
    }
}
