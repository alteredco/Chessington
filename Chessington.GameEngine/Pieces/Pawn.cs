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
                   sq.Add(AddNewSquare(this.Player, pawnPosition.Row+1, pawnPosition.Col));
               }
               if (this.Player == Player.White)
               {
                   sq.Add(AddNewSquare(this.Player, pawnPosition.Row-1, pawnPosition.Col));
               }
            }

            if (this.Player == Player.Black)
            {
                if ((pawnPosition.Row == 1) && (canMove))
                {
                    canMove=CanPawnMoveForward(pawnPosition.Row+1,pawnPosition.Col,this.Player,board);
                    if (canMove)
                    {
              
                        // sq= new Square[]{newSquare};
                        sq.Add(AddNewSquare(this.Player,pawnPosition.Row+2 ,pawnPosition.Col));
                    }
                }
            }

            if (this.Player == Player.White)
            {
                if (pawnPosition.Row == 6 && canMove)
                {
                    canMove=CanPawnMoveForward(pawnPosition.Row-1,pawnPosition.Col,this.Player,board);
                    if (canMove)
                    {
              
                        // sq= new Square[]{newSquare};
                        sq.Add(AddNewSquare(this.Player,pawnPosition.Row-2 ,pawnPosition.Col));
                    }
                }
            }
//checking for diagonal moves are available
           List<Square> sq1=new List<Square>();
            
           
                sq1=CanPawnMoveDiagonally(pawnPosition.Row,pawnPosition.Col,this.Player,board);
                foreach (Square s in sq1)
                {
                    sq.Add(s);
                }
            return sq;
        
        }

        private Square AddNewSquare(Player p,int row,int col)
        {
            Square newSquare=new Square();
                
            if (p  == Player.Black)
            {    // newSquare = CreateNewSquare(row+1, col);
            newSquare=new Square(row,col);
            }
            if (p == Player.White)
            {    //newSquare = CreateNewSquare(row-1, row);
                newSquare=new Square(row,col);
            }

            return newSquare;
        }
        
        private List<Square> CanPawnMoveDiagonally(int row, int col,Player player,Board board)
        {
            Boolean canMove = false;
            List<Square> sq=new List<Square>();
       
            if (player == Player.Black)
            {
             
                if (IsSquareOccupied(row + 1, col-1, board))
                {
                    sq.Add(AddNewSquare(this.Player,row+1 ,col-1));
                } 
                if (IsSquareOccupied(row + 1, col+1, board))
                {
                    sq.Add(AddNewSquare(this.Player,row+1 ,col+1));
                } 
             

              
            }
            if (player == Player.White)
            {
                if (IsSquareOccupied(row -1, col-1, board))
                {
                    sq.Add(AddNewSquare(this.Player,row-1 ,col-1));
                } 
                if (IsSquareOccupied(row -1, col+1, board))
                {
                    sq.Add(AddNewSquare(this.Player,row-1 ,col+1));
                } 
               
             
            }
          

            return sq;

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