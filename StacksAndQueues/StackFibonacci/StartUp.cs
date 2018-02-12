using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var fib = new Stack<long>();

            fib.Push(1);
            fib.Push(1);

            for (int i = 2; i < n; i++)
            {
                long first = fib.Pop();
                long second = fib.Peek() + first;
                fib.Push(first);
                fib.Push(second);
            }
            Console.WriteLine(fib.Peek());


            //var n = int.Parse(Console.ReadLine());

            //var fib = new Queue<long>();

            //fib.Enqueue(1);
            //fib.Enqueue(1);

            //for (int i = 0; i < n-1; i++)
            //{
            //    long first = fib.Dequeue();
            //    long second = fib.Peek();
            //    fib.Enqueue(first+second);
            //}

            //Console.WriteLine(fib.Peek());
        }
    }
}
