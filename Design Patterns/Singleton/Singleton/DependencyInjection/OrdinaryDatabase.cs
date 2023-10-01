using MoreLinq;

namespace Singleton.DependencyInjection
{
    public class OrdinaryDatabase : IDatabase
    {
        private readonly Dictionary<string, int> capitals;
        public OrdinaryDatabase()
        {
 
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
    }
}
