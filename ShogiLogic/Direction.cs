namespace ShogiLogic
{
    public class Direction
    {
        public readonly static Direction North = new Direction(-1, 0);
        public readonly static Direction South = new Direction(1, 0);
        public readonly static Direction West = new Direction(0, -1);
        public readonly static Direction East = new Direction(0, 1);
        public readonly static Direction NorthEast = North + East;
        public readonly static Direction NorthWest = North + West;
        public readonly static Direction SouthEast = South + East;
        public readonly static Direction SouthWest = South + West;

        public int RowYDelta { get; }
        public int ColumnXDelta { get; }

        public Direction (int rowYDelta, int columnXDelta)
        {
            RowYDelta = rowYDelta;
            ColumnXDelta = columnXDelta;
        }

        public static Direction operator +(Direction dir1, Direction dir2)
        {
            return new Direction(dir1.RowYDelta + dir2.RowYDelta, dir1.ColumnXDelta + dir2.ColumnXDelta);
        }

        public static Direction operator * (int scalar, Direction dir)
        {
            return new Direction(scalar * dir.RowYDelta, scalar * dir.ColumnXDelta);
        }
    }
}
