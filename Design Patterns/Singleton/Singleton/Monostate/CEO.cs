namespace Singleton.Monostate
{
    public class CEO
    {
        private static string name;
        private static int age;

        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
}
