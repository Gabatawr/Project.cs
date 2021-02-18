using System;
using System.IO;
using System.Linq;

namespace task4child
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                Console.WriteLine("Parse file: " + args[0]);
                Console.WriteLine("Parse word: " + args[1]);

                string str;
                using (StreamReader sr = new(args[0]))
                {
                    str = sr.ReadToEnd();
                }

                int count = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = 0; j < args[1].Length; j++, i++)
                    {
                        if (str[i] == args[1][j])
                        {
                            if (j == args[1].Length - 1)
                            {
                                count++;
                                break;
                            }
                        }
                        else
                            break;
                    }
                }

                Console.WriteLine($"Result: {count}");
            }
            else Console.WriteLine("Invalid arguments!");

            Console.ReadKey();
        }
    }
}
