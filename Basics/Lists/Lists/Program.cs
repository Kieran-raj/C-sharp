namespace Lists
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 3, 4 };
            numbers.Add(1);

            numbers.AddRange(new int[3] { 5, 6, 7 });

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Remove the ones");
            for (var i = 0; i < numbers.Count; i++)
            {   
                if (numbers[i] == 1)
                {
                    numbers.Remove(1);
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }

}