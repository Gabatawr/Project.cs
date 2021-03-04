using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ThreadExamTaskOne
{
    partial class Program
    {
        class Stat
        {
            public static List<Stat> List = new();
            public static Dictionary<string, int> ExtensionsDic, WordsDic;
            static Stat()
            {
                ExtensionsDic = File.ReadAllText(AppPath.FileExtensions)
                    .Split("\r\n")
                    .ToDictionary(w => w.Insert(0, "."), w => 0);
                WordsDic = File.ReadAllText(AppPath.FileWords)
                    .Split("\r\n")
                    .ToDictionary(w => w, w => 0);
            }

            public static void ShortPrint()
            {
                void Print(Dictionary<string, int> dic)
                {
                    Console.WriteLine();
                    foreach (var wd in dic)
                        Console.WriteLine(wd.Key.PadRight(WordsDic.Keys.Max(w => w.Length) + 1) + ':' + wd.Value);
                }
                Print(ExtensionsDic);
                Print(WordsDic);
            }

            public static void SaveChanges()
            {
                using (FileStream fs = new(AppPath.FileStat, FileMode.Create));
                foreach (var stat in List.OrderByDescending((e) => e.Found))
                    if (stat.Found > 0)
                        stat.Record();
            }

            //-----------------------------------------------------------------

            public string Path { get; init; }
            public long Size { get; init; }
            public int Found => FoundWords.Sum((e) => e.Value);
            public Dictionary<string, int> FoundWords { get; init; }

            void Record()
            {
                using (StreamWriter sw = new(AppPath.FileStat, true))
                {
                    sw.WriteLine(ToString());
                }
            }

            public override string ToString()
            {
                StringBuilder sb = new();
                sb.Append($"Path : {Path}" + '\n');
                sb.Append($"Size : {Size}" + '\n');
                sb.Append($"Total: {Found}" + ' ');

                foreach (var kv in FoundWords.OrderByDescending((e) => e.Value))
                    if (kv.Value > 0)
                        sb.Append('[' + kv.Key + " : " + kv.Value + "] ");

                sb.AppendLine();

                return sb.ToString();
            }
        }
    }
}
