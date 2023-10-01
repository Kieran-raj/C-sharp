namespace Factories.AbstractFactory
{
    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in a tea baf, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }
}

