using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class ScoreCalculator
    {
        private IBoard _board;

        public ScoreCalculator(IBoard board)
        {
            _board = board;
        }

        public int GetWhiteScore()
        {
            var score = 0;
            // Should add up the value of all of the pieces that white has taken.
            foreach (var piece in _board.CapturedPieces)
            {
                score += CalculateScore(piece);
            }
            return score;
        }

        public int GetBlackScore()
        {
            var score = 0;
            // Should add up the value of all of the pieces that black has taken.
            foreach (var piece in _board.CapturedPieces)
            {
                score += CalculateScore(piece);
            }
            return score;
        }

        public int CalculateScore(Piece piece)
        {
            var score = 0;
            if (piece is Pawn)
            {
                score += 1;
            }
            if(piece is Bishop || piece is Knight)
            {
                score += 3;
            }
            if (piece is Rook)
            {
                score += 5;
            }

            if (piece is Queen)
            {
                score += 9;
            }

            return score;
        }
        
    }
}