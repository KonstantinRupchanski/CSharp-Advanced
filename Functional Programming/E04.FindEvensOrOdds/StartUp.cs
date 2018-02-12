using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.FindEvensOrOdds
{
    public class StartUp
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(n => n)
                .ToList();
            var command = Console.ReadLine().ToLower();

            Func<int, bool> isEvenNumber = x => x % 2 == 0;

            var print = GetNumbers(range, isEvenNumber, command);
            Console.WriteLine(string.Join(" ", print));
        }

        private static List<int> GetNumbers(List<int> range, Func<int, bool> isEvenNumber, string command)
        {
            var listOfOddOrEvenNumbers = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                if ((isEvenNumber(i) && command == "even") || (!isEvenNumber(i) && command == "odd"))
                {
                    listOfOddOrEvenNumbers.Add(i);
                }
            }
            return listOfOddOrEvenNumbers;
        }
    }
}

