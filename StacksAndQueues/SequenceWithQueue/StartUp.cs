using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SequenceWithQueue
{
    public class StartUp
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            var count = 1;

            var queue = new Queue<long>();

            Console.Write($"{n} ");
            queue.Enqueue(n);

            while (count <= 50)
            {
                n = queue.Dequeue();

                var s1 = n + 1;
                Console.Write($"{s1} ");
                queue.Enqueue(s1);
                count++;

                CheckThe50();

                var s2 = 2 * n + 1;
                Console.Write($"{s2} ");
                queue.Enqueue(s2);
                count++;

                CheckThe50();

                var s3 = n + 2;
                Console.Write($"{s3} ");
                queue.Enqueue(s3);
                count++;
            }
            Console.WriteLine();

            void CheckThe50()
            {
                if (count >= 50)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
