using System;
using System.Linq;

namespace L03.CountUppercaseWords
{
    public class StartUp
    {
        public static void Main()
        {
            Func<string, bool> checker = s => char.IsUpper(s[0]);
            var words = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToList();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
