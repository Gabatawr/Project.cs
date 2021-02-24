using System;
using System.Threading;

namespace ConsoleThreadPool
{
    class Program
    {
        static Random r = new();
        public static void Mul(object state)
        {
            var max = (int)state;

            int errors = 0;
            int res = 1;

            for (int i = 0; i < 50; i++)
            {
                try { checked { res *= r.Next(1, max); } }
                catch (Exception) { errors++; }
            }
            Console.WriteLine("Mul: " + res + "\tError: " + errors);
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write('.');
                Thread.Sleep(100);
            }
            Console.WriteLine();

            for (int i = 0; i < 100; i++)
                ThreadPool.QueueUserWorkItem(Mul, i + 3);

            Console.ReadKey();
        }
    }
}
