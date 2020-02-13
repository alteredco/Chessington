﻿using System;
 using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square pawnPosition = board.FindPiece(this);
            IEnumerable<Square> sq=Enumerable.Empty<Square>();
            if (this.Player == Player.Black)
            {
                Square newBlackPosition = new Square(pawnPosition.Row + 1, pawnPosition.Col);
                sq= new Square[]{newBlackPosition };
               
            }
            else
            {
                Square newWhitePosition = new Square(pawnPosition.Row -1, pawnPosition.Col);
                sq= new Square[]{newWhitePosition };
            }
            
          
            return sq;
           // return Enumerable.Empty<Square>();
        }
    }
}