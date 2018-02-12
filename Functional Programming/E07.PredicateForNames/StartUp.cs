using System;
using System.Linq;

namespace E07.PredicateForNames
{
    public class StartUp
    {
        public static void Main()
        {
            int charCount = int.Parse(Console.ReadLine());

            Func<string, bool> myFunc = x => x.Length <= charCount;

            var names = Console.ReadLine()
                .Split(new [] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(n => n.Length)
                .Where(n=>myFunc(n))
                .ToList();

            names.ForEach(Console.WriteLine);


            //var output = new List<string>(); //решение с list и foreach

            //foreach (var name in names)
            //{
            //    if (name.Length <= charCount)
            //    {
            //        output.Add(name);
            //    }
            //}

            //output.ForEach(Console.WriteLine);
        }
    }
}
