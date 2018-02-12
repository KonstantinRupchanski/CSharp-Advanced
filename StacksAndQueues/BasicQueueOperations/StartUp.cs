using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var s = int.Parse(input[1]);
            var x = int.Parse(input[2]);

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count > 0)
            {
                if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
