using System;
using System.Linq;

namespace E05.AppliedArithmetics
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();


            Func<long, long> add = x => x + 1;
            Func<long, long> subtract = x => x - 1;
            Func<long, long> multiply = x => x * 2;

            while (true)
            {
                var mycommand = Console.ReadLine();
                if (mycommand == "end")
                {
                    break;
                }

                switch (mycommand)
                {
                    case "add":
                        numbers = numbers.Select(add).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(subtract).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(multiply).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
            }
        }
    }
}
