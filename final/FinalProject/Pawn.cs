public class Pawn : Piece
{
    public Pawn(string color, (int, int) startIndex)
        : base(Pawn, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
