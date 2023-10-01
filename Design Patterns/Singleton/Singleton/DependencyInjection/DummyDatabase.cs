namespace Singleton.DependencyInjection
{
    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["Alpha"] = 1,
                ["Beta"] = 2,
                ["Gamma"] = 3,
            }[name];
        }
    }
}
