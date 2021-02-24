using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadCallBackFramework
{
    class Program
    {
        delegate UInt64 AsyncFoo(UInt64 size);
        static void Main(string[] args)
        {
            
            AsyncFoo foo = (UInt64 size) =>
            {
                UInt64 f = 1;
                for (UInt64 i = 2, tmp; i <= size; i++)
                {
                    try { checked { tmp = f * i; } }
                    catch (Exception)
                    {
                        Console.WriteLine("Overflow, max value returned");
                        return f;
                    }
                    f *= i;
                }
                return f;
            };

            UInt64 n = 21U;
            foo.BeginInvoke(n, (ar) => { Console.WriteLine(foo.EndInvoke(ar)); }, null);

            Console.ReadKey();
        }
    }
}
