using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ThreadPrimitives
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c = new();

            int size = 32;

            var t = new Thread[size];

            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(i.ToString().PadLeft(2, '0') + ": ");
            }

            for (int i = 0; i < size; i++)
            {
                t[i] = new(c.Foo) { Name = i.ToString() };
                t[i].Start(size);
            }

            for (int i = 0; i < size; i++) t[i].Join();

            Console.SetCursorPosition(0, size + 1);
            Console.WriteLine(c.Count);
            
        }
    }

    class Counter
    {
        public int Count { get; private set; }
        Dictionary<string, int> d = new();

        private object lckFoo = new();
        static Mutex m = new();
        public void Foo(object size)
        {
            for (int i = 0; i < 100_000; i++)
            {
                //Interlocked.Increment(ref Count);
                //while (Monitor.TryEnter(this) is false);

                //Monitor.Enter(lck);
                //try { Count++; }
                //catch (Exception){ }
                //finally{ Monitor.Exit(lck); }

                //lock (lckFoo) Count++;

                //m.WaitOne();
                lock (lckFoo) {
                Count++;

                string name = Thread.CurrentThread.Name;

                    if (d.ContainsKey(name)) d[name]++;
                    else d.Add(Thread.CurrentThread.Name, 1);
                        
                    

                Console.SetCursorPosition(5, int.Parse(name));
                Console.CursorVisible = false;
                Console.Write(d[name]);

                }
                //m.ReleaseMutex();
                
            }
        }
    }
}
