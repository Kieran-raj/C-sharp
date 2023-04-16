using BuilderPattern.FluentBuilderInheritence;
using fb = BuilderPattern.FunctionalBuilder;
using facadeB = BuilderPattern.FacetedBuilder;
using BuilderPattern.StepwiseBuilder;
using hb = BuilderPattern.HtmlBuilder;
using BuilderPattern.Excercise;

namespace BuilderPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new hb.HtmlBuilder("ul");
            builder.AddChild("li", "Hello").AddChild("li", "World!");
            Console.WriteLine(builder.ToString());

            var person = Person.New
                .Called("Kieran")
                .WorksAsA("Developer")
                .Build();

            Console.WriteLine(person.ToString());

            var car = CarBuilder.Create() // ISpecifyCarType
                .OfType(CarType.Crossover) // ISpecifyWheelSize
                .WithWheels(18) // IBuildCar
                .Build();

            Console.WriteLine(car);

            var person2 = new fb.PersonBuilder()
                .Called("Kieran")
                .Build();

            Console.WriteLine(person2);

            var pb = new facadeB.PersonBuilder();
            facadeB.Person person3 = pb
                .Works
                .At("ABC")
                .AsA("Developer")
                .Earning(10)
                .Lives
                .At("Road")
                .WithPostcode("AB12 3CD")
                .In("London");

            Console.WriteLine(person3);

            // Excercise
            var cb = new CodeBuilder("Person")
                .AddField("Age", "int")
                .AddField("Name", "string");

            Console.WriteLine(cb);
        }
    }
}