namespace Factories.FactoryMethod
{
    public class Point
    {
        private double X;
        private double Y;

        public static Point NewCatesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho*Math.Cos(theta), rho*Math.Sin(theta));
        }

        public Point(double x, double y)
        {
            this.Y = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}
