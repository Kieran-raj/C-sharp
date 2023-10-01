using MoreLinq;

namespace Singleton.SingletonImplementation
{
    public class SingletonDatabase : IDatabase
    {
        private readonly Dictionary<string, int> capitals;
        private static int instanceCount;
        public static int Count => instanceCount;

        private SingletonDatabase()
        {
            instanceCount++;
            Console.WriteLine("Initilizing database");
            Console.WriteLine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName);
            var file = new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName ?? "";
            capitals = File.ReadAllLines(
                    Path.Combine(
                        file, "SingletonImplementation\\capitals.txt")
                )
                .Batch(2)
                .ToDictionary(
                    x => x.ElementAt(0).Trim(),
                    x => int.Parse(x.ElementAt(1))
                );
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private readonly static Lazy<SingletonDatabase> instance = new(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value; // This value will invoke the lambda within the lazy creation.
    }
}
