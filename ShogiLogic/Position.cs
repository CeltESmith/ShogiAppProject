namespace ShogiLogic
{
    public class Position
    {
        public int RowY { get; }
        public int ColumnX { get; }

        public Position(int rowY, int columnX)
        {
            RowY = rowY;
            ColumnX = columnX;
        }

        public Player SquareColor()
        {
            if ((RowY +ColumnX) % 2 == 0)
            {
                return Player.White;
            }
            return Player.Black;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   RowY == position.RowY &&
                   ColumnX == position.ColumnX;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RowY, ColumnX);
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        public static Position operator + (Position pos, Direction dir)
        {
            return new Position(pos.RowY + dir.RowYDelta, pos.ColumnX + dir.ColumnXDelta);
        }
    }
}
