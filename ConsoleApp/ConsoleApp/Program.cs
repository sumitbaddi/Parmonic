using System;

namespace FizzBuzz
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter an integer:");
            int userInput;
            var input = Console.ReadLine();
            bool isInt = int.TryParse(input, out userInput);

            if (string.IsNullOrEmpty(input) || isInt ==false || userInput <= 0)
            {
                Console.WriteLine("Provide valid integer input value greater than or equal to 1");
                return;
            }
                        
            if (!string.IsNullOrEmpty(input) && isInt == true && userInput > 0)
            {
                var res = DisplayFizzBuzz(userInput);
                Console.WriteLine(res);
                Console.ReadLine();
            }            
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