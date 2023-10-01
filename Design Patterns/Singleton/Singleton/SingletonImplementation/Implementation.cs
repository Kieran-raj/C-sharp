namespace Singleton.SingletonImplementation
{
    public class Implementation
    {
        public static void Run()
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            Console.WriteLine($"{city} has population -> {db.GetPopulation(city)}");
        }
    }
}
