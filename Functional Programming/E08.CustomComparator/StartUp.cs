using System;
using System.Linq;

namespace E08.CustomComparator
{
    public class StartUp
    {
        public static void Main()
        {
            Func<int,bool> isEven = n => n % 2 == 0;

            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .GroupBy(n => isEven(n))
                .OrderByDescending(g => g.Key)
                .ToDictionary(g => g.Key, g => g.OrderBy(n => n).ToList());

            foreach (var group in numbers)
            {
                Console.Write(String.Join(" ", group.Value) + " ");
            }
        }
    }
}
