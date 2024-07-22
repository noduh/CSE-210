public class Queen : Piece
{
    public Queen((int, int) startIndex)
        : base(Queen, startIndex) { }

    public override List<Move> LegalMoves()
    {
        throw new NotImplementedException();
    }
}
