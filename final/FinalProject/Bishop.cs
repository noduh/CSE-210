public class Bishop : Piece
{
    public Bishop((int, int) startIndex)
        : base(Bishop, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
