namespace ExercisesControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            //QuestionOne();
            //QuestionTwo();
            //QuestionThree();
            QuestionFour();
        }

        static void QuestionOne()
        {
            Console.WriteLine("Input number: ");
            var number = Console.ReadLine();
            
            if (int.Parse(number) > 1 && int.Parse(number) < 10)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }

        static void QuestionTwo()
        {
            Console.WriteLine("Input first number: ");
            var numberOne = Console.ReadLine();
            Console.WriteLine("Input second number: ");
            var numberTwo = Console.ReadLine();
            if (int.Parse(numberOne) > int.Parse(numberTwo))
            {
                Console.WriteLine(numberOne);
            }
            else
            {
                Console.WriteLine(numberTwo);
            }
        }

        static void QuestionThree()
        {
            Console.WriteLine("Input Width");
            var width = Console.ReadLine();
            Console.WriteLine("Input Height");
            var height = Console.ReadLine();
            if (int.Parse(width) > int.Parse(height))
            {
                Console.WriteLine("Landscape");
            }
            else
            {
                Console.WriteLine("Portait");
            }
        }

        static void QuestionFour()
        {
            var points = 0;
            Console.WriteLine("Enter Speed limit: ");
            var speedLimit = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Car Speed: ");
            var carSpeed = int.Parse(Console.ReadLine());
            if (carSpeed > speedLimit )
            {
                var diff = carSpeed - speedLimit;
                points += (diff / 5);
                Console.WriteLine(points);

            }
            else
            {
                Console.WriteLine("Ok");
            }
        }
    }
}