namespace ExercisesArraysAndLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //QuestionOne();
            //QuestionTwo();
            //QuestionThree();
            //QuestionFour();
            QuestionFive();
        }

        public static void QuestionOne()
        {
            var userLikes = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter User Name (or hit ENTER to quit): ");
                var input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }

                // What I did
                //if (userLikes != null && input != null)
                //{
                //    userLikes.Add(input);
                //}

                // Actual Solution
                if (String.IsNullOrEmpty(input))
                {
                    break;
                }

                if (userLikes?.Count == 0)
                {
                    continue;
                }
                else if (userLikes?.Count == 1)
                {
                    Console.WriteLine("\n" + userLikes[0] + " likes your post" + "\n");
                }
                else if (userLikes?.Count == 2)
                {
                    Console.WriteLine("\n" + userLikes[0] + " and " + userLikes[1] + " likes your post" + "\n");
                }
                else if (userLikes?.Count >= 2)
                {
                    var otherCount = userLikes?.Count - 2;
                    Console.WriteLine($"\n{userLikes[0]}, {userLikes[1]} and {otherCount} others like your post \n");
                }
            }
            
        }

        public static void QuestionTwo()
        {
            Console.WriteLine("What's your name? ");
            var userName = Console.ReadLine();
            
            var array = new char[userName.Length];
            for (var i = userName.Length; i > 0; i--)
            {
                array[userName.Length - i] = userName[i -1];
            }

            var reversed = new string(array);

            Console.WriteLine("Reversed name: " + reversed);
        }

        public static void QuestionThree()
        {
            var numbers = new List<int>();

            while (true)
            {
                Console.WriteLine("Enter a number: ");
                var chosenNumber = Convert.ToInt32(Console.ReadLine());

                if (!numbers.Contains(chosenNumber))
                {
                    numbers.Add(chosenNumber);
                } 
                else
                {
                    Console.WriteLine("Number has already been chosen. \n");
                    continue;
                }

                if (numbers?.Count == 5)
                {
                    numbers?.Sort();

                    Console.WriteLine("\n");

                    foreach (var number in numbers)
                    {
                        Console.WriteLine(number);
                    }

                    break;
                }
            }
        }

        public static void QuestionFour()
        {
            var numbers = new List<int>();
            while (true)
            {
                Console.WriteLine("Enter a number or type 'Quit' to exit: ");
                var input = Console.ReadLine();

                if (input == "Quit")
                {
                    break;
                }

                numbers.Add(Convert.ToInt32(input));
            }

            var uniques = new List<int>();

            foreach (var number in numbers)
            {
                if (!uniques.Contains(number))
                {
                    uniques.Add(number);
                }   
            }

            Console.WriteLine("Unique numbers: ");
            foreach (var unique in uniques)
            {
                Console.WriteLine(unique);
            }
        }

        public static void QuestionFive()
        {
            string[] numbers;
            while (true)
            {
                Console.WriteLine("Enter a list of comma separated numbers:");

                var input = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(input))
                {
                    numbers = input.Split(',');
                    if (numbers.Length >= 5)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid List");
                }
            }

            var elements = new List<int>();
            foreach (var element in numbers)
            {
                elements.Add(Convert.ToInt32(element));
            }
            var smallest = new List<int>();
            while (smallest.Count <3)
            {
                var min = elements[0];
                foreach (var number in elements)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }
                smallest.Add(min);

                elements.Remove(min);
            }

            Console.WriteLine("The 3 smallest numbers are: ");
            foreach (var number in smallest)
            {
                Console.WriteLine(number);
            }
        }
     }
}