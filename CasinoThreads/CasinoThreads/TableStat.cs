using System;
using System.Collections.Generic;
using System.Linq;

namespace CasinoThreads
{
    partial class Program
    {
        public class TableStat
        {
            public Dictionary<string, MoneyStat> List = new();
            public class MoneyStat
            {
                public int Start { get; init; }
                public int End { get; set; }
            }

            public void Print()
            {
                int j = 1;
                foreach (var i in List.OrderByDescending((e) => e.Value.End))
                {
                    Console.WriteLine($"{j++} : ".PadLeft(5, '0') + i.Key + " : [" + i.Value.Start + "] [" + i.Value.End + ']');
                }
            }
        }
    }
}
