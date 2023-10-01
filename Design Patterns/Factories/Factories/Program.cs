using Factories.AbstractFactory;
using Factories.Exercise;
using Factories.Factory;
using Factories.FactoryMethod;
using Factories.ObjectTrackingAndBulkReplacement;

namespace Factories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var point = Point.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);

            //var x = await Foo.CreateAsync();
            //Console.WriteLine(x);

            var newPoint = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);

            var factory = new TrackingThemeFactory();
            var theme1 = factory.CreateTheme(false);
            var theme2 = factory.CreateTheme(true); 
            Console.WriteLine(factory.Info);

            var factory2 = new ReplaceableThemeFactory();
            var magicTheme = factory2.createTheme(true);
            Console.WriteLine(magicTheme.Value.BgrColor);

            factory2.ReplaceTheme(false);
            Console.WriteLine(magicTheme.Value.BgrColor);

            var hotDrinkMachine = new HotDrinkMachine();
            //var drink = hotDrinkMachine.MakeDrink(HotDrinkMachine.AvailabeDrink.Tea, 100);
            //drink.Consume();

            var drink = hotDrinkMachine.MakeDrink();

            Console.WriteLine("Person Factory");
            var personFactory = new PersonFactory();
            var person = personFactory.CreatePerson("Kieran");
            var person2 = personFactory.CreatePerson("Jessica");
            Console.WriteLine(person);
            Console.WriteLine(person2);
        }
    }
}