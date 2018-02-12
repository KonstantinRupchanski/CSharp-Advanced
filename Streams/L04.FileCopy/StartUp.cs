using System;
using System.IO;

namespace L04.FileCopy
{
    public class StartUp
    {
        public static void Main()
        {
            using (var sourceFile = new FileStream("stream.jpg", FileMode.Open))
            {
                using (var destinationFile = new FileStream("stream-copy.jpg", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        var readBytesCount = sourceFile.Read(buffer, 0, buffer.Length);
                        if (readBytesCount == 0)
                        {
                            break;
                        }
                        destinationFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
