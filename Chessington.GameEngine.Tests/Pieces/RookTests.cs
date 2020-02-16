﻿using System.Linq;
 using Chessington.GameEngine.Pieces;
 using FluentAssertions;
 using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    
    public class RookTests
    {
        private Board _board;
        
        [SetUp]
        public void SetUp(){
        _board =  new Board();
        }
        
        [Test]

        public void Rook_CanMoveForward()
        {
            var rook = new Rook(Player.Black);
            _board.AddPiece(Square.At(2, 5), rook);

            var moves = rook.GetAvailableMoves(_board);
            moves.Should().Contain(Square.At(3, 5));
            moves.Should().Contain(Square.At(4, 5));
            moves.Should().Contain(Square.At(5, 5));
            moves.Should().Contain(Square.At(6, 5));
            moves.Should().Contain(Square.At(7, 5));
        }

        [Test]

        public void Rook_CanMoveBackward()
        {
            var rook = new Rook(Player.Black);
            _board.AddPiece(Square.At(5,2), rook);

            var moves = rook.GetAvailableMoves(_board);
            moves.Should().Contain(Square.At(4, 2));
            moves.Should().Contain(Square.At(3, 2));
            moves.Should().Contain(Square.At(2, 2));
            moves.Should().Contain(Square.At(1, 2));
            moves.Should().Contain(Square.At(0, 2));
        }
        [Test]
        public void Rook_CanMoveLeft()
        {
            var rook = new Rook(Player.Black);
            _board.AddPiece(Square.At(2,2), rook);

            var moves = rook.GetAvailableMoves(_board);
            moves.Should().Contain(Square.At(2, 1));
            moves.Should().Contain(Square.At(2, 0));
        }
        
        [Test]
        public void Rook_CanMoveRight()
        {
            var rook = new Rook(Player.Black);
            _board.AddPiece(Square.At(4,4), rook);

            var moves = rook.GetAvailableMoves(_board);
            moves.Should().Contain(Square.At(4, 5));
            moves.Should().Contain(Square.At(4, 6));
            moves.Should().Contain(Square.At(4, 7));
        }
    }
}