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
           // IEnumerable<Square> sq=Enumerable.Empty<Square>();
           List<Square> sq=new List<Square>();
            Boolean canMove = true;
            Boolean hasMoved = false;

            canMove=CanPawnMoveForward(pawnPosition.Row,pawnPosition.Col,this.Player,board);
            if (canMove)
            {
              
               // sq= new Square[]{newSquare};
               if (this.Player == Player.Black)
               {
                   sq.Add(AddNewSquare(this.Player, pawnPosition.Row, pawnPosition.Col));
               }
               if (this.Player == Player.White)
               {
                   sq.Add(AddNewSquare(this.Player, pawnPosition.Row, pawnPosition.Col));
               }
            }

         /*   if (this.Player == Player.Black)
            {
                if (pawnPosition.Row == 1)
                {
                    canMove=CanPawnMoveForward(pawnPosition.Row+1,pawnPosition.Col,this.Player,board);
                    if (canMove)
                    {
              
                        // sq= new Square[]{newSquare};
                        sq.Add(AddNewSquare(this.Player,pawnPosition.Row+1 ,pawnPosition.Col));
                    }
                }
            }

            if (this.Player == Player.White)
            {
                if (pawnPosition.Row == 7)
                {
                    canMove=CanPawnMoveForward(pawnPosition.Row-1,pawnPosition.Col,this.Player,board);
                    if (canMove)
                    {
              
                        // sq= new Square[]{newSquare};
                        sq.Add(AddNewSquare(this.Player,pawnPosition.Row-1 ,pawnPosition.Col));
                    }
                }
            }
*/
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

        private Square AddNewSquare(Player p,int row,int col)
        {
            Square newSquare=new Square();
                
            if (p  == Player.Black)
            {    // newSquare = CreateNewSquare(row+1, col);
            newSquare=new Square(row+1,col);
            }
            if (p == Player.White)
            {    //newSquare = CreateNewSquare(row-1, row);
                newSquare=new Square(row-1,col);
            }

            return newSquare;
        }
        private Boolean CanPawnMoveForward(int row, int col,Player player,Board board)
        {
            Boolean canMove = false;
       
            if (player == Player.Black)
            {
                /*if (currentPawn.Row == 1) //checking for first move
                {
                    if (!IsSquareOccupied(currentPawn.Row + 2, currentPawn.Col, board))
                    {
                        canMove = true;
                    }
                }
                else
                {*/
                    if (!IsSquareOccupied(row + 1, col, board))
                    {
                        canMove = true;
                    } 
              //  }

              
            }
            if (player == Player.White)
            {
              /*  if (currentPawn.Row == 7) //checking for first move
                {
                    if (!IsSquareOccupied(currentPawn.Row - 2, currentPawn.Col, board))
                    {
                        canMove = true;
                    }
                }
                else
                {*/
                    if (!IsSquareOccupied(row - 1, col, board))
                    {
                        canMove = true;
                    }
            //    }
               
             
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
            Square newSquare=new Square(row,col);
            Square occupiedSquare=new Square(row,col);
            Piece presentPiece = board.GetPiece(newSquare);
            if (presentPiece is null)
            {
                sqOccuped = false;
            }
            else
            {
                sqOccuped = true;
            }
          /*  foreach (var piece in board.CapturedPieces)
            {
                Square capturedSquare = board.FindPiece(piece);
                if (capturedSquare.Col == col && capturedSquare.Row == row)
                {
                    sqOccuped = true;
                    break;
                }
            }*/

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