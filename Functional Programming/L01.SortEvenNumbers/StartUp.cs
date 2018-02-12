using System;
using System.Linq;

namespace L01.SortEvenNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[]{", "}, StringSplitOptions.None)
                .Select(n => int.Parse(n))
                .Where(n => n % 2 == 0)
                .OrderBy(n => n);
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
