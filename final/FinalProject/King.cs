public class King : Piece
{
    public King(string color, (int, int) startIndex)
        : base(King, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
