public abstract class Piece
{
    // types of pieces
    public const string Pawn = "pawn";
    public const string Rook = "Rook";
    public const string Knight = "kNight";
    public const string Bishop = "Bishop";
    public const string King = "King";
    public const string Queen = "Queen";
    public const string Black = "black";
    public const string White = "white";

    protected string pieceType;
    protected bool hasMoved;
    protected (int, int) currentIndex; // array index on the chess board
    protected string color;

    public Piece(string pieceType, string color, (int, int) startIndex)
    {
        this.pieceType = pieceType;
        currentIndex = startIndex;
        hasMoved = false;
        this.color = color;
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

    public override string ToString()
    {
        return pieceType[0].ToString() + pieceType[1].ToString();
    }

    public string GetColor()
    {
        return color;
    }
}
