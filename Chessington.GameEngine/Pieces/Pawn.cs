﻿using System;
 using System.Collections.Generic;
 using System.Data.Common;
 using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            //refactored code
            Square pawnPosition = board.FindPiece(this);
            IEnumerable<Square> sq=Enumerable.Empty<Square>();
            Boolean canMove = true;
            Boolean hasMoved = false;

            canMove=CanPawnMoveForward(pawnPosition,this.Player,board);
            if (canMove)
            {
                Square newSquare=new Square();
                if (this.Player == Player.Black)
                {     newSquare = CreateNewSquare(pawnPosition.Row + 1, pawnPosition.Col);
                }
                if (this.Player == Player.White)
                {    newSquare = CreateNewSquare(pawnPosition.Row - 1, pawnPosition.Col);
                }
                sq= new Square[]{newSquare};
            }

            return sq;
             /*
            if (this.Player == Player.Black)
            {
                if (pawnPosition.Row == 1)
                {
                    hasMoved = false;
                    sq = CreateSquareList(pawnPosition.Row,pawnPosition.Col,'+',"forward");
                    var plusOneBlackPosition = CreateNewSquare(pawnPosition.Row + 1, pawnPosition.Col);
                    var plusTwoBlackPosition = CreateNewSquare(pawnPosition.Row + 2, pawnPosition.Col); 
                    
                    var squareLeft = CreateNewSquare(pawnPosition.Row + 1, pawnPosition.Col-1);
                    var squareRight = CreateNewSquare(pawnPosition.Row + 1, pawnPosition.Col+1); 
                    canMove=CanPiecesBeMoved(board,pawnPosition,plusOneBlackPosition,plusTwoBlackPosition);
                    if (!canMove)
                    {
                      sq=Enumerable.Empty<Square>();
                    }

                    canMove = CanMoveDiagonally(board, pawnPosition, squareLeft, squareRight);
                    sq=CreateSquareList(pawnPosition.Row,pawnPosition.Col,'+',"diagonal");
                    if (!canMove)
                    {
                        sq=Enumerable.Empty<Square>();
                    }
                }
                else{
                    
                   var plusOneBlackPosition =  CreateNewSquare(pawnPosition.Row + 1, pawnPosition.Col);
                    sq= new Square[]{plusOneBlackPosition};
                    
                /*  sq = CreateSquareList(pawnPosition.Row,pawnPosition.Col,'+',"forward");
                  var plusOneBlackPosition = CreateNewSquare(pawnPosition.Row + 1, pawnPosition.Col);
                  var plusTwoBlackPosition = CreateNewSquare(pawnPosition.Row + 2, pawnPosition.Col); 
                    
                  var squareLeft = CreateNewSquare(pawnPosition.Row + 1, pawnPosition.Col-1);
                  var squareRight = CreateNewSquare(pawnPosition.Row + 1, pawnPosition.Col+1); 
                  canMove=CanPiecesBeMoved(board,pawnPosition,plusOneBlackPosition,plusTwoBlackPosition);
                  if (!canMove)
                  {
                      sq=Enumerable.Empty<Square>();
                  }

                  canMove = CanMoveDiagonally(board, pawnPosition, squareLeft, squareRight);
                  sq=CreateSquareList(pawnPosition.Row,pawnPosition.Col,'+',"diagonal");
                  if (!canMove)
                  {
                      sq=Enumerable.Empty<Square>();
                  }
                }
            }
            else if (this.Player == Player.White)
            {
                if (pawnPosition.Row == 7)
                {
                    sq = CreateSquareList(pawnPosition.Row,pawnPosition.Col,'-',"forward");
                    var plusOneBlackPosition = CreateNewSquare(pawnPosition.Row - 1, pawnPosition.Col);
                    var plusTwoBlackPosition = CreateNewSquare(pawnPosition.Row - 2, pawnPosition.Col);
                    canMove=CanPiecesBeMoved(board,pawnPosition,plusOneBlackPosition,plusTwoBlackPosition);
                    if (!canMove)
                    {
                        sq=Enumerable.Empty<Square>();
                    }
                
                }
                else{
                    
                    var plusOneBlackPosition = CreateNewSquare(pawnPosition.Row - 1, pawnPosition.Col);
                    sq= new Square[]{plusOneBlackPosition};
                }
            }
*/
            return sq;
           // return Enumerable.Empty<Square>();
        }

        private Boolean CanPawnMoveForward(Square currentPawn,Player player,Board board)
        {
            Boolean canMove = false;
       
            if (player == Player.Black)
            {
                canMove = IsSquareOccupied(currentPawn.Row+1, currentPawn.Col, board);
            }
            if (player == Player.White)
            {
                canMove = IsSquareOccupied(currentPawn.Row-1, currentPawn.Col, board);
            }
          

            return canMove;

        }
        private Square CreateNewSquare(int rPos,int cPos)
        {
            Square newSquare=new Square(rPos,cPos);
            return newSquare;
        }

        private IEnumerable<Square> CreateSquareList(int row,int col,char operation,string movement)
        {
            IEnumerable<Square> sq=Enumerable.Empty<Square>();
            if (operation == '+')
            {
                if (movement == "forward")
                {
                    var plusOneBlackPosition = CreateNewSquare(row + 1, col);
                    var plusTwoBlackPosition = CreateNewSquare(row + 2, col);  
                    sq= new Square[]{plusOneBlackPosition, plusTwoBlackPosition};
                }
                else
                {
                    var plusOneBlackPosition = CreateNewSquare(row + 1, col-1);
                    var plusTwoBlackPosition = CreateNewSquare(row + 1, col+1);  
                    sq= new Square[]{plusOneBlackPosition, plusTwoBlackPosition};
                }
                
               
            }
            if (operation == '-')
            {
                var plusOneBlackPosition = CreateNewSquare(row - 1, col);
                var plusTwoBlackPosition = CreateNewSquare(row -2, col);     
                sq= new Square[]{plusOneBlackPosition, plusTwoBlackPosition};
            }

            return sq;
        }
        
        private Boolean CanMoveDiagonally(Board board,Square currentPos,Square one,Square two)
        {
            Boolean canMove = false;
            IEnumerable<Square> sq=Enumerable.Empty<Square>();
            foreach (var piece in board.CapturedPieces)
            {
                Square capturedSquare = board.FindPiece(piece);
             
                if ((currentPos.Row + 1 == capturedSquare.Row) && (currentPos.Col - 1) == capturedSquare.Col)
                {
                    canMove = true;
                }
                if ((currentPos.Row + 1 == capturedSquare.Row) && (currentPos.Col +1) == capturedSquare.Col)
                {
                    canMove = true;
                }
            }
              
         
            return canMove;
        }

        private Boolean IsSquareOccupied(int row,int col,Board board)
        {
            Boolean sqOccuped = false;
            foreach (var piece in board.CapturedPieces)
            {
                Square capturedSquare = board.FindPiece(piece);
                if (capturedSquare.Col == col && capturedSquare.Row == row)
                {
                    sqOccuped = true;
                    break;
                }
            }

            return sqOccuped;
        }
        private Boolean CanPiecesBeMoved(Board board,Square currentPos,Square one,Square two)
        {
          Boolean canMove = true;
            IEnumerable<Square> sq=Enumerable.Empty<Square>();
            foreach (var piece in board.CapturedPieces)
            {
                Square capturedSquare = board.FindPiece(piece);
                if (capturedSquare.Col == one.Col || capturedSquare.Col == two.Col)
                {
                    if (capturedSquare == one || capturedSquare == two)
                    {
                        canMove = false;
                    }
                }
                else
                {
                    if ((currentPos.Row + 1 == capturedSquare.Row) && (currentPos.Col - 1) == capturedSquare.Col)
                    {
                        canMove = true;
                    }
                    if ((currentPos.Row + 1 == capturedSquare.Row) && (currentPos.Col +1) == capturedSquare.Col)
                    {
                        canMove = true;
                    }
                }
              
            }

         
            return canMove;
        }
    }
}