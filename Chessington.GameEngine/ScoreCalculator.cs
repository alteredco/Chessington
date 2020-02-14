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
            // Should add up the value of all of the pieces that white has taken.
            return 0;
        }

        public int GetBlackScore()
        {
            var score = 0;
            // Should add up the value of all of the pieces that black has taken.
            foreach (var piece in _board.CapturedPieces)
            {
                if (piece is Rook)
                {
                    score += 5;
                }
            }
            return score;
        }
    }
}