using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests
{
    public class ScoreCalculatorTests
    {
        [Test]

        public void ScoreCalculatorTest()
        {
            var rook = new Rook(Player.Black);
            var board = A.Fake<IBoard>();
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece> {rook});
            var scoreCalculator = new ScoreCalculator(board);

            scoreCalculator.GetBlackScore().Should().Be(5);
        }
    }
}