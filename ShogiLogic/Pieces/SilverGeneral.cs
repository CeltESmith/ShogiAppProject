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
    }
}
