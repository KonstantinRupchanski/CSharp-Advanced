using System;
using System.Collections.Generic;

namespace Reverse_Numbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var stack = new Stack<string>(input);

            Console.WriteLine(string.Join(" ", stack));

            //var input = Console.ReadLine().Split(' ');
            //var stack = new Stack<string>();

            //foreach (var x in input)
            //{
            //    stack.Push(x);
            //}

            //while (stack.Count > 0)
            //{
            //    Console.Write($"{stack.Pop()} ");
            //}
        }
    }
}
