using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E08.FullDirectoryTraversal
{
    public class StartUp
    {
        public static void Main()
        {
            string sourcePath = Console.ReadLine();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filesDict = new Dictionary<string, Dictionary<string, long>>();

            SearchDirectory(sourcePath, desktop, filesDict);
        }

        public static void SearchDirectory(string sourcePath, string desktop, Dictionary<string, Dictionary<string, long>> filesDict)
        {
            var filesInDirectory = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);

            foreach (var file in filesInDirectory)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;
                var name = fileInfo.Name;
                var length = fileInfo.Length;

                if (!filesDict.ContainsKey(extension))
                {
                    filesDict[extension] = new Dictionary<string, long>();
                }
                if (!filesDict[extension].ContainsKey(name))
                {
                    filesDict[extension][name] = length;
                }
            }

            var filesDictSorted = filesDict
                                .OrderByDescending(x => x.Value.Count)
                                .ThenBy(x => x.Key);

            using (var report = new StreamWriter($"{desktop}/reportFullSearch.txt"))
            {

                foreach (var kvp in filesDictSorted)
                {
                    var extension = kvp.Key;
                    var files = filesDict[extension].OrderByDescending(x => x.Value);

                    report.WriteLine(extension);
                    foreach (var file in files)
                    {
                        double fileSize = (double)file.Value / 1024;

                        report.WriteLine($"--{file.Key} - {fileSize:f3} kb");
                    }
                }
            }
        }
    }
}
