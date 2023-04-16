namespace BuilderPattern.FunctionalBuilder
{
    public class Person
    {
        public string Name;
        public string Position;

        public override string ToString()
        {
            return $"The person is {Name}";
        }
    }
}
