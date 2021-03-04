using System;

namespace UnsafeConsole
{
    class Program
    {
        static void Main()
        {
            int a1 = 1;
            ref int a2 = ref a1;
            a2 = 2;
            Console.WriteLine(a1);

            unsafe
            {
                int b1 = 1;
                int* b2 = &b1;
                *b2 = 2;
                Console.WriteLine(b1);
            }

            Console.ReadKey();
        }
    }
}
