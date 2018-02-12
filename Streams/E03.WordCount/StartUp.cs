using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E03.WordCount
{
    public class StartUp
    {
        public static void Main()
        {
            var wordsCount = new Dictionary<string, int>();

            using (var words = new StreamReader("../Resources/words.txt"))
            {
                while (true)
                {
                    var word = words.ReadLine();

                    if (word ==null)
                    {
                        break;
                    }

                    word = word.ToLower();

                    if (!wordsCount.ContainsKey(word))
                    {
                        wordsCount[word] = 0;
                    }
                }
            }

            using (var text = new StreamReader("../Resources/text.txt"))
            {
                while (true)
                {
                    var line = text.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var wordsFromText = line.Split(" .,:;!?()[]{}-".ToCharArray()).Select(x => x.ToLower()).ToArray();

                    foreach (var word in wordsFromText)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }
                }
            }

            using (var write = new StreamWriter("result.txt"))
            {
                var result = wordsCount.OrderByDescending(w => w.Value).Select(w => $"{w.Key} - {w.Value}");

                foreach (var res in result)
                {
                    write.WriteLine(res);
                }
            }
        }
    }
}
