using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShogiLogic.Pieces
{
    public class Lance : Piece
    {
        public override PieceType Type => PieceType.Lance;
        public override Player Color { get; }

        private readonly Direction[] dirs;

        public Lance(Player color)
        {
            Color = color;

            if (color == Player.White)
            {
                dirs = new Direction[] { Direction.North };
            }
            else if (color == Player.Black)
            {
                dirs = new Direction[] { Direction.South };
            }
        }

        public override Piece Copy()
        {
            Lance copy = new Lance(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
