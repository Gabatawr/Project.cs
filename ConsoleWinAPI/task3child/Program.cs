using System;
using System.Collections.Generic;
using System.Linq;

namespace task3child
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Arguments: ");
            Console.WriteLine(string.Join(',', args));

            List<int> numberList = new();
            for (int i = 0; i < args.Length - 1; i++)
            {
                int n;
                if (int.TryParse(args[i], out n)) numberList.Add(n);
            }

            Console.WriteLine("Result: " + numberList.Sum());
            Console.ReadKey();
        }
    }
}
