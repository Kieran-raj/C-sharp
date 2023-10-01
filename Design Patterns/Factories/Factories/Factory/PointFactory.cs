using Factories.FactoryMethod;

namespace Factories.Factory
{
    public class PointFactory
    {
        public static Point NewCatesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
}
