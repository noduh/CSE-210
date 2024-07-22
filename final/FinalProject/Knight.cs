public class Knight : Piece
{
    public Knight(string color, (int, int) startIndex)
        : base(Knight, color, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
