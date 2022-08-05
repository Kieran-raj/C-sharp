using Classes.Maths;

namespace Classes
{
    class Program
    {
        static  void Main(string[] args)
        {
            var john = new Person();
            john.FirstName = "John";
            john.LastName = "Smith";
            john.Introduce();

            Calculator calculator = new Calculator();
            var results = calculator.Add(1, 2);
            Console.WriteLine(results); 
        }
    }

}
