using System;
using System.IO;

namespace E04.CopyBinaryFile
{
    public class StartUp
    {
        public static void Main()
        {
            using (var source = new FileStream("../Resources/copyMe.png", FileMode.Open))
            {
                using (var newFile = new FileStream("copyMeCopy.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0) break;

                        newFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
