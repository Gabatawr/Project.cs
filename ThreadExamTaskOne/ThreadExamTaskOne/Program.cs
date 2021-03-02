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

        static Dictionary<string, int> extenDic;
        static Dictionary<string, int> wordDic = new();

        static void Search(object o)
        {
            Interlocked.Increment(ref count);
            if (o is string s)
            {
                string[] folders = Directory.GetDirectories(s);
                foreach (var folder in folders)
                    Task.Factory.StartNew(Search, folder);
                
                string[] files = Directory.GetFiles(s);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new(file);
                    foreach (var ex in extenDic.Keys)
                    {
                        if (fileInfo.Extension == ex)
                        {
                            lock (block) extenDic[ex] += 1;

                            string fireStr = File.ReadAllText(file);
                            foreach (var word in wordDic.Keys)
                            {
                                MatchCollection m = Regex.Matches(fireStr, @"[\s,\b]" + word);
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
            Console.Write("Tasks: ");

            extenDic = File.ReadAllText(Directory.GetCurrentDirectory() + '\\' + "extensions.txt")
                .Split("\r\n")
                .ToDictionary(w => w.Insert(0, "."), w => 0);
            wordDic = File.ReadAllText(Directory.GetCurrentDirectory() + '\\' + "words.txt")
                .Split("\r\n")
                .ToDictionary(w => w, w => 0);

            Task.Factory.StartNew(Search, path);

            Thread.Sleep(100);
            Console.CursorVisible = false;
            while (true)
            {
                //lock (block) Console.Write(count);
                //Console.SetCursorPosition(7, Console.CursorTop);

                Task.WaitAny();
                lock (block)
                {
                    if (count == 0)
                    {
                        //Console.Write(count);
                        break;
                    }
                }
            }
            Console.CursorVisible = true;
            Console.WriteLine();

            void Print(Dictionary<string, int> dic)
            {
                Console.WriteLine();
                foreach (var wd in dic)
                    Console.WriteLine(wd.Key.PadRight(wordDic.Keys.Max(w => w.Length) + 1) + ':' + wd.Value);
            }

            Print(extenDic);
            Print(wordDic);

            Console.ReadKey();
        }
    }
}
