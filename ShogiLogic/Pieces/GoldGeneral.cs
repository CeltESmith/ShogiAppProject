using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiLogic.Pieces
{
    public class GoldGeneral : Piece
    {
        public override PieceType Type => PieceType.GoldGeneral;
        public override Player Color { get; }

        private static Direction[] dirs;

        public GoldGeneral(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            GoldGeneral copy = new GoldGeneral(Color);
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
                    Direction.East,
                    Direction.West,
                    Direction.South
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
                    Direction.East,
                    Direction.West,
                    Direction.North
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
