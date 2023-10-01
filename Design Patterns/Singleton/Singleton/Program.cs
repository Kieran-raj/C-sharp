using Singleton.AmbientContext;
using Singleton.Monostate;
using Singleton.PerThread;
using Singleton.SingletonImplementation;

namespace Singleton
{
    public static class Program
    {
        public static void Main()
        {
            Implementation.Run();
            var ceo = new CEO();
            ceo.Name = "Adam Smith";
            ceo.Age = 55;

            var ceo2 = new CEO();

            PerThreadSingleton.Run();

            // Ambient Context
            var house = new Buidling();

            using (new BuildingContext(3000))
            {
                house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
                house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));

                using (new BuildingContext(3500))
                {
                    house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
                    house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
                }

                house.Walls.Add(new Wall(new Point(5000, 0), new Point(5000, 4000)));
            }

            Console.WriteLine(house);
        }
    }
}
