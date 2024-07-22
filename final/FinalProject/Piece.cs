public abstract class Piece
{
    // types of pieces
    public const string Pawn = "pawn";
    public const string Rook = "rook";
    public const string Knight = "knight";
    public const string Bishop = "bishop";
    public const string King = "king";
    public const string Queen = "queen";

    protected string pieceType;
    protected bool hasMoved;

    public Piece(string pieceType)
    {
        this.pieceType = pieceType;
        hasMoved = false;
    }

    public bool HasMoved()
    {
        return hasMoved;
    }

    public void Move() // makes sure the game knows the piece has moved
    {
        hasMoved = true;
    }

    public abstract List<Move> LegalMoves(); // gives a list of legal moves. defined by piece
}
