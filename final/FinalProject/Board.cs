using System.Security;
using System.Xml;

public class Board
{
    private Piece[,] board = new Piece[8, 8];
    private List<Piece> capturedPieces;
    private (User white, User black) players = (null, null);
    private string colorTurn;

    public Board()
    {
        int whitePieceFileIndex = 0;
        int blackPieceFileIndex = 7;
        for (int x = 0; x < 8; x++) // place pawns
        {
            board[x, 1] = new Pawn(Piece.White, (x, 1)); // white pawns on file 2
            board[x, 6] = new Pawn(Piece.Black, (x, 6)); // black pawns on file 7
        }

        // place rooks
        board[0, whitePieceFileIndex] = new Rook(Piece.White, (0, whitePieceFileIndex));
        board[7, whitePieceFileIndex] = new Rook(Piece.White, (7, whitePieceFileIndex));
        board[0, blackPieceFileIndex] = new Rook(Piece.Black, (0, blackPieceFileIndex));
        board[7, blackPieceFileIndex] = new Rook(Piece.Black, (0, blackPieceFileIndex));

        // place bishops
        board[1, whitePieceFileIndex] = new Bishop(Piece.White, (1, whitePieceFileIndex));
        board[6, whitePieceFileIndex] = new Bishop(Piece.White, (6, whitePieceFileIndex));
        board[1, blackPieceFileIndex] = new Bishop(Piece.Black, (1, blackPieceFileIndex));
        board[6, blackPieceFileIndex] = new Bishop(Piece.Black, (6, blackPieceFileIndex));

        // place knights
        board[2, whitePieceFileIndex] = new Knight(Piece.White, (2, whitePieceFileIndex));
        board[5, whitePieceFileIndex] = new Knight(Piece.White, (5, whitePieceFileIndex));
        board[2, blackPieceFileIndex] = new Knight(Piece.Black, (2, blackPieceFileIndex));
        board[5, blackPieceFileIndex] = new Knight(Piece.Black, (5, blackPieceFileIndex));

        // place queens
        board[3, whitePieceFileIndex] = new Queen(Piece.White, (3, whitePieceFileIndex));
        board[3, blackPieceFileIndex] = new Queen(Piece.Black, (3, blackPieceFileIndex));

        // place kings
        board[4, whitePieceFileIndex] = new King(Piece.White, (4, whitePieceFileIndex));
        board[4, blackPieceFileIndex] = new King(Piece.Black, (4, blackPieceFileIndex));

        // start game with white
        colorTurn = User.White;
    }

    public bool AddPlayer(User user) // make the user a player and put them in the tuple
    {
        if (user.IsPlayer())
        {
            return false;
        }
        if (players.white == null)
        {
            user.BecomePlayer(User.White);
            players.white = user;
            return true;
        }
        if (players.black == null)
        {
            user.BecomePlayer(User.Black);
            players.black = user;
            return true;
        }
        return false;
    }

    public User WhosTurn()
    {
        if (colorTurn == User.White)
        {
            return players.white;
        }
        return players.black;
    }

    public (User, User) GetPlayers()
    {
        return players;
    }

    public Piece GetPiece(int rankIndex, int fileIndex)
    {
        return board[rankIndex, fileIndex];
    }

    public Piece GetPiece(char rank, int file)
    {
        (int rankIndex, int fileIndex) = Move.ToIndex(rank, file);
        return GetPiece(rankIndex, fileIndex);
    }

    public bool TakeTurn(User player, Move move) // returns true if move is allowed and completed
    {
        // currently this doesn't check if they've jumped over pieces. this will be implemented in each Piece
        // some if not all pieces can currently move to their own spot. fix in each Piece

        bool captureHappened = false;

        // handle turn check
        if (player != WhosTurn()) // only move if it's their turn
        {
            return false;
        }

        (int startRank, int startFile) = move.GetStartIndex();
        (int endRank, int endFile) = move.GetEndIndex();

        // own pieces check
        Piece movingPiece = GetPiece(startRank, startFile);
        if (movingPiece.GetColor() != player.GetSide()) // only move if it's their piece
        {
            return false;
        }

        // handle captures
        Piece capturedPiece = GetPiece(endRank, endFile); // used in the case of a capture
        if (capturedPiece != null) // check for and handle capture
        {
            // FIX PAWNS
            if (capturedPiece.GetColor() == player.GetSide()) // dont capture your own stuff
            {
                return false;
            }

            captureHappened = true;
        }

        // handle movement
        if (movingPiece.MovePiece(move)) // MovePiece returns false if it's not a legal move
        {
            if (captureHappened) // record the capture
            {
                capturedPieces.Add(capturedPiece);
            }

            // move
            board[startRank, startFile] = null;
            board[endRank, endFile] = movingPiece;
        }

        return false; // returns false if the move failed
    }
}
