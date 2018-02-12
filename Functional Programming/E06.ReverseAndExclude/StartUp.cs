using System;
using System.Linq;

namespace E06.ReverseAndExclude
{
    public class StartUp
    {
        public static void Main()
        {
            var listOfNums = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> myFunc = n => n % divider != 0;

            var output = listOfNums
                .Where(n => myFunc(n))
                .Reverse()
                .ToList();

            Console.WriteLine(String.Join(" ", output));
        }
    }
}
