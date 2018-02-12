using System;

namespace E01.ActionPrint
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);

            Action<string> printName = x => Console.WriteLine(x);

            foreach (var name in names)
            {
                printName(name);
            }
        }
    }
}
