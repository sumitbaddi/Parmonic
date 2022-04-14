using System;

namespace FizzBuzz
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter an integer:");
            int i;
            int.TryParse(Console.ReadLine(),out i);
            var res = DisplayFizzBuzz(i);
            Console.WriteLine(res);
            Console.ReadLine();
        }

        public static string DisplayFizzBuzz(int i)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (i % 3 == 0 && i % 5 != 0)
            {
                return "Fizz";
            }
            else if (i % 3 != 0 && i % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return i.ToString();
            }
        }
    }
}