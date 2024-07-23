public class Pawn : Piece
{
    public Pawn(string color, (int, int) startIndex)
        : base(Pawn, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        List<Move> legalMoves = new List<Move>();

        int moveLimit = 1;
        int moveDirection; // determines if it should add or remove speces
        if (color == Piece.White)
        {
            moveDirection = 1;
        }
        else
        {
            moveDirection = -1;
        }

        if (!hasMoved) // can move 2 spaces if it hasn't moved
        {
            moveLimit = 2;
        }

        for (int moveDistance = 1; moveDistance <= moveLimit; moveDistance++)
        {
            int endFileIndex = currentIndex.file + (moveDirection * moveDistance);
            if (endFileIndex < 8 && endFileIndex >= 0) // check that it's in range
            {
                (char endRank, int endFile) = Move.ToChessNotation(currentIndex.rank, endFileIndex);
                (char startRank, int startFile) = Move.ToChessNotation(
                    currentIndex.rank,
                    currentIndex.file
                );
                legalMoves.Add(new Move(startRank, startFile, endRank, endFile));
            }
            // ADD CAPTURE LOGIC
        }

        return legalMoves;
    }
}
