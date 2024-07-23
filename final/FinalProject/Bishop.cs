public class Bishop : Piece
{
    public Bishop(string color, (int, int) startIndex)
        : base(Bishop, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        List<Move> potentialMoves = new List<Move>();
        List<Move> legalMoves = new List<Move>();
        (char startRank, int startFile) = Move.ToChessNotation(
            currentIndex.rank,
            currentIndex.file
        );

        for (int i = 1; i <= 8; i++) // all four diagonals
        {
            potentialMoves.Add(
                new Move(startRank, startFile, (char)(startRank - i), startFile - i)
            );
            potentialMoves.Add(
                new Move(startRank, startFile, (char)(startRank + i), startFile - i)
            );
            potentialMoves.Add(
                new Move(startRank, startFile, (char)(startRank - i), startFile + i)
            );
            potentialMoves.Add(
                new Move(startRank, startFile, (char)(startRank + i), startFile + i)
            );
        }

        foreach (Move testMove in potentialMoves) // check inbounds
        {
            if (Move.InBounds(testMove))
            {
                legalMoves.Add(testMove);
            }
        }

        return legalMoves;
    }
}
