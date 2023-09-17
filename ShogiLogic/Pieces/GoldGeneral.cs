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
    }
}
