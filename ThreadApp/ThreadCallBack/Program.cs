using System;

namespace ThreadCallBack
{
    class Program
    {
        delegate int AsyncSum(int size);
        static void Main(string[] args)
        {
            AsyncSum asum = Sum;
            asum.BeginInvoke(100, (IAsyncResult ar) => { Console.WriteLine(asum.EndInvoke(ar)); }, null);
            Console.ReadKey();
        }
        static int Sum(int size)
        {
            int sum = 0;
            for (int i = 0; i < size; i++) sum += i;
            return sum;
        }
    }
}
