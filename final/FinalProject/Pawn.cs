public class Pawn : Piece
{
    public Pawn((int, int) startIndex)
        : base(Pawn, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
