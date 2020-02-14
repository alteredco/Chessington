﻿using System;
 using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square rookPosition = board.FindPiece(this);
            List<Square> availableSqs = new List<Square>();

            Boolean canMove = false;
            int row = rookPosition.Row;
            int col = rookPosition.Col;
               
            while (row < 7)
            {
                
                canMove = false;
                canMove = CanRookMoveSouth(row + 1, rookPosition.Col, board);
                if (canMove)
                {
                    Square newSquare = new Square(row+1, rookPosition.Col);
                    availableSqs.Add(newSquare);
                 
                }
                else
                {
                    break;
                }
                row++; 
            }
            row = rookPosition.Row;
            while (row > 0)
            {
                canMove = CanRookMoveNorth(row - 1, rookPosition.Col, board);
                if (canMove)
                {
                    Square newSquare = new Square(row-1, rookPosition.Col);
                    availableSqs.Add(newSquare);
                 
                }
                else
                {
                    break;
                }
                row--; 
            }
            row = rookPosition.Row;
            while (col < 7)
            {
                
                canMove = false;
                canMove = CanRookMoveRight(row, col+1, board);
                if (canMove)
                {
                    Square newSquare = new Square(row, col+1);
                    availableSqs.Add(newSquare);
                 
                }
                else
                {
                    break;
                }
                col++; 
            }

            col = rookPosition.Col;
            while (col > 0)
            {
                canMove = CanRookMoveLeft(row, col-1, board);
                if (canMove)
                {
                    Square newSquare = new Square(row, col-1);
                    availableSqs.Add(newSquare);
                 
                }
                else
                {
                    break;
                }
                col--; 
            }

            return availableSqs;
        }

        private Boolean CanRookMoveSouth(int row, int col, Board board)
        {
            Boolean canMove = false;

            if (!IsSquareOccupied(row, col, board))
            {
                canMove = true;
            }

            return canMove;
        }
        
        private Boolean CanRookMoveNorth(int row, int col, Board board)
        {
            Boolean canMove = false;

            if (!IsSquareOccupied(row, col, board))
            {
                canMove = true;
            }

            return canMove;
        }

        private Boolean CanRookMoveLeft(int row, int col, Board board)
        {
            Boolean canMove = false;

            if (!IsSquareOccupied(row, col, board))
            {
                canMove = true;
            }

            return canMove;
        }
        
        private Boolean CanRookMoveRight(int row, int col, Board board)
        {
            Boolean canMove = false;

            if (!IsSquareOccupied(row, col, board))
            {
                canMove = true;
            }

            return canMove;
        }

        private Boolean IsSquareOccupied(int row, int col, Board board)
        {
            Boolean sqOccuped = false;
            Square newSquare = new Square(row, col);
            Square occupiedSquare = new Square(row, col);
            Piece presentPiece = board.GetPiece(newSquare);
            if (presentPiece is null)
            {
                sqOccuped = false;
            }
            else
            {
                sqOccuped = true;
            }

            return sqOccuped;
        }
    }
}