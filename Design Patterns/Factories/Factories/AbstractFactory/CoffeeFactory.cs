namespace Factories.AbstractFactory
{
    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil water, power {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }
}
