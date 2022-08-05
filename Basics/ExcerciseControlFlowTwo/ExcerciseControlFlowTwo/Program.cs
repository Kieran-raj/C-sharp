namespace ExcerciseControlFlowTwo {
    class Program
    {
        public static void Main (string[] args)
        {
            //QuestionOne(); // Answer = 34
            //QuestionTwo();
            //QuestionThree();
            //QuestionFour();
            QuestionFive();
        }

        public static void QuestionOne()
        {
            var count = 0;
            for (int i = 0; i < 100; i++)
            {
                if (i % 3 == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        public static void QuestionTwo()
        {
            var command = String.Empty;
            var sum = 0;
            while (command != "ok") {
                var num = Console.ReadLine();
                try
                {
                    sum += Convert.ToInt32(num);
                } 
                catch 
                {
                    break;
                }

            }
            Console.WriteLine(sum);
        }

        public static void QuestionThree()
        {
            var num = Console.ReadLine();
            var factorial = 1;
            for (int i = 1; i <= Convert.ToInt32(num); i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }

        public static void QuestionFour()
        {
            var random = new Random();
            var randomNum = random.Next(1, 10);
            var userInput = Console.ReadLine();
            if (Convert.ToInt32(userInput) != randomNum)
            {
                Console.WriteLine("You lost");
            }
            else
            {
                Console.WriteLine("You won");
            }
        }

        public static void QuestionFive()
        {
            var numbers = Console.ReadLine();
            var numArray = numbers.Split(", ");
            Console.WriteLine(numArray.Max());
        }
    }
}