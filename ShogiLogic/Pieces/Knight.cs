using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiLogic.Pieces
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override Player Color { get; }

        public Knight(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> PotentialToPositions(Position from)
        {
            if (Color == Player.White)
            {
                foreach (Direction vDir in new Direction[] { Direction.North })
                {
                    foreach (Direction hDir in new Direction[] { Direction.East, Direction.West })
                    {
                        yield return from + 2 * vDir + hDir;
                    }
                }
            }

            else if (Color == Player.Black)
            {
                foreach (Direction vDir in new Direction[] { Direction.South })
                {
                    foreach (Direction hDir in new Direction[] { Direction.East, Direction.West })
                    {
                        yield return from + 2 * vDir + hDir;
                    }
                }
            }
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            return PotentialToPositions(from).Where(pos => Board.IsInside(pos) && (board.IsEmpty(pos) || board[pos].Color != Color));
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositions(from, board).Select(to => new NormalMove(from, to));
        }
    }
}
