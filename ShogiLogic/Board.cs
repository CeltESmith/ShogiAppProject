using ShogiLogic.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiLogic
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[9, 9];

        public Piece this[int rowY, int colX]
        {
            get { return pieces[rowY, colX];}
            set { pieces[rowY, colX] = value; }
        }

        public Piece this[Position pos]
        {
            get { return this[pos.RowY, pos.ColumnX]; }
            set { this[pos.RowY, pos.ColumnX] = value; }
        }

        public static Board Initial()
        {
            Board board = new Board();
            board.AddStartPieces();
            return board;
        }

        private void AddStartPieces()
        {
            this[0, 0] = new Lance(Player.Black);
            this[0, 1] = new Knight(Player.Black);
            this[0, 2] = new SilverGeneral(Player.Black);
            this[0, 3] = new GoldGeneral(Player.Black);
            this[0, 4] = new King(Player.Black);
            this[0, 5] = new GoldGeneral(Player.Black);
            this[0, 6] = new SilverGeneral(Player.Black);
            this[0, 7] = new Knight(Player.Black);
            this[0, 8] = new Lance(Player.Black);
            this[1, 1] = new Rook(Player.Black);
            this[1, 7] = new Bishop(Player.Black);

            this[7, 1] = new Bishop(Player.White);
            this[7, 7] = new Rook(Player.White);
            this[8, 0] = new Lance(Player.White);
            this[8, 1] = new Knight(Player.White);
            this[8, 2] = new SilverGeneral(Player.White);
            this[8, 3] = new GoldGeneral(Player.White);
            this[8, 4] = new King(Player.White);
            this[8, 5] = new GoldGeneral(Player.White);
            this[8, 6] = new SilverGeneral(Player.White);
            this[8, 7] = new Knight(Player.White);
            this[8, 8] = new Lance(Player.White);

            for (int c = 0; c < 9; c++)
            {
                this[2, c] = new Pawn(Player.Black);
                this[6, c] = new Pawn(Player.White);
            }
        }

        public static bool IsInside(Position pos)
        {
            return pos.RowY >= 0 && pos.RowY < 9 && pos.ColumnX >= 0 && pos.ColumnX < 9;
        }

        public bool IsEmpty(Position pos)
        {
            return this[pos] == null;
        }
    }
}
