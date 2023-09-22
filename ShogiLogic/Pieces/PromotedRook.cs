using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiLogic.Pieces
{
    public class PromotedRook : Piece
    {
        public override PieceType Type => PieceType.PromotedRook;
        public override Player Color { get; }

        private readonly Direction[] dirs = new Direction[]
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West
        };
        private readonly Direction[] dir = new Direction[]
        {
            Direction.NorthEast,
            Direction.SouthEast,
            Direction.SouthWest,
            Direction.NorthWest
        };

        public PromotedRook(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            PromotedRook copy = new PromotedRook(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> MovePositions(Position from, Board board, Direction dirs)
        {
            for (Position pos = from + dirs; Board.IsInside(pos); pos += dirs)
            {
                if (board.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }

                Piece piece = board[pos];

                if (piece.Color != Color)
                {
                    yield return pos;
                }
            }

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
