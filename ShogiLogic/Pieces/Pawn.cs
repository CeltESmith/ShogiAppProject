using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShogiLogic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        private readonly Direction forward;

        public Pawn(Player color)
        {
            Color = color;

            if (color == Player.White)
            {
                forward = Direction.North;
            }
            else if(color == Player.Black)
            {
                forward = Direction.South;
            }
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private bool CanMoveTo(Position pos, Board board)
        {
            return Board.IsInside(pos) && board.IsEmpty(pos) || board[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMove(Position from, Board board)
        {
            Position move = from + forward;

            if (CanMoveTo(move, board))
            {
                yield return new NormalMove(from, move);
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMove(from, board);
        }
    }
}
