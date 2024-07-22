public class Rook : Piece
{
    public Rook(string color, (int, int) startIndex)
        : base(Rook, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
