public class Rook : Piece
{
    public Rook((int, int) startIndex)
        : base(Rook, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
