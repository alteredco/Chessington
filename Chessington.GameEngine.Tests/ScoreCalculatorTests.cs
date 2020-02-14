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
            var bishop = new Bishop(Player.Black);
            var board = A.Fake<IBoard>();
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece> {bishop});
            var scoreCalculator = new ScoreCalculator(board);

            scoreCalculator.GetWhiteScore().Should().Be(3);
        }
    }
}