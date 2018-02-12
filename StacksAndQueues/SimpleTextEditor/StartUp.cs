using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var commandsCount = int.Parse(Console.ReadLine());
            var oldVersions = new Stack<string>();
            oldVersions.Push("");
            var text = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                var commandInput = Console.ReadLine().Split().ToArray();
                var command = int.Parse(commandInput[0]);

                switch (command)
                {
                    case 1:
                        oldVersions.Push(text.ToString());
                        var newStr = commandInput[1];
                        text.Append(newStr);
                        break;
                    case 2:
                        oldVersions.Push(text.ToString());
                        var lenght = int.Parse(commandInput[1]);
                        text.Remove(text.Length - lenght, lenght);
                        break;
                    case 3:
                        var index = int.Parse(commandInput[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        text.Clear();
                        text.Append(oldVersions.Pop());
                        break;
                }
            }
        }
    }
}
