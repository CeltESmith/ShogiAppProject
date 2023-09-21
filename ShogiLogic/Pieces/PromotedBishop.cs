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
    }
}
