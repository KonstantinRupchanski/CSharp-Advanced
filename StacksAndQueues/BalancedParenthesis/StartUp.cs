using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 != 0)
            {
                NotBalanced();
            }

            var opening = new char[] { '(', '[', '{' };
            var closing = new char[] { ')', ']', '}' };

            var stack = new Stack<char>();

            foreach (var element in input)
            {
                if (opening.Contains(element))
                {
                    stack.Push(element);
                }
                else if (closing.Contains(element))
                {
                    var lastElement = stack.Pop();
                    var openingIndex = Array.IndexOf(opening, lastElement);
                    var closingIndex = Array.IndexOf(closing, element);
                    if (openingIndex != closingIndex)
                    {
                        NotBalanced();
                    }
                }
            }

            if (stack.Any())
            {
                NotBalanced();
            }
            else
            {
                Console.WriteLine("YES");
            }
        }

        private static void NotBalanced()
        {
            Console.WriteLine("NO");
            Environment.Exit(0);
        }
    }
}