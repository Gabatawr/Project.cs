using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ThreadOne
{
    class PracticeOne
    {
        static Random rand = new();

        static void MIN(object obj) => Console.WriteLine("Min: " + (obj as List<int>).Min());
        static void AVG(object obj) => Console.WriteLine("Avg: " + (obj as List<int>).Average());
        static void MAX(object obj) => Console.WriteLine("Max: " + (obj as List<int>).Max());

        static void Main()
        {
            List<int> l = new();

            int randMax = 100000;
            int randMin = 1000;

            for (int i = 0; i < 10000; i++)
                l.Add(rand.Next(randMin, randMax + 1));

            Thread[] tarr = { new(MIN), new(AVG), new(MAX) };
            foreach (var t in tarr)
                t.Start(l);

            Console.ReadKey();
        }
    }
}
