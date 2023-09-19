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

        public Lance(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Lance copy = new Lance(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
