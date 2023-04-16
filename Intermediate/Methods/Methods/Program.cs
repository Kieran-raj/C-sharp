namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            //var number = int.Parse("args");

            int number;
            var result = int.TryParse("abc", out number);
            if (result)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("Conversion failed.");
            }
        }

        static void UsePoints()
        {
            try
            {
                var point = new Point(10, 20);
                point.Move(new Point(40, 60));

                Console.WriteLine("Point is at ({0}, {1})", point.X, point.Y);

                point.Move(100, 200);
                Console.WriteLine("Point is at ({0}, {1})", point.X, point.Y);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occured.");
            }
        }

        static void UserParams()
        {
            var calculator = new Calculator();
            Console.WriteLine(calculator.Add(1, 2, 3));
            Console.WriteLine(new int[] { 1, 2, 3, 4 });
        }
    } 
}