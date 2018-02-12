using System;
using System.IO;

namespace E02.LineNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            using (var text = new StreamReader("../Resources/text.txt"))
            {
                using (var write = new StreamWriter("newTextdoc.txt"))
                {
                    string line;
                    int row = 1;
                    while ((line = text.ReadLine()) != null)
                    {
                        write.WriteLine($"Line {row} : {line}");
                        row++;
                    }
                }
            }
        }
    }
}



