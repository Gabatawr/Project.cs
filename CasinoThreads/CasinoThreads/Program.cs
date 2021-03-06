using System;

namespace CasinoThreads
{
    partial class Program
    {
        public static Random Rand = new();

        static void Main(string[] args)
        {
            int tablesCount = 1;
            Table[] tables = new Table[tablesCount];
            for (int i = 0; i < tablesCount; i++)
                tables[i] = new(Rand.Next(5, 10 + 1));

            for (int i = 0; i < tablesCount; i++)
            {
                while (tables[i].InGame);
                Console.WriteLine("\nTable #" + i + " Players per day #" + tables[i].PlayersPerDay);
                tables[i].Statistic.Print();
            }
            Console.ReadKey();
        }
    }
}
