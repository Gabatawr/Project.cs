using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExamTaskOne
{
    class Program
    {
        static readonly object block = new();
        static int count = 0;
        static string path = @"E:\Code";

        static Dictionary<string, int> extensionDic, wordDic;

        static void Search(object o)
        {
            Interlocked.Increment(ref count);
            if (o is string s)
            {
                foreach (var folder in Directory.GetDirectories(s))
                    Task.Factory.StartNew(Search, folder);
                
                foreach (var file in Directory.GetFiles(s))
                {
                    FileInfo fileInfo = new(file);
                    foreach (var ex in extensionDic.Keys)
                    {
                        if (fileInfo.Extension == ex)
                        {
                            lock (block) extensionDic[ex] += 1;
                            
                            foreach (var word in wordDic.Keys)
                            {
                                var m = Regex.Matches(File.ReadAllText(file), @"[\s,\b]" + word);
                                lock (block) wordDic[word] += m.Count;
                            }
                            Console.WriteLine(file);
                        }
                    }
                }
            }
            Interlocked.Decrement(ref count);
        }

        static void Main(string[] args)
        {
            extensionDic = File.ReadAllText(Directory.GetCurrentDirectory() + '\\' + "extensions.txt")
                .Split("\r\n")
                .ToDictionary(w => w.Insert(0, "."), w => 0);
            wordDic = File.ReadAllText(Directory.GetCurrentDirectory() + '\\' + "words.txt")
                .Split("\r\n")
                .ToDictionary(w => w, w => 0);

            Task.Factory.StartNew(Search, path);

            while (true)
            {
                Thread.Sleep(100);
                lock (block) {
                    if (count == 0) break;
                }
            }
            Console.WriteLine();

            void Print(Dictionary<string, int> dic)
            {
                Console.WriteLine();
                foreach (var wd in dic)
                    Console.WriteLine(wd.Key.PadRight(wordDic.Keys.Max(w => w.Length) + 1) + ':' + wd.Value);
            }

            Print(extensionDic);
            Print(wordDic);

            Console.ReadKey();
        }
    }
}
