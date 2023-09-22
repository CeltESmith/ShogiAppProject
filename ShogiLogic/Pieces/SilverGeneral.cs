using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiLogic.Pieces
{
    public class SilverGeneral : Piece
    {
        public override PieceType Type => PieceType.SilverGeneral;
        public override Player Color { get; }

        private static Direction[] dirs;

        public SilverGeneral(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            SilverGeneral copy = new SilverGeneral(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            if (Color == Player.White)
            {
                dirs = new Direction[]
                {
                    Direction.North,
                    Direction.NorthEast,
                    Direction.NorthWest,
                    Direction.SouthEast,
                    Direction.SouthWest
                };
                foreach (Direction dir in dirs)
                {
                    Position to = from + dir;

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

            else if (Color == Player.Black)
            {
                dirs = new Direction[]
                {
                    Direction.South,
                    Direction.SouthWest,
                    Direction.SouthEast,
                    Direction.NorthEast,
                    Direction.NorthWest
                };
                foreach (Direction dir in dirs)
                {
                    Position to = from + dir;

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
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach (Position to in MovePositions(from, board))
            {
                yield return new NormalMove(from, to);
            }
        }
    }
}
