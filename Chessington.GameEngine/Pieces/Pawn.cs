﻿using System;
 using System.Collections.Generic;
 using System.Data.Common;
 using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private List<Square> availableMoves;
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            //refactored code
            Square pawnPosition = board.FindPiece(this);
            List<Square> newSquares=new  List<Square>();
            availableMoves=new List<Square>();
     
            if (((this.Player == Player.Black) && (pawnPosition.Row == 1)) || ((this.Player == Player.White) && (pawnPosition.Row == 7)) )
            {
                GetAvailableTwoSquares(pawnPosition.Row,pawnPosition.Col,this.Player,board);
            }
            else
            {
                GetAvailableSquares(pawnPosition.Row,pawnPosition.Col,this.Player,board);
            }

            //get list of squares available diagonally
             GetAvailableDiagonalSquares(pawnPosition.Row,pawnPosition.Col,this.Player,board);
             
            return availableMoves;
        
        }

        private void GetAvailableTwoSquares(int row,int col,Player p,Board board)
        {
            List<Square> newSquares=CanPawnMoveForward(row,col,p,board);
            AddToAvailableMoves(newSquares);
            if (newSquares.Count > 0)
            {
                newSquares = (p == Player.Black)
                    ? CanPawnMoveForward(row + 1, col, p, board)
                    : CanPawnMoveForward(row - 1, col, p, board);
                AddToAvailableMoves(newSquares);
               
            }
        }

        private void AddToAvailableMoves(List<Square> availableSquares)
        {
            foreach (Square s in availableSquares)
            {
                this.availableMoves.Add(s);
            }
        }
        private void GetAvailableSquares(int row,int col,Player p,Board board)
        {
            List<Square> newSquares=CanPawnMoveForward(row,col,p,board);
            AddToAvailableMoves(newSquares);   
         
        }
        private void GetAvailableDiagonalSquares(int row,int col,Player player,Board board)
        {//get available for diagonal moves
            List<Square> sq1=CanPawnMoveDiagonally(row,col,player,board);
            AddToAvailableMoves(sq1);
         
        }

        private Square AddNewSquare(Player p,int row,int col)
        {
            Square newSquare=new Square(row,col);
            return newSquare;
        }

        private Boolean CanPawnCaptureDiagonalPiece(int row, int col,Player player,Board board)
        {
            Square occupiedSquare=new Square(row,col);
            Piece occupiedPiece = board.GetPiece(occupiedSquare);
            Boolean canCapture;
            canCapture = (occupiedPiece.Player == player) ? true : false;
            return canCapture;
        }
        private List<Square> CanPawnMoveDiagonally(int row, int col,Player player,Board board)
        {
            Boolean canMove = false;
            List<Square> sq=new List<Square>();
       
            if (player == Player.Black)
            {
                sq=CaptureDiagonalPieces(row+1,col,Player.White,board);
                  
             
            }
            if (player == Player.White)
            {
                sq=CaptureDiagonalPieces(row-1,col,Player.Black,board);
             
             
            }
          
            return sq;

        }

        private List<Square> CaptureDiagonalPieces(int row, int col, Player player, Board board)
        { List<Square> sq=new List<Square>();
            if (IsSquareOccupied(row, col-1, board))
            {
                if (CanPawnCaptureDiagonalPiece(row, col - 1, player,board))
                {
                    sq.Add(AddNewSquare(this.Player,row,col-1));
                }
                      
                    
            } 
            if (IsSquareOccupied(row, col+1, board))
            {
                if (CanPawnCaptureDiagonalPiece(row, col + 1, player,board))
                {
                    sq.Add(AddNewSquare(this.Player,row,col+1));
                }
                     
            }

            return sq;
        }

        private List<Square> CanPawnMoveForward(int row, int col,Player player,Board board)
        {
            Boolean canMove = false;
            int forwardRow=0;
            int forwardCol=col;
            List<Square> newSquare=new List<Square>();

            forwardRow = (player == Player.Black) ? row + 1 : row - 1;
            
            canMove = (!IsSquareOccupied(forwardRow, forwardCol, board)) ? true : false;
            if (canMove)
            {
                newSquare.Add(new Square(forwardRow, forwardCol));
            }
            return newSquare;
        }
    
       
        private Boolean IsSquareOccupied(int row,int col,Board board)
        {
          if (row >= 0 && row <= 7 && col >= 0 && col <= 7)
            {
                Square newSquare=new Square(row,col);
                Piece presentPiece = board.GetPiece(newSquare);
                return (presentPiece is null) ? false : true;
            }
           return false;
        }
   }
}