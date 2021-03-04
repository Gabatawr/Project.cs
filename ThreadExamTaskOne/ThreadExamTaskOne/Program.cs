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
        static int tasksCount = 0;

        static void Search(object o)
        {
            Interlocked.Increment(ref tasksCount);
            if (o is string s)
            {
                foreach (var folder in Directory.GetDirectories(s))
                {
                    Task.Factory.StartNew(Search, folder);
                    Interlocked.Decrement(ref progressCur);
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
                Interlocked.Decrement(ref tasksCount);
            }
        }

        static int progressCur = 0;
        static void CountMax(object o)
        {
            if (o is string s)
            {
                foreach (var folder in Directory.GetDirectories(s))
                {
                    Task.Factory.StartNew(CountMax, folder).Wait();
                    Interlocked.Increment(ref progressCur);
                }
            }
        }

        static void Main(string[] args)
        {
            Task.Factory.StartNew(CountMax, AppPath.Search).Wait();
            int progressMax = progressCur;

            Task.Factory.StartNew(Search, AppPath.Search);

            Console.CursorVisible = false;
            {
                Console.Write("[".PadRight(100, '_') + ']');
                for (double p = 100; tasksCount != 0; p = (double)progressCur / progressMax * 100)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("[".PadRight(100 - (int)p, '#'));
                    Console.Write("]" + Math.Round(100 - p) + '%');
                    if (100 - p == 100) break;
                }
                Console.WriteLine();
            }
            Console.CursorVisible = true;

            Console.Write("Saving...");
            Stat.SaveChanges();
            Console.WriteLine("\rSaved    ");

            Stat.ShortPrint();

            Console.ReadKey();
        }
    }
}
