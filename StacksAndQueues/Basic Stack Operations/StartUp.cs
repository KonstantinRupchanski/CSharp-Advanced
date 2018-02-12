using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class StartUp
    {
        static void Main()
        {
            var firstLine = Console.ReadLine().Split(' ');
            var n = int.Parse(firstLine[0]);
            var s = int.Parse(firstLine[1]);
            var x = int.Parse(firstLine[2]);



            var secondLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(secondLine[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}