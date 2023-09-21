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
    }
}
