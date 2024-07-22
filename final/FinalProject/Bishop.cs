public class Bishop : Piece
{
    public Bishop(string color, (int, int) startIndex)
        : base(Bishop, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
