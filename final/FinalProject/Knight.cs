public class Knight : Piece
{
    public Knight((int, int) startIndex)
        : base(Knight, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
