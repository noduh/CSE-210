public class Queen : Piece
{
    public Queen(string color, (int, int) startIndex)
        : base(Queen, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
