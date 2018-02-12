using System;
using System.Linq;

namespace L02.SumNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.None)
                .Select(n => int.Parse(n));
            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum()); 
        }
    }
}
