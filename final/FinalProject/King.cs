public class King : Piece
{
    public King(string color, (int, int) startIndex)
        : base(King, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        List<Move> legalMoves = new List<Move>();
        (char startRank, int startFile) = Move.ToChessNotation(
            currentIndex.rank,
            currentIndex.file
        );
        legalMoves.Add(new Move(startRank, startFile, (char)(startRank + 1), startFile + 1)); // up right
        legalMoves.Add(new Move(startRank, startFile, (char)(startRank + 1), startFile)); // right
        legalMoves.Add(new Move(startRank, startFile, (char)(startRank + 1), startFile - 1)); // down right
        legalMoves.Add(new Move(startRank, startFile, startRank, startFile - 1)); // down
        legalMoves.Add(new Move(startRank, startFile, (char)(startRank - 1), startFile - 1)); // down left
        legalMoves.Add(new Move(startRank, startFile, (char)(startRank - 1), startFile)); // left
        legalMoves.Add(new Move(startRank, startFile, (char)(startRank - 1), startFile + 1)); // up left
        legalMoves.Add(new Move(startRank, startFile, startRank, startFile + 1)); // up

        return legalMoves;
    }
}
