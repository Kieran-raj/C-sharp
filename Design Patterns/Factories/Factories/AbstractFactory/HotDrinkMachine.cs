namespace Factories.AbstractFactory
{
    public class HotDrinkMachine
    {
        //public enum AvailabeDrink
        //{
        //    Coffee, 
        //    Tea
        //}

        //private Dictionary<AvailabeDrink, IHotDrinkFactory> factories = new Dictionary<AvailabeDrink, IHotDrinkFactory>();

        //public HotDrinkMachine()
        //{
        //    foreach (AvailabeDrink drink in Enum.GetValues(typeof(AvailabeDrink)))
        //    {
        //        // Create Instance is used because we need to generate the factory by name.
        //        var factory = (IHotDrinkFactory)Activator.CreateInstance(
        //            Type.GetType("Factories.AbstractFactory." + Enum.GetName(typeof(AvailabeDrink), drink) + "Factory")
        //            );

        //        if (factory != null)
        //        {
        //            factories.Add(drink, factory);
        //        }
        //    }
        //}

        //public IHotDrink MakeDrink(AvailabeDrink drink, int amount)
        //{
        //    return factories[drink].Prepare(amount);
        //}

        // Above breaks the open close principle //

        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                // Test if sometihing implements an interence
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t))); 
                }   
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available drinkls:");
            for (int i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                Console.WriteLine($"{i}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null && int.TryParse(s, out int i) && i >= 0 && i < factories.Count)
                {
                    Console.Write("Specify amount: ");
                    s = Console.ReadLine();
                    if (s != null && int.TryParse(s, out int amount)  && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                Console.WriteLine("Incorrect input, try again");
            }
        }
    }
}
