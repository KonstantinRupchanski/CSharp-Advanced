using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.CustomMinFunction
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> smallestNumber = x => x.Min();

            Console.WriteLine(smallestNumber(numbers));
        }
    }
}
