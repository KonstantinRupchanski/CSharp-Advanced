using System;

namespace E02.KnightsOfHonor
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> function = x => Console.WriteLine($"Sir {x}");

            foreach (var name in names)
            {
                function(name);
            }
        }
    }
}
