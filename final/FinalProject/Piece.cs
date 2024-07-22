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
    protected (int, int) currentIndex; // array index on the chess board

    public Piece(string pieceType, (int, int) startIndex)
    {
        this.pieceType = pieceType;
        currentIndex = startIndex;
        hasMoved = false;
    }

    public bool HasMoved()
    {
        return hasMoved;
    }

    public bool MovePiece(Move move) // returns true only if it's legal and successfully moved
    {
        if (this.LegalMoves().Contains(move))
        {
            currentIndex = move.GetEndIndex();
            hasMoved = true;
            return true;
        }
        return false;
    }

    public abstract List<Move> LegalMoves(); // gives a list of legal moves. defined by piece

    public string GetPieceType()
    {
        return pieceType;
    }
}
