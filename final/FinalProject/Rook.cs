public class Rook : Piece
{
    public Rook(string color, (int, int) startIndex)
        : base(Rook, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        List<Move> legalMoves = new List<Move>();
        (char startRank, int startFile) = Move.ToChessNotation(
            currentIndex.rank,
            currentIndex.file
        );

        for (char rank = 'A'; rank <= 'H'; rank++) // rank moves
        {
            legalMoves.Add(new Move(startRank, startFile, rank, startFile));
        }

        for (int file = 1; file <= 8; file++) // file moves
        {
            legalMoves.Add(new Move(startRank, startFile, startRank, file));
        }

        return legalMoves;
    }
}
