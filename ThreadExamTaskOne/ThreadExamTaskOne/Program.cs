using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExamTaskOne
{
    partial class Program
    {
        static readonly object block = new();

        static void Search(object o)
        {
            if (o is string s)
            {
                DirectoryInfo dInfo = new(s);
                if (dInfo.Attributes.HasFlag(FileAttributes.Hidden) is false &&
                    dInfo.Attributes.HasFlag(FileAttributes.System) is false)
                {
                    foreach (var folder in Directory.GetDirectories(s))
                    {
                        Task.Factory.StartNew(Search, folder);
                        Interlocked.Decrement(ref progressCur);
                    }
                }

                foreach (var file in Directory.GetFiles(s))
                {
                    FileInfo fileInfo = new(file);
                    foreach (var ex in Stat.ExtensionsDic.Keys)
                    {
                        if (fileInfo.Extension == ex)
                        {
                            lock (block) Stat.ExtensionsDic[ex] += 1;

                            string fileText = File.ReadAllText(file);

                            Dictionary<string, int> foundWords = new();

                            foreach (var word in Stat.WordsDic.Keys)
                            {
                                var m = Regex.Matches(fileText, @"[\s,\b]" + word);
                                foundWords.Add(word, m.Count);
                                lock (block) Stat.WordsDic[word] += m.Count;
                            }

                            Stat.List.Add(new Stat()
                            {
                                Path = file,
                                Size = fileInfo.Length,
                                FoundWords = foundWords
                            });
                        }
                    }
                }
                Thread.Sleep(10); //fake lag
            }
        }

        static int progressCur = 0, progressMax = 0;
        static void CountMax(object o)
        {
            if (o is string s)
            {
                DirectoryInfo dInfo = new(s);
                if (dInfo.Attributes.HasFlag(FileAttributes.Hidden) is false &&
                    dInfo.Attributes.HasFlag(FileAttributes.System) is false)
                {
                    foreach (var folder in Directory.GetDirectories(s))
                    {
                        Task.Factory.StartNew(CountMax, folder).Wait();
                        Interlocked.Increment(ref progressCur);
                    }
                }
            }
        }

        static void EnterPath()
        {
            Console.Write("Enter path: ");
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s) is false && Directory.Exists(s))
            {
                if (s[^1] == ':' || s[^1] != '\\')
                    s += '\\';
                AppPath.Search = s;
            }
            Console.CursorVisible = false;
        }

        static void SearchStart()
        {
            void Print(string s)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("".PadRight(12, ' '));
                Console.Write('\r'+ s + ".." +'\r');
            }

            Print("Scan");
            Task.Factory.StartNew(CountMax, AppPath.Search).Wait();
            progressMax = progressCur;

            Print("Search");
            Task.Factory.StartNew(Search, AppPath.Search);
        }

        static void ProgressBar()
        {
            Console.WriteLine();
            {
                Console.Write("[".PadRight(100, '_') + ']');
                for (double p = 100; p >= 0; p = (double)progressCur / progressMax * 100)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("[".PadRight(100 - (int)p, '#'));
                    Console.Write("]" + Math.Round(100 - p) + '%');
                    if (100 - p == 100) break;
                }
                Console.WriteLine();
            }
            Console.CursorVisible = true;
        }

        static void Main(string[] args)
        {
            EnterPath();
            SearchStart();

            Task.Run(ProgressBar).Wait();

            Stat.SaveChanges();
            Stat.ShortPrint();

            Console.ReadKey();
        }
    }
}
