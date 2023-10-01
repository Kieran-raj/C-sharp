namespace Factories.Exercise
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"The person's name is - {Name} and has an ID of {Id}";
        }
    }
}
