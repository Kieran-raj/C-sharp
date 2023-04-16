namespace ClassIntro
{
    public class Person
    {
        public string Name;

        public void Introduce(string to)
        {
            Console.WriteLine("Hi {0}, I am {1}", to, Name);
        }

        public static Person Parse(string str)
        {
            var person = new Person();
            person.Name = str;

            return person;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();

            person.Name = "Kieran";
            person.Introduce("Mosh");

            var newPerson = Person.Parse("John");
            newPerson.Introduce("Mosh");
        }
    }
}