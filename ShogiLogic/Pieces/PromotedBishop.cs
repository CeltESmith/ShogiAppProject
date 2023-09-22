using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiLogic.Pieces
{
    public class PromotedBishop : Piece
    {
        public override PieceType Type => PieceType.PromotedBishop;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.NorthEast,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest
        };
        private static readonly Direction[] dir = new Direction[]
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West
        };

        public PromotedBishop(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            PromotedBishop copy = new PromotedBishop(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            foreach (Direction di in dir)
            {
                Position to = from + di;

                if (!Board.IsInside(to))
                {
                    continue;
                }

                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to)); 
        }
    }
}
