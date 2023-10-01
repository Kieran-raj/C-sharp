namespace Singleton.AmbientContext
{
    public struct Point
    {
        private int x, y;

        public Point(int x, int y)
        {
            this.y = y;
            this.x = x;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

    }
    public class Wall
    {
        public Point Start, End;
        public int Height;

        public Wall(Point start, Point end)
        {
            Start = start;
            End = end;
            Height = BuildingContext.Current.WallHeight;
        }

        public override string ToString()
        {
            return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}" + $" {nameof(Height)}, {Height}";
        }
    }
}