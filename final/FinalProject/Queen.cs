public class Queen : Piece
{
    public Queen(string color, (int, int) startIndex)
        : base(Queen, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        List<Move> potentialMoves = new List<Move>();
        List<Move> legalMoves = new List<Move>();
        (char startRank, int startFile) = Move.ToChessNotation(
            currentIndex.rank,
            currentIndex.file
        );

        // Diagonals
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

        foreach (Move testMove in potentialMoves) // check inbounds for diagonal
        {
            if (Move.InBounds(testMove))
            {
                legalMoves.Add(testMove);
            }
        }


        // Perpendiculars
        for (char rank = 'A'; rank <= 'H'; rank++) // rank moves
        {
            legalMoves.Add(new Move(startRank, startFile, rank, startFile));
        }

        for (int file = 1; file <= 8; file++) // file moves
        {
            legalMoves.Add(new Move(startRank, startFile, startRank, file));
        }


        // Return
        return legalMoves;
    }
}
