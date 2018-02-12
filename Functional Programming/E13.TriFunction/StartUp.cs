using System;
using System.Linq;

namespace E13.TriFunction
{
    public class StartUp
    {
        public static void Main()
        {
            var sum = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().ToList();

            var filter = CreateFilter(sum);

            Console.WriteLine(names.FirstOrDefault(filter));
        }

        private static Func<string, bool> CreateFilter(int sum)
        {
            return name => name.ToCharArray().Sum(c => c) >= sum;
        }
    }
}
