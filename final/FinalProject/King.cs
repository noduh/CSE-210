public class King : Piece
{
    public King((int, int) startIndex)
        : base(King, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
